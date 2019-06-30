using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************************************
********************************************************************************
**************	Title:			
**************	Author:
**************	Describe:
**************	Function:
**************	Time:
**************	Other:
********************************************************************************
*********************************************************************************/

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //G 随机得到一个物品放到背包里面
	    if (Input.GetKeyDown(KeyCode.G))
	    {
	        int id = Random.Range(1, 13);
	        Knapsack.Instance.StoreItem(id);
	    }
		
	}
}


