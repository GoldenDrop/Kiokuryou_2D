using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    GameObject phaseController;
    PhaseController phaseControlerComponent;

	void Start () 
    {
        this.phaseController = GameObject.FindWithTag("PhaseController");
        this.phaseControlerComponent = this.phaseController.GetComponent<PhaseController>();
        this.phaseControlerComponent.SetPhase(Phase.Title);
	}
	
	void Update () 
    {
        Debug.Log("Phase is " + this.phaseControlerComponent.GetPhase());
	}
}
