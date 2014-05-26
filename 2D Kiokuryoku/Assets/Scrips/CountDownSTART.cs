using UnityEngine;
using System.Collections;

public class CountDownSTART : MonoBehaviour {

    float alpha = 1;
    float timer = 0;
    const float INTERVAL = 0.1f;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 1);
    }

    void Update()
    {
        this.alpha -= Time.deltaTime;
        this.spriteRenderer.color = new Color(1, 1, 1, alpha);
    }
}
