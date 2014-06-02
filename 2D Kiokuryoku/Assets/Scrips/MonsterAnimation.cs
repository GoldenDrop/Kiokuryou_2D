using UnityEngine;
using System.Collections;

public class MonsterAnimation : MonoBehaviour {
    Animator animator;
    bool isTouched = false;

    // アタッチしているモンスターが現れた順番
    int myOrder = 0; 

    // リソースまでのパス
    const string PATH = "Prefabs/Balloon/B_";

    const float BALLOON_OFFSET_X = 0.6f;

    // GameObjectへの参照
    GameObject monsterController;

    // オーダー番号の吹き出し
    GameObject orderBalloon;



    void Start()
    {
        this.monsterController = GameObject.FindWithTag("MonsterController");

        this.animator = gameObject.GetComponent<Animator>();

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

                // SEをならす

                // AngryBalloonを作成する
                CreateBalloon(BalloonType.Angry);

                // missメッセージを出す
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
        DestroyBalloon();
    }


    // 吹き出しを生成
    void CreateBalloon(BalloonType type)
    {
        
        Vector3 balloonPoint = new Vector3(0, BALLOON_OFFSET_X, 0);
        string balloonPath = "";

        switch (type)
        {
            case BalloonType.Numbers:
                balloonPath = PATH + this.myOrder;
                break;

            case BalloonType.Angry:
                balloonPath = PATH + BalloonType.Angry.ToString();
                break;
        }

        GameObject balloonPrefab = Resources.Load(balloonPath) as GameObject;
        this.orderBalloon = Instantiate(balloonPrefab, transform.position + balloonPoint, Quaternion.identity) as GameObject;
        this.orderBalloon.transform.parent = gameObject.transform;
    }

    // 吹き出しを削除
    void DestroyBalloon()
    {
        Destroy(this.orderBalloon);
    }

    // 正解の順番をセット
    void SetMyOrder(int order)
    {
        Debug.Log("SetMyOrder : " + order);
        this.myOrder = order;
    }


    // ********** AnimationEventで呼ぶ関数　ここから **********
    void StartNextMonsterAnimation()
    {
        this.monsterController.SendMessage("StartShowsUpAnimation");
    }

    void DisplayNumbersBalloon()
    {
        CreateBalloon(BalloonType.Numbers);
    }
    // ********** AnimationEventで呼ぶ関数　ここまで **********

	
}
