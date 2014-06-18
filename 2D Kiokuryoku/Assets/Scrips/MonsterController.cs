using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MonsterController : MonoBehaviour {

    List<GameObject> holeObjectList = new List<GameObject>();
    List<int> orderList             = new List<int>();
    List<int> dethList              = new List<int>();
    List<int> dethOrderList         = new List<int>();


    int orderNumber     = 0;
    int dethOrderNumber = 0;

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

    void SetDethList(List<int> list)
    {
        foreach (int number in list)
        {
            Debug.Log("foreach dethOrder : " + number);
            this.dethList.Add(number);
        }
        Debug.Log("dethList Count : " + this.dethList.Count);

        SelectDethOrder(this.dethList.Count);
    }

    void SelectDethOrder(int dethNumber)
    {
        Debug.Log("SelectDethOrder : " + dethNumber);

        for (int i = 0; i < dethNumber; i++)
        {
            Debug.Log("SelectDethOrder this.orderList.Count : " + this.orderList.Count);
            int selectedNumber = Random.Range(0, this.orderList.Count + 1);
            Debug.Log("SelectDethOrder selectedNumber : " + selectedNumber);

            if (this.dethOrderList.Contains(selectedNumber))
            {
                i--;
            }
            else
            {
                this.dethOrderList.Add(selectedNumber);
            }
        }

        for (int j = 0; j < this.dethOrderList.Count; j++)
        {
            Debug.Log("dethOrderList[" + j + "] : " + this.dethOrderList[j]);
        }
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
            GameObject monsterObject = this.holeObjectList[this.orderList[this.orderNumber] - 1];
            
            //Debug.Log(monsterObject.name);
            monsterObject.SendMessage("ShowsUp");
            this.orderNumber++;

            // Dethの出てくる順番なら(dethOrderListにorderNumberがあるなら)
            if (this.dethOrderList.Contains(this.orderNumber))
            {
                int dethIndex = this.dethOrderList.FindIndex(x => x == this.orderNumber);
                //dethListのGameObjectにアニメーション命令
                GameObject dethObject = this.holeObjectList[this.dethList[dethIndex] - 1];
                dethObject.SendMessage("ShowsUp");
                //this.dethOrderNumber++;
            }
            
        }
        else
        {
            yield return new WaitForSeconds(3.0f);
            Debug.Log("Monster Animation Finish");
            this.gameController.SendMessage("StartPlayerPhase");
            //this.orderNumber = 0;
        }
    }

    void StarIntoHoleAnimation()
    {
        int order     = 0;
        int dethOrder = 0;
        for (int i = 0; i < this.orderList.Count; i++)
        {
            GameObject monsterObject = this.holeObjectList[this.orderList[order] - 1];
            Debug.Log(monsterObject.name);
            monsterObject.SendMessage("IntoHole");
            order++;
        }

        // for dethOrderListにもIntoHoleを送る
        for (int j = 0; j < this.dethOrderList.Count; j++)
        {
            GameObject dethObject = this.holeObjectList[this.dethList[dethOrder] - 1];
            Debug.Log("Deth IntoHole : " + (this.dethList[dethOrder] - 1));
            dethObject.SendMessage("IntoHole");
            dethOrder++;
        }

        this.holeObjectList.Clear();
        this.orderList.Clear();
        this.dethList.Clear();
        this.dethOrderList.Clear();

        this.orderNumber     = 0;
        this.dethOrderNumber = 0;
    }
}
