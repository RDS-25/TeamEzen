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

            // �� �����ֱ�
            // �̸� : 
            // �� : 
            // �� : 
        }
        else
        {
            Debug.Log("�� ����");
        }
    }

    public void OnClickEventClose()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
