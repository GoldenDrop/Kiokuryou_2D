using UnityEngine;
using System.Collections;

public class AnimationTestFunction : MonoBehaviour {


    Animator animator;
    GameObject monster;

	void Start () 
    {
        this.animator = gameObject.GetComponent<Animator>();
        this.monster = GameObject.FindWithTag("Monster");
	}

    public void SendShowsUp()
    {
        this.monster.SendMessage("ShowsUp");
    }
}
