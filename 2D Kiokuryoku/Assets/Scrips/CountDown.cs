using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour {

    public GameObject onePrefab;
    public GameObject twoPrefab;
    public GameObject threePrefab;
    public GameObject startPrefab;

    float timer = 0;
    const float INTERVAL = 1.0f;
    const int MAX_NUMBER = 4;
    int count;

    GameObject sePlayer;

    Messages message = Messages.None;



	void Start () 
    {
        this.count = MAX_NUMBER;
        this.sePlayer = GameObject.FindWithTag("SEPlayer");

	}
	
	void Update () 
    {
        if (this.message == Messages.CountDown)
        {
            this.timer += Time.deltaTime;

            if (this.timer > INTERVAL)
            {
                this.count--;

                switch (this.count)
                {
                    case 3:
                        GameObject three = Instantiate(this.threePrefab, Vector2.zero, Quaternion.identity) as GameObject;
                        three.transform.parent = gameObject.transform;
                        this.sePlayer.SendMessage("Play", SE.SE_02);
                        break;
                    case 2:
                        GameObject two = Instantiate(this.twoPrefab, Vector2.zero, Quaternion.identity) as GameObject;
                        two.transform.parent = gameObject.transform;
                        this.sePlayer.SendMessage("Play", SE.SE_02);
                        break;
                    case 1:
                        GameObject one = Instantiate(this.onePrefab, Vector2.zero, Quaternion.identity) as GameObject;
                        one.transform.parent = gameObject.transform;
                        this.sePlayer.SendMessage("Play", SE.SE_02);
                        break;
                    case 0:
                        GameObject start = Instantiate(this.startPrefab, Vector2.zero, Quaternion.identity) as GameObject;
                        start.transform.parent = gameObject.transform;
                        this.sePlayer.SendMessage("Play", SE.SE_03);
                        break;
                    case -1:
                        this.count = MAX_NUMBER;
                        this.message = Messages.None;
                        break;
                }


                this.timer = 0;
            }
        }
        
	}

    void SetMessage(Messages m)
    {
        this.message = m;
    }
}
