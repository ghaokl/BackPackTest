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

public class Slot : MonoBehaviour {

    /// <summary>
    /// 把Item放在自身下面
    /// 如果自身下面已经有Item了，Amount++
    /// 如果没有，根据itemPrefa去实例化一个item，放在自身下面
    /// </summary>
    /// <param name="item"></param>
    public void StoreItem(Item item)
    {
        
    }

    /// <summary>
    /// 得到当前物品槽存储的物品类型
    /// </summary>
    /// <returns></returns>
    public Item.ItemType GetItemType()
    {
        return transform.GetChild(0).GetComponent<ItemUI>().Item.Type;
    }

    public bool IsFull()
    {
        ItemUI itemUI = transform.GetChild(0).GetComponent<ItemUI>();
        return itemUI.Amount >= itemUI.Item.Capacity;//当前的数量大于等于容量
    }
}



