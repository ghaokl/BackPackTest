using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;

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

public class ItemUI : MonoBehaviour {

    #region Data组建
    public Item Item { get; set; }
    public int Amount { get; set; }
    #endregion
    #region  UI组件

    private Image itemImage;
    private Text amountText;

    private Image ItemImage
    {
        get
        {
            if (itemImage == null)
            {
                itemImage = GetComponent<Image>();
            }
            return itemImage;
        }
    }

    private Text AmountText
    {
        get
        {
            if (amountText == null)
            {
                 amountText = GetComponentInChildren<Text>();
            }
            return amountText;
        }
    }
#endregion
    void Start()
    {
       
    }

    public  void SetItem(Item item,int amount=1)
    {
        this.Item = item;
        this.Amount = amount;
        //update UI
        ItemImage.sprite = Resources.Load<Sprite>(item.Sprite);
        if (Item.Capacity > 1)
        {
            AmountText.text = Amount.ToString();
        }
        else
        {
            AmountText.text = "";
        }
        

    }

    public void AddAmount(int amount=1)
    {
        this.Amount += amount;
        //update UI
        if (Item.Capacity > 1)
        {          
            AmountText.text = Amount.ToString();
            
        }
        else
        {
            AmountText.text = "";
        }
    }
}


