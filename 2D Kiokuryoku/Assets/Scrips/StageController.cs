using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour {

    HolesShuffle shuffleComponent;

    // オブジェクトへの参照
    GameObject gameController;
    GameObject gameMessageWindows;


    // 現在のステージレベル
    int stageLevel = 1;

    // やつけたモンスター数
    int killedMonsterNumber = 0;

    // ステージ毎の出現モンスター数のリスト
    int[] stageMonsterNumberList = new int[] {3, 4, 5, 6, 7, 8, 9, 10, 12, 15};

    StageInfo info;

	void Start () 
    {
        this.gameController     = GameObject.FindWithTag("GameController");
        this.gameMessageWindows = GameObject.FindWithTag("GameMessageWindows");

        this.shuffleComponent = gameObject.GetComponent<HolesShuffle>();

        this.shuffleComponent.FindGameObject();

        SetStageInfo();
        SendStageInfo();
        CreateStage();
	    
	}
	
	void UpdateStageLevel () 
    {
        this.shuffleComponent.DestroyHoles();
        this.stageLevel++;
        SetStageInfo();
        SendStageInfo();
        CreateStage();
	}

    void SetStageInfo ()
    {
        this.info = new StageInfo(this.stageLevel, this.stageMonsterNumberList[this.stageLevel - 1]);
    }

    void SendStageInfo()
    {
        this.gameMessageWindows.SendMessage("CatchStageInfo", this.info);
    }

    void ResetStage()
    {
        this.stageLevel = 1;
        SetStageInfo();
        SendStageInfo();
        this.shuffleComponent.DestroyHoles();
        CreateStage();
    }

    void CreateStage()
    {

        this.killedMonsterNumber = 0;
        this.shuffleComponent.CreateHolesBox(this.stageLevel);
        this.shuffleComponent.RandomSelect(this.info.monsterNumber);
        this.shuffleComponent.DethRandomSelect(2);
        this.shuffleComponent.CreateHoles();
    }

    void CheckKilledMonsterNumber()
    {
        this.killedMonsterNumber++;
        this.gameMessageWindows.SendMessage("UpdateKilledMonster");

        // 全てのモンスターを倒したなら
        if (this.killedMonsterNumber == this.info.monsterNumber)
        {
            // 最終ステージなら
            if (this.stageLevel == this.stageMonsterNumberList.Length) 
            {
                this.gameController.SendMessage("StartGameClear");
            }
            else
            {
                this.gameController.SendMessage("StartStageClear");
            }
        }
    }
}
