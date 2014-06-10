using UnityEngine;
using System.Collections;

public enum Messages 
{
    None,                  // 何もない状態 初期化用
    CountDown,             // ゲームスタートの合図
    CLEAR,                 // ステージクリアメッセージ
    CONGRATULATIONS,       // ゲームクリアメッセージ
    MISS,                  // ゲームオーバーのメッセージ
    BlackCurtainTakenUp,   // 暗幕をあげる
    BlackCurtainTakenDown, // 暗幕を下げる(被せる)
    GAMEOVER,              // Result画面の表示
    GAMECLEAR,             // Result画面の表示
}
