using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour {

    public GameObject onePrefab;
    public GameObject twoPrefab;
    public GameObject threePrefab;
    public GameObject startPrefab;

    float timer = 0;
    const float INTERVAL = 1.0f;
    const int MAX_NUMBER = 5;
    int count;

    GameObject monsterController;

    Messages message = Messages.None;



	void Start () 
    {
        this.count = MAX_NUMBER;
        this.monsterController = GameObject.FindWithTag("MonsterController");
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
                        break;
                    case 2:
                        GameObject two = Instantiate(this.twoPrefab, Vector2.zero, Quaternion.identity) as GameObject;
                        two.transform.parent = gameObject.transform;
                        break;
                    case 1:
                        GameObject one = Instantiate(this.onePrefab, Vector2.zero, Quaternion.identity) as GameObject;
                        one.transform.parent = gameObject.transform;

                        break;
                    case 0:
                        GameObject start = Instantiate(this.startPrefab, Vector2.zero, Quaternion.identity) as GameObject;
                        start.transform.parent = gameObject.transform;
                        break;
                    case -1:
                        this.count = MAX_NUMBER;
                        this.monsterController.SendMessage("StartShowsUpAnimation");
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
