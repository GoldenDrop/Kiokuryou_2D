using UnityEngine;
using System.Collections;

public class CountDownNumbers : MonoBehaviour {

    float timer = 0;
    const float INTERVAL = 0.1f;
    Vector3 localScale;

	void Start () 
    {
        Destroy(gameObject, 1);
	}
	
	void Update () 
    {
        this.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        this.timer += Time.deltaTime;

        if (this.timer > INTERVAL)
        {
            gameObject.transform.localScale = localScale * 1 / 1.5f;
            this.timer = 0;
        }
	}
}
