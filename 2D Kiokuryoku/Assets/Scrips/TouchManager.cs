using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {
    Vector2 touch_point;
    RaycastHit2D hit;
    Touch touch;
    int touchNumber = 0; // オブジェクトをタッチした回数
    PhaseController phaseController = new PhaseController();

    void Update()
    {

        // タッチが開始されたら
        if (Input.touchCount > 0)
        {
            this.touch = Input.touches[0];
            // タッチ座標をVector2に変換
            this.touch_point = Camera.main.ScreenToWorldPoint(this.touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                // Raycast(光線の出る位置, 光線の向き)
                this.hit = Physics2D.Raycast(this.touch_point, Vector2.zero);
                if (this.hit)
                {
                    GameObject selectedObject = this.hit.collider.gameObject;
                    switch (this.phaseController.GetPhase())
                    {
                        case Phase.Title:
                            TitleOperate();
                            break;
                        case Phase.Game:
                            GameOperate();
                            break;
                        case Phase.Result:
                            ResultOperate();
                            break;
                            
                    }
                }
            }
        }
    }

    void RestTouchNumber()
    {
        this.touchNumber = 0;
    }

    void TitleOperate ()
    {

    }

    void GameOperate()
    {
        switch (selectedObject.tag)
        {
            case "Monster":
                this.touchNumber++;
                Debug.Log("Monster TouchNumber : " + this.touchNumber);
                selectedObject.SendMessage("CheckTurn", this.touchNumber);
                break;
            case "Hole":
                this.touchNumber++;
                Debug.Log("Hole TouchNumber : " + this.touchNumber);
                // miss処理を送る
                break;
        }
    }

    void ResultOperate()
    {

    }
}
