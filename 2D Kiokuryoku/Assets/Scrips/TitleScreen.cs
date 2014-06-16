using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

    public GameObject titlePrefab;
    public GameObject touchStartTextPrefab;

    GameObject title;
    GameObject touchStart;

    


    void Start()
    {
        CreateTexts();
    }

    void CreateTexts()
    {
        // 題字テキストオブジェクト生成
        this.title = Instantiate(this.titlePrefab, new Vector3(0.5f, 0.6f, 0), Quaternion.identity) as GameObject;

        // タッチスタート　テキストオブジェクト生成
        this.touchStart = Instantiate(this.touchStartTextPrefab, new Vector3(0.5f, 0.2f, 0), Quaternion.identity) as GameObject;
    }

    void DestroyTexts()
    {
        Destroy(this.title);

        Destroy(this.touchStart);
    }

}
