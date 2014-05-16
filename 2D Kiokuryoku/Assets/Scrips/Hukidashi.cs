using UnityEngine;
using System.Collections;

public class Hukidashi : MonoBehaviour {
    SpriteRenderer hukidashiRenderer;

	void Start () 
    {
        this.hukidashiRenderer = GetComponent<SpriteRenderer>();
	    
	}

    void ChangeTransparency (int alpha) 
    {
        this.hukidashiRenderer.color = new Color(1, 1, 1, alpha);
	}
}
