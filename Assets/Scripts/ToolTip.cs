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

public class ToolTip : MonoBehaviour
{

    private Text toolTipText;
    private Text contentText;
    private CanvasGroup canvasGroup;

    private float targetAlpha = 0;

    public float smoothSpeed =3;
	// Use this for initialization
	void Start ()
	{

	    toolTipText = GetComponent<Text>();
	    contentText = transform.Find("Content").GetComponent<Text>();
	    canvasGroup = GetComponent<CanvasGroup>();

	}
	
	// Update is called once per frame
	void Update () {
	    if (canvasGroup.alpha != targetAlpha)
	    {
	        canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, smoothSpeed*Time.deltaTime);
	        if (Mathf.Abs(canvasGroup.alpha - targetAlpha) < 0.01)
	        {
	            canvasGroup.alpha = targetAlpha;
	        }
	    }
		
	}

    public void Show(string text)
    {
        toolTipText.text = text;
        contentText.text = text;
        targetAlpha = 1;
    }

    public void Hide()
    {
        targetAlpha = 0;
    }

    public  void SetLocalPosition(Vector3 pos)
    {
        transform.localPosition = pos;
    }
}


 