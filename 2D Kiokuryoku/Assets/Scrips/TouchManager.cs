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
    GameObject title;
    GameObject result;
    GameObject gameController;
    GameObject phaseController;

    // phaseControllerオブジェクトのコンポーネントへの参照
    PhaseController phaseControlerComponent;



    void Start()
    {
        this.mainCamera      = GameObject.FindWithTag("MainCamera");
        this.title           = GameObject.FindWithTag("Title");
        this.result          = GameObject.FindWithTag("Result");
        this.gameController  = GameObject.FindWithTag("GameController");
        this.phaseController = GameObject.FindWithTag("PhaseController");

        this.phaseControlerComponent = this.phaseController.GetComponent<PhaseController>();

    }

    void Update()
    {
        // 現在のフェイズ
        Phase phase = this.phaseControlerComponent.GetPhase();
        Debug.Log("touch phase : " + phase);

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
                this.title.SendMessage("DestroyTexts");
                this.mainCamera.SendMessage("CameraMove", Screens.Game);

                //Debug
                this.phaseControlerComponent.SetPhase(Phase.Player);

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
                            // miss処理を送る
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
            Debug.Log("ResultOperate");
            if (touch.phase == TouchPhase.Began)
            {
               
            }
        }
    }
}
