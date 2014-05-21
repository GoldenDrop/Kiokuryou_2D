using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MonsterController : MonoBehaviour {

    List<GameObject> holeObjectList = new List<GameObject>();
    List<int>        orderList      = new List<int>();
    int orderNumber = 0;

	void Start () 
    {
	
	}

    void SetHoleObjectList (List<GameObject> list) 
    {
        foreach(GameObject obj in list) 
        {
            this.holeObjectList.Add(obj);
            Debug.Log(obj.name);

        }
        Debug.Log("holeObjectList Count : " + this.holeObjectList.Count);
        
    }

    void SetOrderList(List<int> list)
    {
        foreach (int number in list)
        {
            Debug.Log("foreach order : " + number);
            this.orderList.Add(number);
        }
        Debug.Log("orderList Count : " + this.orderList.Count);

    }
    

    void StartStandAnimation()
    {
        if (this.orderNumber < this.orderList.Count)
        {
            Debug.Log(this.orderList[orderNumber]);
            GameObject monsterObject = this.holeObjectList[this.orderList[orderNumber] - 1];
            Debug.Log(monsterObject.name);
            monsterObject.SendMessage("ShowsUp");
            this.orderNumber++;
        }
        else
        {
            // 暗幕を下ろす
            /*
            this.holeObjectList.Clear();
            this.orderList.Clear();
            this.orderNumber = 0;
            */
        }
    }
}
