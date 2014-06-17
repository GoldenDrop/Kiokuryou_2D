﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HolesShuffle : MonoBehaviour {

    public GameObject holesBoxPrefab;
    public GameObject holePrefab;

    // モンスターを格納
    public GameObject[] monstersPrefabList = new GameObject[7];

    // GameObjectへの参照
    GameObject monsterController;


    // 穴オブジェクトを格納する
    GameObject holesBox;

    // 穴の数、列数
    const int MAX_Hole = 20;
    const int MAX_Row  = 4;

    // 1つ目の穴の位置　基準になる
    const float FIRST_X = -2.1f;
    const float FIRST_Y =  3.0f;

    // オフセット　次の穴との間隔
    const float OFFSET_X =  1.4f;
    const float OFFSET_Y = -1.5f;

    // モンスターが出現する穴の番号を順に格納
    // 穴は5行４列の20個で左上から右へ数えて番号を付ける
    List<int> orderList = new List<int>();

    // Hole,Monsterオブジェクトを格納
    List<GameObject> holeObjectList = new List<GameObject>();

    // 現在のステージレベル
    int stageLevel = 0;

	public void FindGameObject () 
    {
        this.monsterController = GameObject.FindWithTag("MonsterController");
	}
	

    public void CreateHolesBox(int level)
    {
        this.stageLevel = level;
        this.holesBox = Instantiate(this.holesBoxPrefab, Vector2.zero, Quaternion.identity) as GameObject;
        holesBox.transform.parent = gameObject.transform;
    }

    public void RandomSelect(int rand)
    {
        for (int i = 0; i < rand; i++)
        {
            int selectedNumber = Random.Range(1, MAX_Hole + 1);

            if (this.orderList.Contains(selectedNumber))
            {
                i--;
            }
            else
            {
                this.orderList.Add(selectedNumber);
            }
        }

        for (int j = 0; j < this.orderList.Count; j++)
        {
            Debug.Log("orderList[" + j + "] : " + this.orderList[j]);
        }
    }

    public void CreateHoles()
    {

        for (int i = 0; i < MAX_Hole; i++)
        {
            int row = Mathf.FloorToInt(i / MAX_Row);
            int col = i;
            if (row > 0)
            {
                col = i - row * MAX_Row;
            }

            Vector2 holePoint = new Vector2(FIRST_X + col * OFFSET_X, FIRST_Y + row * OFFSET_Y);

            int order = this.orderList.FindIndex(x => x == i + 1);
            Debug.Log("Number[" + i + "] order : " + order);
            if (order != -1)
            {
                int chooseNumber = MonsterRandomSelect();
                GameObject monster = Instantiate(monstersPrefabList[chooseNumber], holePoint, Quaternion.identity) as GameObject;
                monster.transform.parent = this.holesBox.transform;
                order++;
                monster.SendMessage("SetMyOrder", order);
                this.holeObjectList.Add(monster);
            }
            else
            {
                GameObject hole = Instantiate(holePrefab, holePoint, Quaternion.identity) as GameObject;
                hole.transform.parent = this.holesBox.transform;
                this.holeObjectList.Add(hole);

            }
        }
        this.monsterController.SendMessage("SetHoleObjectList", this.holeObjectList);
        this.monsterController.SendMessage("SetOrderList", this.orderList);
    }

    public void DestroyHoles()
    {
        Destroy(this.holesBox);
        this.holeObjectList.Clear();
        this.orderList.Clear();
    }

    int MonsterRandomSelect()
    {
        int selectIndex = 0;
        if (this.stageLevel == 1)
        {
            selectIndex = 0;
        }
        else if (this.stageLevel < 4)
        {
            selectIndex = Random.Range(0, 2);
        }
        else if (this.stageLevel < 7)
        {
            selectIndex = Random.Range(0, 4);
        }
        else if (this.stageLevel < 9)
        {
            selectIndex = Random.Range(1, 4);
        }
        else
        {
            selectIndex = Random.Range(4, 7);
        }

        return selectIndex;
    }
}
