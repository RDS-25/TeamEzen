using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="SkillData",menuName ="SkilldataObject",order =1)]
public class Skilldata : ScriptableObject
{
    public float fId;//식별자
    public string sName;//이름        
    public float fSkillLevel = 1f;//스킬레벨
    public string sDiscription;//스킬 설명
    public float fSkillRequireExp;//스킬 레벨업 필요경험치
    public float fSkillExp;//스킬경험치
    public float fUnlockLevel;//스킬해금 필요캐릭터레벨
    public float fUnlockHidenLevel;//스킬 추가특성해제 레벨
    public float fTimer;//스킬타이머
    public float fCoolTime;//스킬 쿨타임
    public float fDuration; //스킬 지속시간        
    public float fSkillCoolReduce;//스킬 쿨타임감소
    public float fBuffDuration;//버프스킬 지속시간
    public float fRange;//스킬범위        
    public float fValue;//스킬 기본데미지
    public float fMagnification;//스킬배율
    public float fTargetCount;//스킬 타겟수
    public float fAttackCount;//스킬타격횟수        
    public float fBulletCount;//발사체 갯수
    public bool isUnlockSkill = false;//스킬 해금
    public bool canUse = false;//스킬이 사용가능한지
    public bool isAtctivate = false;//스킬 발동여부    
}
