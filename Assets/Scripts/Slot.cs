using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

public class Slot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{


    public GameObject itemPrefab;
    /// <summary>
    /// 把Item放在自身下面
    /// 如果自身下面已经有Item了，Amount++
    /// 如果没有，根据itemPrefa去实例化一个item，放在自身下面
    /// </summary>
    /// <param name="item"></param>
    public void StoreItem(Item item)
    {
        if (transform.childCount == 0)
        {
            GameObject itemGameObject=Instantiate(itemPrefab) as GameObject;
            itemGameObject.transform.SetParent(this.transform);
            itemGameObject.transform.localPosition=Vector3.zero;
            itemGameObject.GetComponent<ItemUI>().SetItem(item);
        }
        else
        {
           transform.GetChild(0).GetComponent<ItemUI>().AddAmount();
        }
        

    }

    /// <summary>
    /// 得到当前物品槽存储的物品类型
    /// </summary>
    /// <returns></returns>
    public Item.ItemType GetItemType()
    {
        return transform.GetChild(0).GetComponent<ItemUI>().Item.Type;
    }

    public int GetItemID()
    {
        return transform.GetChild(0).GetComponent<ItemUI>().Item.ID;
    }

    public bool IsFull()
    {
        ItemUI itemUI = transform.GetChild(0).GetComponent<ItemUI>();
        return itemUI.Amount >= itemUI.Item.Capacity;//当前的数量大于等于容量
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {            
            string toolTipText = transform.GetChild(0).GetComponent<ItemUI>().Item.GetToolTipText();
            InventoryManager.Instance.ShowToolTip(toolTipText);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (transform.childCount > 0)
            InventoryManager.Instance.HideToolTip();
    }
}



