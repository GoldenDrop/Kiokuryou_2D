using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

    // リソースまでのパス
    const string PATH = "Prefabs/Balloon/B_";

    const float BALLOON_OFFSET_X = 0.6f;

    // Missの吹き出し
    GameObject missBalloon;

    void CreateMissBalloon()
    {
        Vector3 balloonPoint = new Vector3(0, BALLOON_OFFSET_X, 0);
        string balloonPath = PATH + BalloonType.Miss.ToString();
        GameObject balloonPrefab = Resources.Load(balloonPath) as GameObject;
        this.missBalloon = Instantiate(balloonPrefab, transform.position + balloonPoint, Quaternion.identity) as GameObject;
        this.missBalloon.transform.parent = gameObject.transform;
    }

    void DestroyMissBalloon()
    {
        Destroy(this.missBalloon);
    }
}
