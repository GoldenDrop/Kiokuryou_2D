using UnityEngine;
using System.Collections;

public class ResultScreen : MonoBehaviour {

    GameObject messageObject;
    GameObject valueActor;

    Transform topText;
    Transform valueText;
    Transform bottomText;

    const string MESSAGE_PATH = "Prefabs/Messages/";
    const string ACTOR_PATH   = "Prefabs/Actors/";

    const string YOU   = "そなたに、";
    const string GIVES = "の称号を与える";


    const float MESSAGE_X = 20.0f;
    const float MESSAGE_Y =  3.2f;
    const float ACTOR_X   = 20.0f;
    const float ACTOR_Y   = -1.0f;




    string[] valueList;

    string[] acterList;

    void Start()
    {
        this.topText    = gameObject.transform.Find("TopText");
        this.valueText  = gameObject.transform.Find("ValueText");
        this.bottomText = gameObject.transform.Find("BottomText");

        SetLists();
        SetText();
        EraseTexts();

    }

    // 各リストに中身をセット　valueListには称号名、acterListにはActorオブジェクト名
    void SetLists()
    {
        this.valueList = new string[] {Values.VALUE_00, Values.VALUE_01, Values.VALUE_02, Values.VALUE_03, Values.VALUE_04, Values.VALUE_05, 
                                       Values.VALUE_06, Values.VALUE_07, Values.VALUE_08, Values.VALUE_09, Values.VALUE_10,};

        this.acterList = new string[] {Actors.ACTOR_00, Actors.ACTOR_01, Actors.ACTOR_02, Actors.ACTOR_03, Actors.ACTOR_04, Actors.ACTOR_05,
                                       Actors.ACTOR_06, Actors.ACTOR_07, Actors.ACTOR_08, Actors.ACTOR_09, Actors.ACTOR_10,};
    }

    // テキストをセット
    void SetText()
    {
        this.topText.guiText.text    = YOU;
        this.bottomText.guiText.text = GIVES;
    }


    // メッセージオブジェクトをトップに生成
    void CreateMessageObject(Phase phase)
    {
        Vector3 messagePoint = new Vector3(MESSAGE_X, MESSAGE_Y, 0);
        string objectPath = "";
        switch (phase)
        {
            case Phase.GameClear:
                objectPath = MESSAGE_PATH + Messages.GAMECLEAR.ToString();
                break;

            case Phase.GameOver:
                objectPath = MESSAGE_PATH + Messages.GAMEOVER.ToString();
                break;
        }
        Debug.Log("******* ResultScreen objectPath : " + objectPath);
        GameObject messagePrefab = Resources.Load(objectPath) as GameObject;
        this.messageObject = Instantiate(messagePrefab, messagePoint, Quaternion.identity) as GameObject;
        this.messageObject.transform.parent = gameObject.transform;
    }

    
    // ResultScreenにあるGameObjectを削除
    void DestroyObjects()
    {
        Destroy(this.messageObject);
        Destroy(this.valueActor);
    }

    // Textを表示する
    void DisplayTexts()
    {
        this.topText.guiText.enabled    = true;
        this.valueText.guiText.enabled  = true;
        this.bottomText.guiText.enabled = true;
    }

    // Textを非表示にする
    void EraseTexts()
    {
        this.topText.guiText.enabled    = false;
        this.valueText.guiText.enabled  = false;
        this.bottomText.guiText.enabled = false;
    }

    // 称号をセット
    void SetValueAndActors(int stageLevel)
    {
        Debug.Log("****** ClearStageLvel : " + (stageLevel));
        string value = this.valueList[stageLevel];
        string actor = this.acterList[stageLevel];
        /*
        if (stageLevel > 0) // クリアステージが0以外なら
        {
            value = this.valueList[stageLevel - 1];
            actor = this.acterList[stageLevel - 1];
        }
        */
        this.valueText.guiText.text = value;
        string path = ACTOR_PATH + actor;

        Vector3 actorPoint = new Vector3(ACTOR_X, ACTOR_Y, 0);
        GameObject valuePrefab = Resources.Load(path) as GameObject;
        this.valueActor = Instantiate(valuePrefab, actorPoint, Quaternion.identity) as GameObject;
        DisplayTexts();
    }
}
