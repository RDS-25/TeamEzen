//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Trap : MonoBehaviour
//{
//    public static string[] STATUS_LIST = new string[] {

//         "fHealth", // 체력
//         "fDef", // 방어력
//         "fAtk", // 공격력
//         "fMoveSpeed", // 이동속도
//         "fAtkSpeed", // 공격속도
//         "fDefBreak", // 방어구 관통력
//         "fCriticalPer", // 크리 확률
//         "fCriticalDmg", // 크리 데미지
//         "fMiss", // 회피율
//         "fCoolDownReduction", // 쿨감
//         "fHealthSteel", // 방어구 관통력
//         "fRecoveryRate", // 회복량
//         "fSightRange", // 시야 사거리
//         "fDefaultRange" // 기본 사거리
//    };

//    private bool bStart = false;

//    void OnTriggerEnter(Collider other)
//    {
//        if (!bStart)
//        {
//            bStart = true;
//            ShuffleArr(); // 배열 순서 섞기

//            int nStatusChoise = Random.Range(0, STATUS_LIST.Length); // 랜덤 값을 통해 배열 내 status를 선택
//            int nBuffChoise = Random.Range(0, 1); // 0 = 디버프 / 1 = 버프
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

//            // UI 디자인 => 네모 안의 ? 박스가 1초~2초 정도 돌아가다가 멈추고 설명 
//            // STATUS_LIST[nStatusChoise] 변경 될 스테이터스 항목
//            // 변경 될 수치 (고정 or 랜덤)
//            // 버프인지 디버프인지

//            // 최종으로 나온 값을 캐릭터랑 상의하에 값을 받아서 계산 후 던져줄건지?
//            // 항목과 변화 될 수치만 던져주고 계산하게 할건지 상의

//        }
//    }

//    public void ShuffleArr()
//    {
//        for (int i = 0; i < STATUS_LIST.Length; i++)
//        {
//            int r = UnityEngine.Random.Range(0, STATUS_LIST.Length); // 랜덤 값 받기
//            string temp = STATUS_LIST[i]; // 0번째 리스트를 temp에 저장
//            STATUS_LIST[i] = STATUS_LIST[r]; // 랜덤 값으로 받은 항목을 0번째 리스트에 넣기 (랜덤 index 항목과 0번째 항목 자리 바꾸기)
//            STATUS_LIST[r] = temp; // 랜덤 값으로 받은 항목 위치에 0번째 리스트를 넣기 (랜덤 index 항목과 0번째 항목 자리 바꾸기)
//        }
//    }
//}

