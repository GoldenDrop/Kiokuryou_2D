using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MonsterController : MonoBehaviour {

    List<GameObject> holeObjectList = new List<GameObject>();
    List<int>        orderList      = new List<int>();
    int orderNumber = 0;

    GameObject phaseController;
    GameObject systemMessage;

    PhaseController phaseControlerComponent;


    void Start () 
    {
        this.phaseController = GameObject.FindWithTag("PhaseController");
        this.systemMessage   = GameObject.FindWithTag("SystemMessage");

        this.phaseControlerComponent = this.phaseController.GetComponent<PhaseController>();
	    
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
    

    void StartShowsUpAnimation()
    {
        if (this.orderNumber == 0)
        {
            this.phaseControlerComponent.SetPhase(Phase.Memorizes);
        }

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
            this.phaseControlerComponent.SetPhase(Phase.Wait);

            // 暗幕を下ろす
            this.systemMessage.SendMessage("TakenDownBlackCurtain");

            this.holeObjectList.Clear();
            this.orderList.Clear();
            this.orderNumber = 0;
        }
    }
}
