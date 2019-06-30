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

public class Equipment : Item {

    /// <summary>
    /// 力量
    /// </summary>
	public int Strength { get; set; }
    /// <summary>
    /// 智力
    /// </summary>
    public int Intelligent { get; set; }
    /// <summary>
    /// 敏捷
    /// </summary>
    public int Agility { get; set; }
    /// <summary>
    /// 体力
    /// </summary>
    public int Stamina { get; set; }
    /// <summary>
    /// 装备类型
    /// </summary>
    public EquipmentType EquipType { get; set; }

    public Equipment(int id, string name, ItemType type, QualityType qualityType, string description, int capacity, int buyPrice, int sellPrice,string sprite,
        int strength,int intelligent,int agility,int stamina,EquipmentType equipType)
        :base(id, name, type, qualityType, description, capacity, buyPrice, sellPrice,sprite)
    {
        this.Strength = strength;
        this.Intelligent = intelligent;
        this.Agility = agility;
        this.Stamina = stamina;
        this.EquipType = equipType;
    }



    public enum EquipmentType
    {
        Head,
        Neck,
        Chest,
        Ring,
        Leg,
        Bracer,
        Roots,    
        Shoulder,
        Belt,
        OffHand

    }
}


