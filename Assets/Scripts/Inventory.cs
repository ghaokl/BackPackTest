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

public class Inventory : MonoBehaviour {


    private Slot[] slotList;
	// Use this for initialization
	public  virtual void Start () {
        slotList = GetComponentsInChildren<Slot>();
		
	}
	
	public bool StoreItem(int id)
    {
        Item item = InventoryManager.Instance.GetItemById(id);

        return StoreItem(item);
    }

    public bool StoreItem(Item item)
    {
        if(null==item)
        {
            Debug.LogWarning("要存储的ID物品不存在");
            return false;
        }
        if(item.Capacity==1)
        {
            //TODO
            Slot slot = FindEmptySlot();
            if(null==slot)
            {
                Debug.LogWarning("没有空的物品槽了");
                return false;
            }
            else
            {
                slot.StoreItem(item); //把物品存储到这个空的物品槽

            }
        }
        else
        {
            Slot slot = FindSameTypeSlot(item);
            if(slot!=null)
            {
                slot.StoreItem(item);
            }
            else
            {
                Slot emptySlot = FindEmptySlot();
                if(emptySlot!=null)
                {
                    emptySlot.StoreItem(item);
                }
                else
                {
                    Debug.LogWarning("没有空的物品槽了");
                    return false;
                }
            }

        }
        return true;
    }

    /// <summary>
    /// 这个方法用来找到一个空的物品槽
    /// </summary>
    /// <returns></returns>
    private Slot FindEmptySlot()
    {
        foreach(Slot slot in slotList)
        {
            if(slot.transform.childCount==0)
            {
                return slot;
            }
        }
        return null;
    }

    private Slot FindSameTypeSlot(Item item)
    {
        foreach(Slot slot in slotList)
        {
            if(slot.transform.childCount>=1&&slot.GetItemType()==item.Type&&slot.IsFull()==false)
            {
                return slot;
            }
        }
        return null;
    }
}


