using UnityEngine;
using System.Collections;

public class TitleController : MonoBehaviour {

    public GameObject titleTextPrefab;
    public GameObject touchStartTextPrefab;

    GameObject title;
    GameObject touchStart;


	void Start () 
    {
        CreateTexts();
	}
	
    

    void CreateTexts()
    {
        this.title      = Instantiate(this.titleTextPrefab,      new Vector3(0.5f, 0.6f, 0), Quaternion.identity) as GameObject;
        this.touchStart = Instantiate(this.touchStartTextPrefab, new Vector3(0.5f, 0.2f, 0), Quaternion.identity) as GameObject;
    }

    void DestroyTexts()
    {
        Destroy(this.title);
        Destroy(this.touchStart);
    }
}
