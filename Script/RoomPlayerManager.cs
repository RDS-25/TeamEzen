using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPlayerManager : MonoBehaviour
{
    public static int nMoney = 1000; // 돈
    public static float fHealth = 1000f; // 체력
    public static float fDef = 10f; // 방어력
    public static float fAtk = 100f; // 공격력
    public static float fMoveSpeed = 100f; // 이동속도
    public static float fAtkSpeed = 100f; // 공격속도
    public static float fDefBreak = 10f; // 방어구 관통력
    public static float fCriticalPer = 10f; // 크리 확률
    public static float fCriticalDmg = 10f; // 크리 데미지
    public static float fMiss = 10f; // 회피율
    public static float fCoolDownReduction = 10f; // 쿨감
    public static float fHealthSteel = 10f; // 방어구 관통력
    public static float fRecoveryRate = 10f; // 회복량
    public static float fSightRange = 10f; // 시야 사거리
    public static float fDefaultRange = 10f; // 기본 사거리
}