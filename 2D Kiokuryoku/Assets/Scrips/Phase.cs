using UnityEngine;
using System.Collections;

public enum Phase 
{ // フェイズ
    Wait,         // 待機 
    Memorizes,    // 記憶フェイズ
    Player,       // Playerフェイズ
    CountDown,    // カウントダウン

    StageClear,   // ステージクリア
    GameClear,    // ゲームクリア(全ステージクリア)
    GameOver,     // ゲームオーバー
    Title,        // タイトル
    Result        // リザルト
}
