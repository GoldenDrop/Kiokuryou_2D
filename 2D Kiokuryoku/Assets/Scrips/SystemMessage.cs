using UnityEngine;
using System.Collections;

public class SystemMessage : MonoBehaviour {

    const string BLACK_CURTAIN = "BlackCurtain";

    Transform blackCurtain;
    Transform countDown;

    Vector3 startPoint;

    // リソースまでのパス
    const string PATH = "Prefabs/Messages/";

	void Start () 
    {
        this.blackCurtain = gameObject.transform.Find("BlackCurtain");
        this.countDown    = gameObject.transform.Find("CountDown");
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

    void MoveBlackCurtain(Screens screen)
    {
        switch (screen)
        {
            case Screens.Title:
                this.startPoint = new Vector3( 0.0f,  0.0f, 0.0f);
                break;
            case Screens.Game:
                this.startPoint = new Vector3( 0.0f, 15.0f, 0.0f);
                break;
            case Screens.Result:
                this.startPoint = new Vector3(20.0f, 15.0f, 0.0f);
                break;
        }
        this.blackCurtain.transform.localPosition = this.startPoint;
    }

}
