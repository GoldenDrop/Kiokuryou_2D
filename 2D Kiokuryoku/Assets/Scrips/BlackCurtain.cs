using UnityEngine;
using System.Collections;

public class BlackCurtain : MonoBehaviour {

    Messages message = Messages.None;
    public float moveSpeed = 20.0f;

	void Start () 
    {
	
	}
	
	void Update () 
    {
        switch (this.message)
        {
            case Messages.BlackCurtainTakenUp:
                if (gameObject.transform.position.y > -15.0f)
                {
                    Debug.Log("BlackCurtainTakenUp");
                    gameObject.transform.Translate(Vector2.up * this.moveSpeed * Time.deltaTime * -1);

                }
                break;
            case Messages.BlackCurtainTakenDown:
                if (gameObject.transform.position.y > 0)
                {
                    Debug.Log("BlackCurtainTakenDown");
                    gameObject.transform.Translate(Vector2.up * this.moveSpeed * Time.deltaTime * -1);
                }
                break;
            case Messages.None:
                break;
            default:
                Debug.Log("***** BlackCurtain Messages Error. Please select  \"BlackCurtainUp\" or \"BlackCurtainDown\". *****");
                break;

        }
	}

    void ChangeMessage(Messages m)
    {
        this.message = m;
    }
}
