using UnityEngine;
using System.Collections;

public class CoroutineTest : MonoBehaviour {

	void Start () {
        StartCoroutine("Test");
	    
	}

    IEnumerator Test()
    {
        Debug.Log("Test");

        yield return new WaitForSeconds(3.0f);
        Debug.Log("Test 1");
    }
}
