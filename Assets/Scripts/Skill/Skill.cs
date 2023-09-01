using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SkillParameter;
using System;


public class Skill: SkilParams
{//1.스킬 해금 2.스킬 발동 3.강화 4.효과거리 5.지속시간
    //스킬 레벨/거리/시간
    

    //스킬마다 지정된값 써주기
    //const float PLUS_VAL = 10f;
    //const float PLUS_MAG = 10f;
    //const float PLUS_TARGET_COUNT = 0f;
    //const float PLUS_ATTACK_COUNT = 0f;

    private void Start()
    {
        InitParams();
        SetType();
    }
    public virtual void InitParams()
    {//데이터파일 있으면 LoadParams() 없으면 SetParams()

    }
    public virtual void SetType()
    {

    }


    public virtual void SetParams()//스킬 파라미터 적용
    {

    }
      public virtual void LoadParams()
    {

    }
    

    public virtual void SkillUnlock()//스킬 해금
    {
    //    if (CharacterLevel > SkilParams.fUnlockLevel)
    //        SkilParams.bisUnlockSkill = true;
    //    //활성화 시키기
    }
   public virtual void SkillHidenUnlock()
    {
        //if (CharacterLevel > SkilParams.fUnlockHidenLevel)
        //    SkilParams.bisUnlockHiden = true;
    }
    public virtual void SkillTriger()//스킬 발동(단발형)
    {//애니메이션, 효과음, 투사체발사, 범위내 대미지주기, 
                   
        
                       
    }
    public virtual void SkillExpUp(float exp)
    {

    }
    public virtual void SkillLevelUp()//스킬 레벨업(강화)
    {//상승후 딕셔너리에 다시 정보주기
        /*SkilParams.fSkillLevel++;
        SkilParams.fValue += damage;//기본대미지 증가
        SkilParams.fMagnification += magnification;//스킬배율 증가
        SkilParams.fAttackCount += attackcount;//타격횟수 증가
        SkilParams.fTargetCount += targetcount;//타겟수 증가
        SkilParams.fSkillRequireExp += SkilParams.fSkillLevel *10;//요구경험치 증가
        float plusdam, float pulsmag,
        float plusattackcount,float plustargetcount*/
    }




}
/*public virtual void ActSkill(float characterstat, float value, float magnification,
       float attackcount, float tartgetcount, float fduration)//스킬작동(대미지형)
{//스킬기본 값, 배율, 타격횟수, 타겟수, 지속시간
    float skilldamage = value + characterstat * magnification;
public virtual void ActSkill(float characterstat, float value, float magnification,
       float attackcount, float tartgetcount, float fduration)//스킬작동(대미지형)
        //여기 있을 필요 없고 이펙트쪽으로
    {//스킬기본 값, 배율, 타격횟수, 타겟수, 지속시간
        skilParams.isAtctivate = false;
    }
    public virtual void ActSkill(float characterstat ,float value, float magnification,
        float fbuffduration)//스킬작동(버프형)
    {//캐릭터 스텟, 기본 스킬값, 배율, 버프 지속시간
        skilParams.fTimer = 0;        
        float buffstat = characterstat + value + characterstat * magnification;
        if (skilParams.isAtctivate == true)
        {

        }
        
        if (skilParams.fTimer >= fbuffduration)
        {
            buffstat = characterstat;
            skilParams.isAtctivate = false;
        }   
    }
public virtual void SkillCoolDown()
    {//쿨타임동안 사용불가 쿨타임 종료시 사용가능
        skilParams.fTimer += Time.deltaTime;
        if (skilParams.fTimer >= skilParams.fCoolTime)
            skilParams.canUse = true;
    }
}*/