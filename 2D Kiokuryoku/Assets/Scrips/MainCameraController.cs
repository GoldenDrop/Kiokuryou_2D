using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {

	
	void Start () 
    {
        CameraMove(Screens.Title);
        // Debug 
        //CameraMove(Screens.Result);
	}
	
    void CameraMove(Screens screen)
    {
        switch (screen)
        {
            case Screens.Title :
                gameObject.transform.localPosition = new Vector3(-20.0f, 0, -10.0f);
                break;
            case Screens.Game:
                gameObject.transform.localPosition = new Vector3(  0.0f, 0, -10.0f);
                break;
            case Screens.Result:
                gameObject.transform.localPosition = new Vector3( 20.0f, 0, -10.0f);
                break;
        }
    }
}
