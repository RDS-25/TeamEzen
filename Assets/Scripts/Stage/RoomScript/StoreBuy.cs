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
        int nPrice = int.Parse(resourceText.text);
        int nMoney = RoomPlayerManager.nMoney;

        if (nMoney >= nPrice)
        {
            nMoney -= nPrice;

            // 값 던져주기
            // 이름 : 
            // 값 : 
            // 돈 : 
        }
        else
        {
            Debug.Log("돈 부족");
        }
    }

    public void OnClickEventClose()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
