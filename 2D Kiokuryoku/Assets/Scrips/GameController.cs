using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    GameObject phaseController;
    GameObject systemMessage;
    GameObject mainCamera;
    GameObject monsterController;
    GameObject gameMessageWindows;
    GameObject stageController;
    GameObject touchManager;
    GameObject resultScreen;
    GameObject titleScreen;

    



    PhaseController phaseControlerComponent;

	void Start () 
    {
        this.phaseController    = GameObject.FindWithTag("PhaseController");   
        this.systemMessage      = GameObject.FindWithTag("SystemMessage");
        this.mainCamera         = GameObject.FindWithTag("MainCamera");
        this.monsterController  = GameObject.FindWithTag("MonsterController");
        this.gameMessageWindows = GameObject.FindWithTag("GameMessageWindows");
        this.stageController    = GameObject.FindWithTag("StageController");
        this.touchManager       = GameObject.FindWithTag("TouchManager");
        this.resultScreen       = GameObject.FindWithTag("ResultScreen");
        this.titleScreen        = GameObject.FindWithTag("TitleScreen");





        this.phaseControlerComponent = this.phaseController.GetComponent<PhaseController>();
        this.phaseControlerComponent.SetPhase(Phase.Title);
	}
	
	void Update () 
    {
        //Debug.Log("Phase is " + this.phaseControlerComponent.GetPhase());
	}

    void StartMemorizePhase()
    {
        Debug.Log("StartMemorizePhase");
        StartCoroutine("MemorizePhase");
    }

    IEnumerator MemorizePhase()
    {
        Debug.Log("MemorizePhase");
        // 暗幕移動
        this.systemMessage.SendMessage("MoveBlackCurtain", Screens.Title);
        this.systemMessage.SendMessage("TakenDownBlackCurtain");
        yield return new WaitForSeconds(1.0f);

        // MainCameraをゲーム画面へ移動
        this.mainCamera.SendMessage("CameraMove", Screens.Game);

        // 暗幕移動
        this.systemMessage.SendMessage("TakenUpBlackCurtain");
        yield return new WaitForSeconds(1.0f);

        // カウントダウン開始
        this.phaseControlerComponent.SetPhase(Phase.Memorizes);
        this.gameMessageWindows.SendMessage("DisplayTexts", Phase.Memorizes);
        this.systemMessage.SendMessage("DisplayMessage", Messages.CountDown);
        yield return new WaitForSeconds(5.5f);

        // モンスターのアニメーション開始
        this.monsterController.SendMessage("StartShowsUpAnimation");
    }

    


    void StartPlayerPhase()
    {
        Debug.Log("StartPlayerPhase");
        StartCoroutine("PlayerPhase");
    }

    IEnumerator PlayerPhase()
    {
        this.phaseControlerComponent.SetPhase(Phase.Wait);
        this.gameMessageWindows.SendMessage("EraseTexts");
        this.systemMessage.SendMessage("MoveBlackCurtain", Screens.Game);
        //yield return new WaitForSeconds(1.0f);
        this.systemMessage.SendMessage("TakenDownBlackCurtain");
        yield return new WaitForSeconds(1.0f);
        this.monsterController.SendMessage("StarIntoHoleAnimation");
        yield return new WaitForSeconds(1.0f);
        this.systemMessage.SendMessage("TakenUpBlackCurtain");
        yield return new WaitForSeconds(1.0f);

        this.phaseControlerComponent.SetPhase(Phase.Player);
        this.gameMessageWindows.SendMessage("DisplayTexts", Phase.Player);
    }


    void StartGameOver()
    {
        StartCoroutine("GameOver");

    }

    IEnumerator GameOver()
    {
        Debug.Log("GameOver");
        this.phaseControlerComponent.SetPhase(Phase.GameOver);
        this.gameMessageWindows.SendMessage("EraseTexts");

        // Miss演出開始
        yield return new WaitForSeconds(1.0f);
        this.systemMessage.SendMessage("DisplayMessage", Messages.MISS);
        yield return new WaitForSeconds(4.0f);
        // 暗幕移動
        this.systemMessage.SendMessage("MoveBlackCurtain", Screens.Game);
        this.systemMessage.SendMessage("TakenDownBlackCurtain");
        yield return new WaitForSeconds(1.0f);

        this.phaseControlerComponent.SetPhase(Phase.Wait);

        // Result画面へ
        GoToResultScreen();
    }

    void StartStageClear()
    {
        StartCoroutine("StageClear");
    }

    IEnumerator StageClear()
    {
        Debug.Log("StageClear");
        this.phaseControlerComponent.SetPhase(Phase.StageClear);
        this.gameMessageWindows.SendMessage("EraseTexts");

        // Cler演出開始
        yield return new WaitForSeconds(1.0f);
        this.systemMessage.SendMessage("DisplayMessage", Messages.CLEAR);
        yield return new WaitForSeconds(4.0f);

        // 暗幕移動
        this.systemMessage.SendMessage("MoveBlackCurtain", Screens.Game);
        this.systemMessage.SendMessage("TakenDownBlackCurtain");
        yield return new WaitForSeconds(1.0f);

        // 次のステージ作成
        this.stageController.SendMessage("UpdateStageLevel");

        // タッチ数初期化
        this.touchManager.SendMessage("RestTouchNumber");

        StartMemorizePhase();

        yield return new WaitForSeconds(2.0f);

    }

    void StartGameClear()
    {
        StartCoroutine("GameClear");
    }

    IEnumerator GameClear()
    {
        Debug.Log("GameClear");
        this.phaseControlerComponent.SetPhase(Phase.GameClear);
        this.gameMessageWindows.SendMessage("EraseTexts");

        // Miss演出開始
        yield return new WaitForSeconds(1.0f);
        this.systemMessage.SendMessage("DisplayMessage", Messages.CONGRATULATIONS);
        yield return new WaitForSeconds(4.0f);
        // 暗幕移動
        this.systemMessage.SendMessage("MoveBlackCurtain", Screens.Game);
        this.systemMessage.SendMessage("TakenDownBlackCurtain");
        yield return new WaitForSeconds(1.0f);

        this.phaseControlerComponent.SetPhase(Phase.Wait);

        // Result画面へ
        GoToResultScreen();
    }

    void GoToResultScreen()
    {

        // MainCameraをResult画面へ移動
        this.mainCamera.SendMessage("CameraMove", Screens.Result);

        // ステージ初期化 
        this.stageController.SendMessage("ResetStage");

        // Touchmanagerタッチ数初期化
        this.touchManager.SendMessage("RestTouchNumber");

        // Resultテキスト表示
        // アクター生成
        this.resultScreen.SendMessage("SetValueAndActors");

        this.phaseControlerComponent.SetPhase(Phase.Result);
    }


    void GoToTitleScreen()
    {
        // テキストを非表示にする
        this.resultScreen.SendMessage("EraseTexts");

        // Message,ActorのgameObjectを削除
        this.resultScreen.SendMessage("DestroyObjects");

        // MainCameraをTitlet画面へ移動
        this.mainCamera.SendMessage("CameraMove", Screens.Title);

        // Titleのテキストを表示させる
        this.titleScreen.SendMessage("CreateTexts");

        this.phaseControlerComponent.SetPhase(Phase.Result);

    }
}
