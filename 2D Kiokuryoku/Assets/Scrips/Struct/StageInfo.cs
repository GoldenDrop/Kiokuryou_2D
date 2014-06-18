using UnityEngine;
using System.Collections;

public struct StageInfo
{ // ステージ情報

    public int stageLevel;
    public int monsterNumber;
    public int dethNumber;

    public StageInfo(int lv, int monster, int deth)
    {
        stageLevel    = lv;
        monsterNumber = monster;
        dethNumber    = deth; 
    }
}
