using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    public GameObject gStoreUi;
    private bool bState = false;
    StatusInfo cStatusInfo;

    int nStoreLength = 3;

    private TextMeshProUGUI tName;
    private TextMeshProUGUI tGold;
    private TextMeshProUGUI tInfo;

    private Image sImg;

    void OnCollisionEnter(Collision collision)
    {
        gStoreUi.SetActive(true);

        if(!bState)
        {
            bState = true;
            for (int i = 1; i <= nStoreLength; i++)
            {
                string sInformation = "% 증가합니다.";
                int nStatusChoise = Random.Range(0, Trap.STATUS_LIST.Length); // 랜덤 값을 통해 배열 내 status를 선택
                int nPriceChoise = Random.Range(0, 2); // 0 = 100 / 1 = 200 / 2 = 300

                string scPath = "ScriptableObjects/Status/";
                cStatusInfo = Resources.Load<StatusInfo>(scPath + Trap.STATUS_LIST[nStatusChoise]);

                // Name Text 변경
                tName = GameObject.Find("Slot" + i).transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>();
                tName.text = cStatusInfo.kName;

                // 이미지 변경
                string spPath = "Sprite/";
                sImg = GameObject.Find("Slot" + i).transform.Find("Image").gameObject.GetComponent<Image>();
                sImg.sprite = Resources.Load<Sprite>(spPath + Trap.STATUS_LIST[nStatusChoise]);

                // 골드 값 변경
                tGold = GameObject.Find("Slot" + i).transform.Find("Button").Find("Gold").gameObject.GetComponent<TextMeshProUGUI>();
                tGold.text = cStatusInfo.lGold[nPriceChoise];

                // Info 설명 변경 (Text 만들어서 lincrease에서 받아오는거 추가)
                sInformation = cStatusInfo.lincrease[nPriceChoise] + sInformation;
                tInfo = GameObject.Find("Slot" + i).transform.Find("Info").gameObject.GetComponent<TextMeshProUGUI>();
                tInfo.text = sInformation;
            }
        }
    }
}
