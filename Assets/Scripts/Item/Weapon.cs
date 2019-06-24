using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************************************
********************************************************************************
**************	Title:		武器类	
**************	Author:
**************	Describe:
**************	Function:
**************	Time:
**************	Other:
********************************************************************************
*********************************************************************************/

public class Weapon : Item{

    public int Damage { get; set; }

    public WeaponType WpType { get; set; }

    public Weapon(int id, string name, ItemType type, QualityType qualityType, string description, int capacity, int buyPrice, int sellPrice,string sprite,
        int damage,WeaponType wpType)
        :base(id, name, type, qualityType, description, capacity, buyPrice, sellPrice,sprite)
    {
        this.Damage = damage;
        this.WpType = wpType;
    }

    public enum WeaponType
    {
        OffHand,
        MainHand
    }



}


