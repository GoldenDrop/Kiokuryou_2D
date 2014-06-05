using UnityEngine;
using System.Collections;

public struct StageInfo
{ // ステージ情報

    public int stageLevel;
    public int monsterNumber;

    public StageInfo(int lv, int number)
    {
        stageLevel    = lv;
        monsterNumber = number;
    }
}
