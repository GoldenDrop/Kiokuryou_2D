using UnityEngine;
using System.Collections;

public class Hukidashi : MonoBehaviour {
    SpriteRenderer hukidashiRenderer;

	void Start () 
    {
        this.hukidashiRenderer = GetComponent<SpriteRenderer>();
	    
	}

    void ChangeTransparency () 
    {
        Color hukidashiColor = new Color(1, 1, 1, 1);
        this.hukidashiRenderer.color = hukidashiColor;
	}
}
