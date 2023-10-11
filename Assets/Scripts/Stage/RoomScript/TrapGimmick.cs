using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrapGimmick : Gimmick
{
    public static string[] STATUS_LIST = new string[] {

         "fHealth", // 체력
         "fDef", // 방어력
         "fAtk", // 공격력
         "fMoveSpeed", // 이동속도
         "fAtkSpeed", // 공격속도
         "fDefBreak", // 방어구 관통력
         "fCriticalPer", // 크리 확률
         "fCriticalDmg", // 크리 데미지
         "fMiss", // 회피율
         "fCoolDownReduction", // 쿨감
         "fHealthSteel", // 흡혈률
         "fRecoveryRate", // 회복량
         "fSightRange", // 시야 사거리
         "fDefaultRange" // 기본 사거리
    };

    StatusInfo cStatusInfo;
    private bool bStart = false;
    string sInfo = "";
    private Image sImg;
    private GameObject tCanvas;
    private TextMeshProUGUI tName;
    private TextMeshProUGUI tInfo;
    MonoBehaviour mb;
    private bool bClearCheck = false;

    public void InitializeGimmick(MonoBehaviour mb, GameObject Stroe, GameObject StoreUi, GameObject TrapUi)
    {
        this.mb = mb;
        tCanvas = TrapUi;
        // GameObject 변수 받아오기
    }

    public void UpdateGimmick()
    {
        if (bClearCheck)
        {
            //mb.gameObject.transform.parent.gameObject.SetActive(false);
            RoomManager.nClearCount++;
            RoomManager.vRoomPos = mb.transform.position;
            bClearCheck = false;
        }
    }

    public void ActiveGimmick()
    {
        if (!bStart)
        {
            bStart = true;
            ShuffleArr(); // 배열 순서 섞기

            int nStatusChoise = Random.Range(0, STATUS_LIST.Length); // 랜덤 값을 통해 배열 내 status를 선택
            int nBuffChoise = Random.Range(0, 2); // 0 = 디버프 / 1 = 버프
            int nPriceChoise = Random.Range(0, 3); // 버프or디버프 정도

            string scPath = "ScriptableObjects/RoomStoreStatus/";
            cStatusInfo = Resources.Load<StatusInfo>(scPath + "Room_Store_" + STATUS_LIST[nStatusChoise]);

            if (nBuffChoise == 0)
            {
                sInfo = cStatusInfo.lincrease[nPriceChoise] + "% 감소합니다.";
            }
            else
            {
                sInfo = cStatusInfo.lincrease[nPriceChoise] + "% 증가합니다.";
            }

            tCanvas.SetActive(true);
            string spPath = "Sprite/";

            sImg = tCanvas.transform.Find("Image").gameObject.GetComponent<Image>();
            sImg.sprite = Resources.Load<Sprite>(spPath + STATUS_LIST[nStatusChoise]);

            tName = tCanvas.transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>();
            tName.text = cStatusInfo.kName;

            tInfo = tCanvas.transform.Find("Info").gameObject.GetComponent<TextMeshProUGUI>();
            tInfo.text = sInfo;

            mb.StartCoroutine(CloseCanvas());

            // 던져 줄 데이터
            // 이름 : STATUS_LIST[nStatusChoise]
            // 값 : cStatusInfo.lincrease[nPriceChoise]
            // 상태(버프or디버프) : nBuffChoise
            // 값으로 한 번에 던져달라고 할 경우 = sInfo 만드는 과정에서 값 데이터를 -or +로 바꿔 보내주면 됨

        }
    }
    public void DiableGimmick()
    {
    }

    public void ShuffleArr()
    {
        for (int i = 0; i < STATUS_LIST.Length; i++)
        {
            int r = UnityEngine.Random.Range(0, STATUS_LIST.Length); // 랜덤 값 받기
            string temp = STATUS_LIST[i]; // 0번째 리스트를 temp에 저장
            STATUS_LIST[i] = STATUS_LIST[r]; // 랜덤 값으로 받은 항목을 0번째 리스트에 넣기 (랜덤 index 항목과 0번째 항목 자리 바꾸기)
            STATUS_LIST[r] = temp; // 랜덤 값으로 받은 항목 위치에 0번째 리스트를 넣기 (랜덤 index 항목과 0번째 항목 자리 바꾸기)
        }
    }

    IEnumerator CloseCanvas()
    {
        yield return new WaitForSeconds(3.0f);
        tCanvas.SetActive(false);
        bClearCheck = true;
    }
}