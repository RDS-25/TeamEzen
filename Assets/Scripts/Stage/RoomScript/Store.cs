using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Text.RegularExpressions;

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

    string[,] aStoreData = new string[3,3];

    void OnCollisionEnter(Collision collision)
    {
        gStoreUi.SetActive(true);

        if (!bState)
        {
            bState = true;
            for (int i = 1; i <= nStoreLength; i++)
            {
                string sInformation = "% 증가합니다.";
                int nStatusChoise = Random.Range(0, TrapGimmick.STATUS_LIST.Length); // 랜덤 값을 통해 배열 내 status를 선택
                int nPriceChoise = Random.Range(0, 3); // 0 = 100 / 1 = 200 / 2 = 300

                string scPath = "ScriptableObjects/RoomStoreStatus/";
                cStatusInfo = Resources.Load<StatusInfo>(scPath + "Room_Store_" + TrapGimmick.STATUS_LIST[nStatusChoise]);

                // Name Text 변경
                tName = GameObject.Find("Slot" + i).transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>();
                tName.text = cStatusInfo.kName;

                // 이미지 변경
                string spPath = "Sprites/RoomStoreStatus/";
                sImg = GameObject.Find("Slot" + i).transform.Find("Image").gameObject.GetComponent<Image>();
                sImg.sprite = Resources.Load<Sprite>(spPath + TrapGimmick.STATUS_LIST[nStatusChoise]);

                // 골드 값 변경
                tGold = GameObject.Find("Slot" + i).transform.Find("Button").Find("Gold").gameObject.GetComponent<TextMeshProUGUI>();
                tGold.text = cStatusInfo.lGold[nPriceChoise];

                // Info 설명 변경 (Text 만들어서 lincrease에서 받아오는거 추가)
                sInformation = cStatusInfo.lincrease[nPriceChoise] + sInformation;
                tInfo = GameObject.Find("Slot" + i).transform.Find("Info").gameObject.GetComponent<TextMeshProUGUI>();
                tInfo.text = sInformation;

                aStoreData[i - 1, 0] = TrapGimmick.STATUS_LIST[nStatusChoise]; // 이름
                aStoreData[i - 1, 1] = cStatusInfo.lGold[nPriceChoise]; // 골드
                aStoreData[i - 1, 2] = cStatusInfo.lincrease[nPriceChoise]; // 증가 수치
            }
        }
    }

    public void OnClickEventBuy()
    {

        int nClickNum = int.Parse(Regex.Replace(EventSystem.current.currentSelectedGameObject.transform.parent.name, @"\D", ""));

        Debug.Log(aStoreData[nClickNum-1, 0]); // 이름
        Debug.Log(aStoreData[nClickNum-1, 1]); // 골드
        Debug.Log(aStoreData[nClickNum-1, 2]); // 증가 수치

    }

    public void OnClickEventExit()
    {
        gStoreUi.SetActive(false);
    }
}
