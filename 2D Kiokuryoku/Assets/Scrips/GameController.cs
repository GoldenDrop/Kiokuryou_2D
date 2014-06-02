using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    GameObject phaseController;
    GameObject systemMessage;
    GameObject mainCamera;

    GameObject monsterController;


    PhaseController phaseControlerComponent;

	void Start () 
    {
        this.phaseController = GameObject.FindWithTag("PhaseController");   
        this.systemMessage   = GameObject.FindWithTag("SystemMessage");
        this.mainCamera = GameObject.FindWithTag("MainCamera");

        this.monsterController = GameObject.FindWithTag("MonsterController");

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
        this.systemMessage.SendMessage("CreateBlackCurtain", Screens.Title);
        this.systemMessage.SendMessage("TakenDownBlackCurtain");
        yield return new WaitForSeconds(1.0f);

        // MainCameraをゲーム画面へ移動
        this.mainCamera.SendMessage("CameraMove", Screens.Game);

        // 暗幕移動
        this.systemMessage.SendMessage("TakenUpBlackCurtain");
        yield return new WaitForSeconds(1.0f);

        // カウントダウン開始
        this.phaseControlerComponent.SetPhase(Phase.Memorizes);
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
        this.systemMessage.SendMessage("CreateBlackCurtain", Screens.Game);
        yield return new WaitForSeconds(1.0f);
        this.systemMessage.SendMessage("TakenDownBlackCurtain");
        yield return new WaitForSeconds(1.0f);
        this.monsterController.SendMessage("StarIntoHoleAnimation");
        yield return new WaitForSeconds(1.0f);
        this.systemMessage.SendMessage("TakenUpBlackCurtain");
        yield return new WaitForSeconds(1.0f);
        this.phaseControlerComponent.SetPhase(Phase.Player);
    }

    void GameOver()
    {

    }

    void Result()
    {




    }
}
