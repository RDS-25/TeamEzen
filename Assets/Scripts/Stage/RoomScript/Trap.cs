//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Trap : MonoBehaviour
//{
//    public static string[] STATUS_LIST = new string[] {

//         "fHealth", // ü��
//         "fDef", // ����
//         "fAtk", // ���ݷ�
//         "fMoveSpeed", // �̵��ӵ�
//         "fAtkSpeed", // ���ݼӵ�
//         "fDefBreak", // �� �����
//         "fCriticalPer", // ũ�� Ȯ��
//         "fCriticalDmg", // ũ�� ������
//         "fMiss", // ȸ����
//         "fCoolDownReduction", // ��
//         "fHealthSteel", // �� �����
//         "fRecoveryRate", // ȸ����
//         "fSightRange", // �þ� ��Ÿ�
//         "fDefaultRange" // �⺻ ��Ÿ�
//    };

//    private bool bStart = false;

//    void OnTriggerEnter(Collider other)
//    {
//        if (!bStart)
//        {
//            bStart = true;
//            ShuffleArr(); // �迭 ���� ����

//            int nStatusChoise = Random.Range(0, STATUS_LIST.Length); // ���� ���� ���� �迭 �� status�� ����
//            int nBuffChoise = Random.Range(0, 1); // 0 = ����� / 1 = ����
//            Debug.Log(STATUS_LIST[nStatusChoise]);
//            switch (STATUS_LIST[nStatusChoise]) {
//                case "fDef":
//                    double fDef = PlayerManager.fDef;

//                    if (nBuffChoise == 1)
//                    {
//                        fDef = fDef + fDef * 0.05f;
//                    }
//                    else
//                    {
//                        fDef = fDef - fDef * 0.05f;
//                    }

//                    PlayerManager.fDef = (float)fDef;
//                    break;
//                case "fAtk":
//                    double fAtk = PlayerManager.fAtk;

//                    if (nBuffChoise == 1)
//                    {
//                        fAtk = fAtk + fAtk * 0.05f;
//                    }
//                    else
//                    {
//                        fAtk = fAtk - fAtk * 0.05f;
//                    }

//                    PlayerManager.fAtk = (float)fAtk;
//                    break;
//                case "fHealth":
//                    double fHealth = PlayerManager.fHealth;

//                    if (nBuffChoise == 1)
//                    {
//                        fHealth = fHealth + fHealth * 0.05f;
//                    }
//                    else
//                    {
//                        fHealth = fHealth - fHealth * 0.05f;
//                    }

//                    PlayerManager.fHealth = (float)fHealth;
//                    break;
//                case "fMoveSpeed":
//                    double fMoveSpeed = PlayerManager.fMoveSpeed;

//                    if (nBuffChoise == 1)
//                    {
//                        fMoveSpeed = fMoveSpeed + fMoveSpeed * 0.05f;
//                    }
//                    else
//                    {
//                        fMoveSpeed = fMoveSpeed - fMoveSpeed * 0.05f;
//                    }

//                    PlayerManager.fMoveSpeed = (float)fMoveSpeed;
//                    break;
//                case "fDefBreak":
//                    double fDefBreak = PlayerManager.fDefBreak;

//                    if (nBuffChoise == 1)
//                    {
//                        fDefBreak = fDefBreak + fDefBreak * 0.05f;
//                    }
//                    else
//                    {
//                        fDefBreak = fDefBreak - fDefBreak * 0.05f;
//                    }

//                    PlayerManager.fDefBreak = (float)fDefBreak;;
//                    break;
//            }

//            // UI ������ => �׸� ���� ? �ڽ��� 1��~2�� ���� ���ư��ٰ� ���߰� ���� 
//            // STATUS_LIST[nStatusChoise] ���� �� �������ͽ� �׸�
//            // ���� �� ��ġ (���� or ����)
//            // �������� ���������

//            // �������� ���� ���� ĳ���Ͷ� �����Ͽ� ���� �޾Ƽ� ��� �� �����ٰ���?
//            // �׸�� ��ȭ �� ��ġ�� �����ְ� ����ϰ� �Ұ��� ����

//        }
//    }

//    public void ShuffleArr()
//    {
//        for (int i = 0; i < STATUS_LIST.Length; i++)
//        {
//            int r = UnityEngine.Random.Range(0, STATUS_LIST.Length); // ���� �� �ޱ�
//            string temp = STATUS_LIST[i]; // 0��° ����Ʈ�� temp�� ����
//            STATUS_LIST[i] = STATUS_LIST[r]; // ���� ������ ���� �׸��� 0��° ����Ʈ�� �ֱ� (���� index �׸�� 0��° �׸� �ڸ� �ٲٱ�)
//            STATUS_LIST[r] = temp; // ���� ������ ���� �׸� ��ġ�� 0��° ����Ʈ�� �ֱ� (���� index �׸�� 0��° �׸� �ڸ� �ٲٱ�)
//        }
//    }
//}

