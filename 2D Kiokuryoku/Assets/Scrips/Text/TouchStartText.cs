using UnityEngine;
using System.Collections;

public class TouchStartText : MonoBehaviour {

    float timer          = 0;
    const float INTERVAL = 0.5f;

	void Start () 
    {
        gameObject.guiText.text = "Touch Start";
	}
	
	void Update () 
    {
        this.timer += Time.deltaTime;
        if (this.timer >= INTERVAL ) 
        {
            if (gameObject.guiText.enabled)
            {
                gameObject.guiText.enabled = false;
            }
            else
            {
                gameObject.guiText.enabled = true;
            }
            this.timer = 0;
        }
	}
}
