using UnityEngine;
using System.Collections;

public class GameMessageWindows : MonoBehaviour {

    // 各MessageWindowのtext
    Transform levelText;
    Transform topText;
    Transform bottomText;

    // 各textオブジェクト
    GameObject topTextObject;
    GameObject bottomTextObject;

    // テキスト
    const string LV               = "Lv. ";
    const string ATO              = "あと ";
    const string HIKI             = " 匹";
    const string MEMORIZES_BOTTOM = "モンスターの位置を順番におぼえろ!!";
    const string GAME_BOTTOM      = "かくれたモンスターを順番に退治しろ!!"; 

    // ステージの最大モンスター数
    int maxMonsterNumber;

    //　やつけたモンスター数
    int killedMonster = 0;


	void Awake () 
    {
        this.levelText  = gameObject.transform.Find("TopWindow/LevelText");
        this.topText    = gameObject.transform.Find("TopWindow/TopText");
        this.bottomText = gameObject.transform.Find("BottomWindow/BottomText");

        EraseTexts();
        // デバッグ用
        //StageInfo si = new StageInfo(1, 3);
        //SetStageInfo(new StageInfo(1, 3));
        //DisplayTexts(Phase.Player);
	}

    // ステージ情報をセット
    void CatchStageInfo(StageInfo info)
    {
        this.killedMonster = 0;
        this.maxMonsterNumber = info.monsterNumber;
        Debug.Log("maxMonsterNumber : " + maxMonsterNumber);
        this.levelText.guiText.text = LV + info.stageLevel;

    }

    void UpdateKilledMonster()
    {
        this.killedMonster++;
        this.topText.guiText.text = ATO + (this.maxMonsterNumber - this.killedMonster) + HIKI;
    }

    void DisplayTexts (Phase phase)
    {
        string topTextString    = "";
        string bottomTextString = "";

        switch (phase)
        {
            case Phase.Memorizes:
                topTextString    = this.maxMonsterNumber + HIKI;
                bottomTextString = MEMORIZES_BOTTOM;
                break;

            case Phase.Player:
                topTextString = ATO + (this.maxMonsterNumber - this.killedMonster) + HIKI;;
                bottomTextString = GAME_BOTTOM;
                break;
        }

        this.topText.guiText.text    = topTextString;
        this.bottomText.guiText.text = bottomTextString;

        this.levelText.guiText.enabled  = true;
        this.topText.guiText.enabled    = true;
        this.bottomText.guiText.enabled = true;

    }

    void EraseTexts()
    {
        this.levelText.guiText.enabled  = false;
        this.topText.guiText.enabled    = false;
        this.bottomText.guiText.enabled = false;
    }

    
}
