using System;
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

public class InventoryManager : MonoBehaviour
{

    #region 单例模式
    private static InventoryManager _instance;

    public static InventoryManager Instance
    {
        get
        {
            if (null == _instance)
            {
                //下面的代码只会执行一次
                _instance= GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
            }
            return _instance;

        }
    }
    #endregion

    /// <summary>
    /// 物品信息列表
    /// </summary>
    private  List<Item> itemList;


    public void Start()
    {
        ParseItemJson();
    }
    /// <summary>
    /// 解析物品信息
    /// </summary>
    private  void ParseItemJson()
    {
        itemList=new List<Item>();
        //文本为在Unity里面是TextAsset类型
        TextAsset itemText = Resources.Load<TextAsset>("Items");
        string itemJson = itemText.text; //物品信息的Json格式
        JSONObject j=new JSONObject(itemJson);

        foreach (JSONObject temp in j.list)
        {
            string typeStr= temp["type"].str;
            Item.ItemType type=(Item.ItemType)System.Enum.Parse(typeof (Item.ItemType), typeStr);

            int id =(int)temp["id"].n;
            string name = temp["name"].str;
            Item.QualityType qualitype =
                (Item.QualityType) System.Enum.Parse(typeof (Item.QualityType), temp["qualityType"].str);
            string description = temp["description"].str;
            int capacity = (int)temp["capacity"].n;
            int buyPrice = (int)temp["buyPrice"].n;
            int sellPrice = (int)(temp["sellPrice"].n);
            string sprite = temp["sprite"].str;

            Item item = null;
            switch (type)
            {
                case Item.ItemType.Consumable:
                    int hp =int.Parse(temp["hp"].ToString()) ;
                    int mp = int.Parse(temp["mp"].ToString());
                    item=new Consumable(id,name,type,qualitype,description,capacity,buyPrice,sellPrice,sprite,hp,mp);
                    break;
                case Item.ItemType.Equipment:
                    //TODO
                    break;
                case Item.ItemType.Weapon:
                    //TODO
                    break;
                case Item.ItemType.Material:
                    break;
                
            }
            itemList.Add(item);
            Debug.Log(item);
        }

    }
}


