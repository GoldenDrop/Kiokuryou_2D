﻿using UnityEngine;
using System.Collections;

public class MonsterAnimation : MonoBehaviour {
    Animator animator;
    Transform balloon;
    bool isTouched = false;
    bool isWait = false;
    int myOrder = 0; // モンスターが現れた順番

    const string STAND_NAMEHASH_FLONT = "Base Layer.";
    const string STAND_NAMEHASH_BACK  = "Stand";
    string animatoinName = "";

    // GameObjectへの参照
    GameObject monsterController;

    // 数字オブジェクトのリスト
    public GameObject[] numberObjectPrefabList = new GameObject[10];


    void Start()
    {
        this.monsterController = GameObject.FindWithTag("MonsterController");

        this.animator = gameObject.GetComponent<Animator>();
        this.balloon = gameObject.transform.Find("Balloon");

        // モンスターの名前を取得
        string monsterName = gameObject.name.Replace("(Clone)", "");
        // モンスターのStandアニメーション名
        this.animatoinName = STAND_NAMEHASH_FLONT + monsterName + STAND_NAMEHASH_BACK;

        // デバッグ用
        //SetMyTurn(1);
        //ShowsUp();
        //IntoHole();
        //JumpsOut();
    }

    void CheckTurn(int order)
    {
        if (!this.isTouched)// タッチされていないなら
        {
            // タッチされた順番が正しいかチェックする
            if (this.myOrder == order) // 正解なら
            {
                this.isTouched = true;
                JumpsOut();
            }
            else // 不正解なら
            {
                Debug.Log("Touch Miss");
                // missメッセージを出す
                // 
                // 
            }
        }
    }

    void ShowsUp()
    {
        this.animator.SetTrigger("ShowsUp");
    }

    void JumpsOut()
    {
        this.animator.SetTrigger("JumpsOut");
    }

    void IntoHole()
    {
        this.animator.SetTrigger("IntoHole");
        int alpha = 0;
        this.balloon.SendMessage("ChangeTransparency", alpha);
        // 吹き出しの数字オブジェクトを削除
        // DestroyNumberObject();
    }


    void CreateBalloonNumber(int number)
    {
        // 吹き出しに入れる数字オブジェクトを生成する
        // 吹き出しの子オブジェクトとする
    }

    void DestroyNumberObject()
    {
        // 吹き出しの数字オブジェクトを削除
    }

    // 正解である順番をセット
    void SetMyOrder(int order)
    {
        Debug.Log("SetMyOrder : " + order);
        this.myOrder = order;
    }

    void DisplayBalloon()
    {
        int alpha = 1;
        this.balloon.SendMessage("ChangeTransparency", alpha);
    }

    void StartNextMonsterAnimation()
    {
        Debug.Log("StartNextMonsterAnimation");
        this.monsterController.SendMessage("StartShowsUpAnimation");
    }
	
}
