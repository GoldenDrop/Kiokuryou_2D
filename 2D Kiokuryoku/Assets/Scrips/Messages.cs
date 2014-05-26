using UnityEngine;
using System.Collections;

public enum Messages 
{
    None,             // 何もない状態
    CountDown,        // ゲームスタートの合図
    StageClear,       // ステージクリアメッセージ
    GameClear,        // ゲームクリアメッセージ
    GameOver,         // ゲームオーバーのメッセージ
    BlackCurtainTakenUp,   // 暗幕をあげる
    BlackCurtainTakenDown, // 暗幕を下げる(被せる)
}
