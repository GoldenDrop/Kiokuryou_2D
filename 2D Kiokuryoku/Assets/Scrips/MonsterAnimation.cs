using UnityEngine;
using System.Collections;

public class MonsterAnimation : MonoBehaviour {
    Animator animator;
    Transform hukidashi;
    bool isTouched = false;
    bool onHukidashi = false;
    int myOrder = 0; // モンスターが現れた順番

    void Start()
    {
        this.animator = gameObject.GetComponent<Animator>();
        this.hukidashi = gameObject.transform.Find("Hukidashi");

        // デバッグ用
        //SetMyTurn(1);
        //ShowsUp();
        //IntoHole();
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
        this.hukidashi.SendMessage("ChangeTransparency", alpha);
        // 吹き出しの数字オブジェクトを削除
        // DestroyNumberObject();
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
        Debug.Log("nameHash : " + stateInfo.nameHash);
        Debug.Log("Wait : " + Animator.StringToHash("Base Layer.Wait"));


        if (stateInfo.nameHash == Animator.StringToHash("Base Layer.Wait"))
        {
            Debug.Log("Base Layer.Wait");
            if (!this.onHukidashi)
            {
                this.onHukidashi = true;
                int alpha = 1;
                this.hukidashi.SendMessage("ChangeTransparency", alpha);
            }
        }
    }

    void CreateHukidashiNumber(int number)
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
	
}
