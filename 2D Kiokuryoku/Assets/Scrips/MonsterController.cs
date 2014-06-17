using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MonsterController : MonoBehaviour {

    List<GameObject> holeObjectList = new List<GameObject>();
    List<int>        orderList      = new List<int>();
    int orderNumber = 0;

    GameObject gameController;
    GameObject systemMessage;



    void Start()
    {
        this.systemMessage = GameObject.FindWithTag("SystemMessage");
        this.gameController = GameObject.FindWithTag("GameController");
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
        StartCoroutine("ShowsUpAnimation");
        
    }

    IEnumerator ShowsUpAnimation()
    {

        if (this.orderNumber < this.orderList.Count)
        {
            Debug.Log(this.orderList[orderNumber]);
            GameObject monsterObject = this.holeObjectList[this.orderList[orderNumber] - 1];
            
            //Debug.Log(monsterObject.name);
            monsterObject.SendMessage("ShowsUp");
            this.orderNumber++;

            // orderNumberとdethOrderList[0]を比べる
            // if orderNumber == dethOrderList[0]ならdethOrderListから[0]のGameObjectにアニメーション命令＆削除
            
        }
        else
        {
            yield return new WaitForSeconds(3.0f);
            Debug.Log("Monster Animation Finish");
            this.gameController.SendMessage("StartPlayerPhase");
            this.orderNumber = 0;
        }
    }

    void StarIntoHoleAnimation()
    {
        int order = 0;
        for (int i = 0; i < this.orderList.Count; i++)
        {
            GameObject monsterObject = this.holeObjectList[this.orderList[order] - 1];
            Debug.Log(monsterObject.name);
            monsterObject.SendMessage("IntoHole");
            order++;
        }

        // for dethOrderListにもIntoHoleを送る

        this.holeObjectList.Clear();
        this.orderList.Clear();
        this.orderNumber = 0;
    }
}
