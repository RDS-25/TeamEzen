using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreBuy : MonoBehaviour
{
    public TextMeshProUGUI resourceText;
    
    public void OnClickEventBuy()
    {
        Debug.Log(resourceText);
        int nPrice = int.Parse(resourceText.text);
        int nMoney = PlayerManager.nMoney;

        if(nMoney >= nPrice)
        {
            nMoney -= nPrice;
            

        }else
        {
            Debug.Log("µ∑ ∫Œ¡∑");
        }
    }

    public void OnClickEventClose()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
