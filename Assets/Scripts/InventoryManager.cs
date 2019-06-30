using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private ToolTip toolTip;
    private bool isToolTipshow = false;

    private Canvas canvas;
    private Vector2 toolTipPosOffset=new Vector2(10,-10);

    public void Start()
    {
        ParseItemJson();
        toolTip = GameObject.FindObjectOfType<ToolTip>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    void Update()
    {
        if (isToolTipshow)
        {
            //控制显示面板跟随鼠标
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,
                Input.mousePosition, null, out position);        
            toolTip.SetLocalPosition(position + toolTipPosOffset);
        }
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
                    int strength = (int) temp["strength"].n;
                    int intelligent = (int) temp["intelligent"].n;
                    int agility = (int) temp["agility"].n;
                    int stamina = (int) temp["stamina"].n;
                    
                    
                    Equipment.EquipmentType equipType =
                        (Equipment.EquipmentType)
                            System.Enum.Parse(typeof (Equipment.EquipmentType), temp["equipType"].str);
                    
                    item=new Equipment(id,name,type,qualitype,description,capacity,buyPrice,sellPrice,sprite,strength,intelligent,agility,stamina,equipType);
                    break;
                case Item.ItemType.Weapon:
                    //TODO
                    break;
                case Item.ItemType.Material:
                    break;
                
            }
            itemList.Add(item);
            
        }

    }

    /// <summary>
    /// 通过ID来获取Item
    /// </summary>
    public Item GetItemById(int id)
    {
        foreach (Item item in itemList)
        {
            if (item.ID == id)
            {
                return item;
            }
            
        }
        return null;
    }

    public void ShowToolTip(string content)
    {      
        isToolTipshow = true;
        toolTip.Show(content);
    }

    public void HideToolTip()
    {
        isToolTipshow = false;
        toolTip.Hide();
    }
}


