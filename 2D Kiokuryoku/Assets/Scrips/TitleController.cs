using UnityEngine;
using System.Collections;

public class TitleController : MonoBehaviour {

    public GameObject titleTextPrefab;
    public GameObject touchStartTextPrefab;

    GameObject title;
    GameObject touchStart;

    PhaseController phaseController = new PhaseController();

	void Start () 
    {
        // Debug
        CreateTexts();
        this.phaseController.SetPhase(Phase.Title);
        
	}
	
	void Update () 
    {
        if (this.phaseController.GetPhase() == Phase.Title)
        {
            Debug.Log("Title Sreen");
        }
	}

    void CreateTexts()
    {
        this.title      = Instantiate(this.titleTextPrefab,      new Vector3(0.5f, 0.6f, 0), Quaternion.identity) as GameObject;
        this.touchStart = Instantiate(this.touchStartTextPrefab, new Vector3(0.5f, 0.2f, 0), Quaternion.identity) as GameObject;
    }

    void DestroyTexts()
    {
        Destroy(this.title);
        Destroy(this.touchStart);
    }
}
