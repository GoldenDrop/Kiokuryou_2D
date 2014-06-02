using UnityEngine;
using System.Collections;

public class MISS : MonoBehaviour {

    float alpha = 1;
    SpriteRenderer spriteRenderer;
    const float SPEED = 1.0f;

    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 2);
    }

    void Update()
    {
        this.alpha -= Time.deltaTime / 2;
        this.spriteRenderer.color = new Color(1, 1, 1, alpha);
        gameObject.transform.Translate(Vector3.up * SPEED * Time.deltaTime);
    }
}
