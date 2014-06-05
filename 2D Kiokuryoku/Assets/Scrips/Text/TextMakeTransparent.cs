using UnityEngine;
using System.Collections;

public class TextMakeTransparent : MonoBehaviour {

    float alpha = 1;
    SpriteRenderer spriteRenderer;
    public float speed = 1.0f;
    public float destroyTime = 2.0f;

    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        Destroy(gameObject, this.destroyTime);
    }

    void Update()
    {
        this.alpha -= Time.deltaTime / 2;
        this.spriteRenderer.color = new Color(1, 1, 1, alpha);
        gameObject.transform.Translate(Vector3.up * this.speed * Time.deltaTime);
    }
}
