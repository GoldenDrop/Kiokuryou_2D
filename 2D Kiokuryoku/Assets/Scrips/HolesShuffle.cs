using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HolesShuffle : MonoBehaviour {

    public GameObject holesBoxPrefab;
    public GameObject holePrefab;

    public GameObject[] monstersPrefabList = new GameObject[3];

    GameObject holesBox;

    int maxHole = 20;
    int maxRow  = 4;

    float xOffset =  1.4f;
    float yOffset = -1.5f;

    List<int> selectedList = new List<int>();
    int randomSelectNumber = 0;




	void Start () 
    {
        CreateHolesBox();
        RandomSelect(4);
        CreateHoles();
	}
	
	

    void CreateHolesBox()
    {
        this.holesBox = Instantiate(this.holesBoxPrefab, Vector2.zero, Quaternion.identity) as GameObject;
        holesBox.transform.parent = gameObject.transform;
    }

    void RandomSelect(int rand)
    {
        for (int i = 0; i < rand; i++)
        {
            int selectedNumber = Random.Range(1, this.maxHole + 1);
            if (this.selectedList.Contains(selectedNumber))
            {
                i--;
            }
            else
            {
                this.selectedList.Add(selectedNumber);
            }
        }

        for (int j = 0; j < this.selectedList.Count; j++)
        {
            Debug.Log("selectedList[" + j + "] : " + this.selectedList[j]);
        }
    }

    void CreateHoles()
    {
        Vector2 firstPoint = new Vector2(-2.1f, 3.0f); // 1つ目の穴の位置　基準になる

        for (int i = 0; i < this.maxHole; i++)
        {
            int row = Mathf.FloorToInt(i / this.maxRow);
            int col = i;
            if (row > 0)
            {
                col = i - row * maxRow;
            }
            Vector2 holePoint = new Vector2(col * this.xOffset, row * this.yOffset);

            int order = this.selectedList.FindIndex(x => x == i + 1);
            Debug.Log("Number[" + i + "] order : " + order);
            if (order != -1)
            {
                int rand = Random.Range(0, monstersPrefabList.Length);
                Debug.Log("rand & monstersPrefabList : " + rand + ", " + (monstersPrefabList.Length + 1));
                GameObject moster = Instantiate(monstersPrefabList[rand], firstPoint + holePoint, Quaternion.identity) as GameObject;
                moster.transform.parent = this.holesBox.transform;
                order++;
                moster.SendMessage("SetMyOrder", order);
            }
            else
            {
                GameObject hole = Instantiate(holePrefab, firstPoint + holePoint, Quaternion.identity) as GameObject;
                hole.transform.parent = this.holesBox.transform;
            }
        }
    }

    void DestroyHoles()
    {
        Destroy(this.holesBox);
    }
}
