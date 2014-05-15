using UnityEngine;
using System.Collections;

public class TouchManagerTest : MonoBehaviour {
    Vector2 touch_point;
    RaycastHit2D hit;
    Touch touch;

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
                    switch (selectedObject.tag) 
                    {
                        case "Monster":
                            selectedObject.SendMessage("ShowsUp");
                            break;
                    }
                }
            }
        }
    }
}
