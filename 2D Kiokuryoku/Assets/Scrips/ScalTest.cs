using UnityEngine;
using System.Collections;

public class ScalTest : MonoBehaviour {
    Animator animator;
    Transform hukidashi;

	void Start () 
    {
        this.animator = gameObject.GetComponent<Animator>();
        this.hukidashi = gameObject.transform.Find("Hukidashi");
	}

    void ShowsUp()
    {
        this.animator.SetTrigger("ShowsUp");
        //IntoHole();
    }

    void JumpsOut()
    {
        this.animator.SetTrigger("JumpsOut");
    }

    void IntoHole()
    {
        this.animator.SetTrigger("IntoHole");
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
        Debug.Log("nameHash : " + stateInfo.nameHash);
        Debug.Log("Hole : " + Animator.StringToHash("Base Layer.Hole"));


        if (stateInfo.nameHash != Animator.StringToHash("Base Layer.Hole"))
        {
            this.hukidashi.SendMessage("ChangeTransparency", 1);
            Debug.Log("Hole Out.");
        }
    }
	
}
