using UnityEngine;
using System.Collections;

public class DethAnimation : MonoBehaviour {
    Animator animator;

    // リソースまでのパス
    const string PATH = "Prefabs/Balloon/B_Angry";

    const float BALLOON_OFFSET_X = 0.65f;

    // 吹き出し
    GameObject balloon;



    void Start()
    {
        this.animator = gameObject.GetComponent<Animator>();
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

    // 吹き出しを削除
    void DestroyBalloon()
    {
        Destroy(this.balloon);
    }

    // ********** AnimationEventで呼ぶ関数　ここから **********
    void DisplayBalloon()
    {

        Vector3 balloonPoint = new Vector3(0, BALLOON_OFFSET_X, 0);
        GameObject balloonPrefab = Resources.Load(PATH) as GameObject;
        this.balloon = Instantiate(balloonPrefab, transform.position + balloonPoint, Quaternion.identity) as GameObject;
        this.balloon.transform.parent = gameObject.transform;
    }
    // ********** AnimationEventで呼ぶ関数　ここまで **********

	
}
