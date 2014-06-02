using UnityEngine;
using System.Collections;

public class SystemMessage : MonoBehaviour {

    const string BLACK_CURTAIN = "BlackCurtain";
    GameObject blackCurtain;

    Transform countDown;
    Vector2 startPoint;
    Quaternion rotation;

    // リソースまでのパス
    const string PATH = "Prefabs/Messages/";

	void Start () 
    {
        this.countDown = gameObject.transform.Find("CountDown");
        this.rotation.eulerAngles = new Vector3(0, 0, 0.0f);
	}
	

    void TakenUpBlackCurtain()
    {
        this.blackCurtain.SendMessage("ChangeMessage", Messages.BlackCurtainTakenUp);
    }

    void TakenDownBlackCurtain ()
    {
        this.blackCurtain.SendMessage("ChangeMessage", Messages.BlackCurtainTakenDown);

    }

    void DisplayMessage(Messages message)
    {

        if (message == Messages.CountDown) // カウントダウン開始なら
        {
            this.countDown.SendMessage("SetMessage", Messages.CountDown);
        }
        else // それ以外のメッセージなら
        {
            string messagePath = PATH + message.ToString();
            GameObject messageObjectPrefab = Resources.Load(messagePath) as GameObject;
            GameObject messageObject = Instantiate(messageObjectPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            messageObject.transform.parent = gameObject.transform;
        }
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
                this.startPoint = new Vector2(20.0f, 15.0f);
                break;
        }
        string blackCurtainPath = PATH + BLACK_CURTAIN;
        GameObject blackCurtainPrefab = Resources.Load(blackCurtainPath) as GameObject;
        this.blackCurtain = Instantiate(blackCurtainPrefab, this.startPoint, this.rotation) as GameObject;
        this.blackCurtain.transform.parent = gameObject.transform;
    }

    void DestroyBlackCurtain ()
    {
        Destroy(this.blackCurtain);
    }

}
