using UnityEngine;
using System.Collections;

public class ScalTest : MonoBehaviour {
    Animator animator;

	void Start () 
    {
        this.animator = gameObject.GetComponent<Animator>();
        this.animator.SetTrigger("ShowsUp");
	}
	
}
