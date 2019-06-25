using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************************************
********************************************************************************
**************	Title:	消耗品的类		
**************	Author:
**************	Describe:
**************	Function:
**************	Time:
**************	Other:
********************************************************************************
*********************************************************************************/

public class Consumable : Item {

    public int HP { get; set; }
    public int MP { get; set; }

    public Consumable(int id, string name, ItemType type, QualityType qualityType, string description, int capacity, int buyPrice, int sellPrice,string sprite,int hp,int mp) 
        :base(id,name,type,qualityType,description,capacity,buyPrice,sellPrice,sprite)
    {
        this.HP = hp;
        this.MP = mp;

    }

    public override string ToString()
    {
        string s = "";
        s += ID.ToString();
        s += Type;
        s += Qualitytype;
        s += Description;

       
        
        return s;
    }
}


