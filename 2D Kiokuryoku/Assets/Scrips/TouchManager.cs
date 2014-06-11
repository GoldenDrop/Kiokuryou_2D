using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {

    Vector2 touch_point;
    RaycastHit2D hit;
    Touch touch;

    // オブジェクトをタッチした回数
    int touchNumber = 0; 

    // ゲームオブジェクトへの参照
    GameObject mainCamera;
    GameObject titleScreen;
    GameObject result;
    GameObject gameController;
    GameObject phaseController;
    GameObject monsterController;

    // タッチされたハズレの穴
    GameObject toucedHole;

    // phaseControllerオブジェクトのコンポーネントへの参照
    PhaseController phaseControlerComponent;




    void Start()
    {
        this.mainCamera        = GameObject.FindWithTag("MainCamera");
        this.titleScreen       = GameObject.FindWithTag("TitleScreen");
        this.result            = GameObject.FindWithTag("ResultScreen");
        this.gameController    = GameObject.FindWithTag("GameController");
        this.phaseController   = GameObject.FindWithTag("PhaseController");
        this.monsterController = GameObject.FindWithTag("MonsterController");

        this.phaseControlerComponent = this.phaseController.GetComponent<PhaseController>();

    }

    void Update()
    {
        // 現在のフェイズ
        Phase phase = this.phaseControlerComponent.GetPhase();
        //Debug.Log("touch phase : " + phase);

        // フェイズ毎にタッチ操作を変える
        switch (phase)
        {
            case Phase.Title:
                TitleOperate();
                break;
            case Phase.Player:
                GameOperate();
                break;
            case Phase.Result:
                ResultOperate();
                break;
        }
    }


    void RestTouchNumber()
    {
        this.touchNumber = 0;
    }

    // Title画面でのタッチ操作
    void TitleOperate ()
    {
        if (Input.touchCount > 0)
        {
            this.touch = Input.touches[0];
            Debug.Log("TitleOperate");
            if (touch.phase == TouchPhase.Began)
            {
                this.phaseControlerComponent.SetPhase(Phase.Wait);
                this.titleScreen.SendMessage("DestroyTexts");
                this.gameController.SendMessage("StartMemorizePhase");
            }
        }
    }

    // ゲーム画面でのタッチ操作
    void GameOperate()
    {
        if (Input.touchCount > 0)
        {
            this.touch = Input.touches[0];
            // タッチ座標を変換
            this.touch_point = Camera.main.ScreenToWorldPoint(this.touch.position);
            Debug.Log("GameOperate");
            if (touch.phase == TouchPhase.Began)
            {
                // Raycast(光線の出る位置, 光線の向き)
                this.hit = Physics2D.Raycast(this.touch_point, Vector2.zero);
                if (this.hit)
                {
                    switch (this.hit.collider.gameObject.tag)
                    {
                        case "Monster":
                            this.touchNumber++;
                            Debug.Log("Monster TouchNumber : " + this.touchNumber);
                            this.hit.collider.gameObject.SendMessage("CheckTurn", this.touchNumber);
                            
                            break;
                        case "Hole":
                            this.touchNumber++;
                            Debug.Log("Hole TouchNumber : " + this.touchNumber);
                            this.toucedHole = this.hit.collider.gameObject;
                            this.toucedHole.SendMessage("CreateMissBalloon");
                            // miss処理を送る
                            this.gameController.SendMessage("StartGameOver");
                            break;
                    }
                }
            }
        }
    }


    // Result画面でのタッチ操作 
    void ResultOperate()
    {
        if (Input.touchCount > 0)
        {
            this.touch = Input.touches[0];
            this.touch_point = Camera.main.ScreenToWorldPoint(this.touch.position);

            Debug.Log("ResultOperate");
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("ResultOperate Began");
               this.hit = Physics2D.Raycast(this.touch_point, Vector2.zero);
                if (this.hit)
                {
                    Debug.Log("ResultOperate hit");
                    Debug.Log(this.hit.collider.gameObject.name);
                    Debug.Log(this.hit.collider.gameObject.tag);


                    switch (this.hit.collider.gameObject.name)
                    {
                        case "OKButton":
                            Debug.Log("OKButton Touched");
                            this.gameController.SendMessage("GoToTitleScreen");
                            break;

                        // ボタン追加の予定あり
                    }
                }
            }
        }
    }
}
