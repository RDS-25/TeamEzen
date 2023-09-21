using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrapGimmick : Gimmick
{
    public static string[] STATUS_LIST = new string[] {

         "fHealth", // ü��
         "fDef", // ����
         "fAtk", // ���ݷ�
         "fMoveSpeed", // �̵��ӵ�
         "fAtkSpeed", // ���ݼӵ�
         "fDefBreak", // �� �����
         "fCriticalPer", // ũ�� Ȯ��
         "fCriticalDmg", // ũ�� ������
         "fMiss", // ȸ����
         "fCoolDownReduction", // ��
         "fHealthSteel", // ������
         "fRecoveryRate", // ȸ����
         "fSightRange", // �þ� ��Ÿ�
         "fDefaultRange" // �⺻ ��Ÿ�
    };

    StatusInfo cStatusInfo;
    private bool bStart = false;
    string sInfo = "";
    private Image sImg;
    private Transform tCanvas;
    private TextMeshProUGUI tName;
    private TextMeshProUGUI tInfo;
    MonoBehaviour mb;

    public void InitializeGimmick(MonoBehaviour mb, GameObject a, GameObject b)
    {
        this.mb = mb;
        // GameObject ���� �޾ƿ���
    }
    public void ActiveGimmick()
    {
        if (!bStart)
        {
            bStart = true;
            ShuffleArr(); // �迭 ���� ����

            int nStatusChoise = Random.Range(0, STATUS_LIST.Length); // ���� ���� ���� �迭 �� status�� ����
            int nBuffChoise = Random.Range(0, 2); // 0 = ����� / 1 = ����
            int nPriceChoise = Random.Range(0, 3); // ����or����� ����

            string scPath = "ScriptableObjects/RoomStoreStatus/";
            cStatusInfo = Resources.Load<StatusInfo>(scPath + "Room_Store_" + STATUS_LIST[nStatusChoise]);

            if (nBuffChoise == 0)
            {
                sInfo = cStatusInfo.lincrease[nPriceChoise] + "% �����մϴ�.";
            }
            else
            {
                sInfo = cStatusInfo.lincrease[nPriceChoise] + "% �����մϴ�.";
            }

            tCanvas = GameObject.Find("TrapCanvas").transform;

            string spPath = "Sprite/";
            sImg = tCanvas.transform.Find("Image").gameObject.GetComponent<Image>();
            sImg.sprite = Resources.Load<Sprite>(spPath + STATUS_LIST[nStatusChoise]);

            tName = tCanvas.transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>();
            tName.text = cStatusInfo.kName;

            tInfo = tCanvas.transform.Find("Info").gameObject.GetComponent<TextMeshProUGUI>();
            tInfo.text = sInfo;

            mb.StartCoroutine(CloseCanvas());

            // ���� �� ������
            // �̸� : STATUS_LIST[nStatusChoise]
            // �� : cStatusInfo.lincrease[nPriceChoise]
            // ����(����or�����) : nBuffChoise
            // ������ �� ���� �����޶�� �� ��� = sInfo ����� �������� �� �����͸� -or +�� �ٲ� �����ָ� ��

        }
    }
    public void DiableGimmick()
    {

    }

    public void ShuffleArr()
    {
        for (int i = 0; i < STATUS_LIST.Length; i++)
        {
            int r = UnityEngine.Random.Range(0, STATUS_LIST.Length); // ���� �� �ޱ�
            string temp = STATUS_LIST[i]; // 0��° ����Ʈ�� temp�� ����
            STATUS_LIST[i] = STATUS_LIST[r]; // ���� ������ ���� �׸��� 0��° ����Ʈ�� �ֱ� (���� index �׸�� 0��° �׸� �ڸ� �ٲٱ�)
            STATUS_LIST[r] = temp; // ���� ������ ���� �׸� ��ġ�� 0��° ����Ʈ�� �ֱ� (���� index �׸�� 0��° �׸� �ڸ� �ٲٱ�)
        }
    }

    IEnumerator CloseCanvas()
    {
        yield return new WaitForSeconds(3.0f);
        tCanvas.gameObject.SetActive(false);


    }
}