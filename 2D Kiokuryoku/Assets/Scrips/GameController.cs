using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    GameObject phaseController;
    GameObject systemMessage;
    GameObject mainCamera;


    PhaseController phaseControlerComponent;

	void Start () 
    {
        this.phaseController = GameObject.FindWithTag("PhaseController");   
        this.systemMessage   = GameObject.FindWithTag("SystemMessage");
        this.mainCamera = GameObject.FindWithTag("MainCamera");


        this.phaseControlerComponent = this.phaseController.GetComponent<PhaseController>();
        this.phaseControlerComponent.SetPhase(Phase.Title);
	}
	
	void Update () 
    {
        //Debug.Log("Phase is " + this.phaseControlerComponent.GetPhase());
	}

    void StartMemorizePhase()
    {
        // 暗幕移動
        this.systemMessage.SendMessage("CreateBlackCurtain", Screens.Title);
        this.systemMessage.SendMessage("TakenDownBlackCurtain");
        this.mainCamera.SendMessage("CameraMove", Screens.Game);
        //this.systemMessage.SendMessage("TakenDownBlackCurtain");
        this.systemMessage.SendMessage("StartCountDown");
        //this.monsterController.SendMessage("StartShowsUpAnimation");
    }

    void StartPlayerPhase()
    {

    }

    void GameOver()
    {

    }

    void Result()
    {




    }
}
