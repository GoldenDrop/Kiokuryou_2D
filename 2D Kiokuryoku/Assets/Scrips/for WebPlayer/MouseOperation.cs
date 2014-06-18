using UnityEngine;
using System.Collections;

public class MouseOperation : MonoBehaviour {

    RaycastHit2D hit;

    // オブジェクトをタッチした回数
    int touchNumber = 0; 

    // ゲームオブジェクトへの参照
    GameObject mainCamera;
    GameObject titleScreen;
    GameObject result;
    GameObject gameController;
    GameObject phaseController;
    GameObject monsterController;
    GameObject sePlayer;

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
        this.sePlayer          = GameObject.FindWithTag("SEPlayer");


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

    // Title画面でのクリック操作
    void TitleOperate ()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("TitleOperate");

            this.sePlayer.SendMessage("Play", SE.SE_01);
            this.phaseControlerComponent.SetPhase(Phase.Wait);
            this.titleScreen.SendMessage("DestroyTexts");
            this.gameController.SendMessage("StartMemorizePhase");
        }
    }

    // ゲーム画面でのクリック操作
    void GameOperate()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("GameOperate");
            // クリック座標を変換
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Raycast(光線の出る位置, 光線の向き)
            this.hit = Physics2D.Raycast(mousePoint, Vector2.zero);
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
                        this.sePlayer.SendMessage("Play", SE.SE_05);
                        // miss処理を送る
                        this.gameController.SendMessage("StartGameOver");
                        break;    

                    case "Deth":
                        this.touchNumber++;
                        Debug.Log("Deth Touch!");
                        this.toucedHole = this.hit.collider.gameObject;
                        this.toucedHole.SendMessage("JumpsOut");
                        this.sePlayer.SendMessage("Play", SE.SE_11);
                        // miss処理を送る
                        this.gameController.SendMessage("StartGameOver");
                        break;
                    }
                }
            }
    }


    // Result画面でのクリック操作 
    void ResultOperate()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("ResultOperate");
            // クリック座標を変換
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.hit = Physics2D.Raycast(mousePoint, Vector2.zero);
            if (this.hit)
            {
                Debug.Log("ResultOperate hit");

                switch (this.hit.collider.gameObject.name)
                {
                    case "OKButton":
                        Debug.Log("OKButton Touched");
                        this.sePlayer.SendMessage("Play", SE.SE_01);
                        this.gameController.SendMessage("GoToTitleScreen");
                        break;

                        // ボタン追加の予定あり
                }
            }
            
        }
    }
}
