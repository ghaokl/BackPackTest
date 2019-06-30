using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************************************
*****************Title:	物品的基类		
*****************Author:
*****************Describe:
*****************Function:
*****************Time:
*****************Other:
*********************************************************************************/

public class Item  {

	public int ID { get; set; }
    public string Name { get; set; }

    public ItemType Type { get; set; }
    public QualityType Qualitytype { get; set; }
    public string Description { get; set; }
    public int Capacity { get; set; }
    public int BuyPrice { get; set; }
    public int SellPrice { get; set; }
    public string Sprite { get; set; }

    public Item(int id,string name,ItemType type,QualityType qualityType,string description,int capacity,int buyPrice,int sellPrice,string sprite)
    {
        this.ID = id;
        this.Name = name;
        this.Type = type;
        this.Qualitytype = qualityType;
        this.Description = description;
        this.Capacity = capacity;
        this.BuyPrice = buyPrice;
        this.SellPrice = sellPrice;
        this.Sprite = sprite;
    }

    public Item()
    {
        this.ID = -1;
    }



    /// <summary>
    /// 物品类型
    /// </summary>
    public  enum ItemType
    {
        Consumable,
        Equipment,
        Weapon,
        Material
    }

    /// <summary>
    /// 品质类型
    /// </summary>
    public enum QualityType
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
        Artifact
    }

    /// <summary>
    /// 得到提示面板显示什么样的内容
    /// </summary>
    /// <returns></returns>
    public virtual string GetToolTipText()
    {
        return Name;//TODO

    }
}


