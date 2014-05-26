using UnityEngine;
using System.Collections;

public class SystemMessage : MonoBehaviour {

    public GameObject blackCurtainPrefab;
    public GameObject stageClearPrefab;
    public GameObject GameCearPrefab;
    public GameObject gameOverPrefab;

    GameObject blackCurtain;
    Transform countDown;

    Vector2 startPoint;
    Quaternion rotation;


	void Start () 
    {
        this.countDown = gameObject.transform.Find("CountDown");
        this.rotation.eulerAngles = new Vector3(0, 0, 0.0f);
	}
	
    void StartCountDown()
    {
        TakenUpBlackCurtain();
        this.countDown.SendMessage("SetMessage", Messages.CountDown);
    }

    void CreateBlackCurtain(Screens screen)
    {
        switch (screen)
        {
            case Screens.Title:
                this.startPoint = new Vector2(0.0f, 0.0f);
                break;
            case Screens.Game:
                this.startPoint = new Vector2(0.0f, 15.0f);
                break;
            case Screens.Result:
                this.startPoint = new Vector2( 20.0f, 15.0f);
                break;
        }

        this.blackCurtain = Instantiate(blackCurtainPrefab, this.startPoint, this.rotation) as GameObject;
        this.blackCurtain.transform.parent = gameObject.transform;
    }

    void TakenUpBlackCurtain()
    {
        this.blackCurtain.SendMessage("ChangeMessage", Messages.BlackCurtainTakenUp);
    }

    void TakenDownBlackCurtain ()
    {
        this.blackCurtain.SendMessage("ChangeMessage", Messages.BlackCurtainTakenDown);

    }

    void DestroyBlackCurtain ()
    {
        Destroy(this.blackCurtain);
    }
}
