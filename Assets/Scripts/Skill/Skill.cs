using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;
using System;


public class Skill: SkillParams
{//1.스킬 해금 2.스킬 발동 3.강화 4.효과거리 5.지속시간
    //스킬 레벨/거리/시간
    protected string SkillPath;//폴더경로
    protected string SkillParamsPath;//파일경로
    protected Dictionary<string, string> SkillStat;//딕셔너리 사용

    //스킬마다 지정된값 써주기
    protected float PLUS_VAL = 10f;
    protected float PLUS_MAG = 10f;
    protected float PLUS_TARGET_COUNT = 0f;
    protected float PLUS_ATTACK_COUNT = 0f;
    protected Stat ChaStat;


    public void SkillActivationInit(ref Stat activeObjectStat)//스킬 장착할때 불러달라고 말하기
    {
        ChaStat = activeObjectStat;
    }
    protected void LevelUpValue()
    {
        plusval = PLUS_VAL;
        pulsmag = PLUS_MAG;
        plustargetcount = PLUS_TARGET_COUNT;
        plusattackcount = PLUS_ATTACK_COUNT;
    }
    public virtual void InitParams()
    {//데이터파일 있으면 LoadParams() 없으면 SetParams()
        if (GameManager.instance.CheckExist(SkillParamsPath, SkillParamsPath))
        {
            LoadParams();
        }
        else
        {
            SetDefault();
            SaveParams();
        }
    }
    public virtual void SetType()
    {

    }
    public virtual void SetDefault()//첫 스킬파라미터 입력
    {

    }

    protected void SaveParams()//스킬 파라미터 적용

    {
        //스킬타입 넣기, 안들어간 값 다쓰기
        Dictionary<string, string> dictTemp = new Dictionary<string, string>();
        dictTemp.Add("fSkillLevel", fSkillLevel.ToString());
        dictTemp.Add("fId", fId.ToString());
        dictTemp.Add("skillDetail", skillDetail);
        dictTemp.Add("strName", strName);
        dictTemp.Add("strDiscription", strDiscription);
        dictTemp.Add("strIconpath", strIconpath);
        dictTemp.Add("strEffectPath", strEffectPath);
        dictTemp.Add("fSkillExp", fSkillExp.ToString());
        dictTemp.Add("fSkillRequireExp", fSkillRequireExp.ToString());
        dictTemp.Add("fUnlockLevel", fUnlockLevel.ToString());
        dictTemp.Add("fUnlockHidenLevel", fUnlockHidenLevel.ToString());
        dictTemp.Add("fTimer", fTimer.ToString());
        dictTemp.Add("fCoolTime", fCoolTime.ToString());
        dictTemp.Add("fDuration", fDuration.ToString());
        dictTemp.Add("fSkillCoolReduce", fSkillCoolReduce.ToString());
        dictTemp.Add("fRange", fRange.ToString());
        dictTemp.Add("fMaxRange", fMaxRange.ToString());
        dictTemp.Add("fValue", fValue.ToString());
        dictTemp.Add("fHidenValue", fHidenValue.ToString());
        dictTemp.Add("fMagnification", fMagnification.ToString());
        dictTemp.Add("fTargetCount", fTargetCount.ToString());
        dictTemp.Add("fAttackCount", fAttackCount.ToString());
        dictTemp.Add("fBulletCount", fBulletCount.ToString());
        dictTemp.Add("bisUnlockSkill", bisUnlockSkill.ToString());
        dictTemp.Add("bisUnlockHiden", bisUnlockHiden.ToString());
        dictTemp.Add("bisCanUse", bisCanUse.ToString());
        dictTemp.Add("bisActtivate", bisActtivate.ToString());
        // 이펙트이름
        GameManager.instance.DataWrite(SkillPath + SkillParamsPath, dictTemp);
    }

    public virtual void LoadParams()
    {
        Dictionary<string, string> dictTemp = GameManager.instance.DataRead(SkillPath);
        fSkillLevel = float.Parse(dictTemp["fSkillLevel"]);
        fId = float.Parse(dictTemp["fId"]);
        strName = dictTemp["strName"];
        enumSkillDetail = (SkillDetailType)Enum.Parse(typeof(SkillDetailType), dictTemp["skillDetail"]);

        fSkillExp = float.Parse(dictTemp["fSkillExp"]);
        fSkillRequireExp = float.Parse(dictTemp["fSkillRequireExp"]);
        strDiscription = dictTemp["strDiscription"];
        fUnlockLevel = float.Parse(dictTemp["fUnlockLevel"]);
        fUnlockHidenLevel = float.Parse(dictTemp["fUnlockHidenLevel"]);
        fTimer = float.Parse(dictTemp["fTimer"]);
        fCoolTime = float.Parse(dictTemp["fCoolTime"]);
        fDuration = float.Parse(dictTemp["fDuration"]);
        fSkillCoolReduce = float.Parse(dictTemp["fSkillCoolReduce"]);
        fRange = float.Parse(dictTemp["fRange"]);
        fValue = float.Parse(dictTemp["fValue"]);
        fHidenValue = float.Parse(dictTemp["fHidenValue"]);
        fMagnification = float.Parse(dictTemp["fMagnification"]);
        fTargetCount = float.Parse(dictTemp["fTargetCount"]);
        fAttackCount = float.Parse(dictTemp["fAttackCount"]);
        fBuffDuration = float.Parse(dictTemp["fBulletCount"]);
        bisUnlockSkill = Convert.ToBoolean(dictTemp["bisUnlockSkill"]);
        bisUnlockHiden = Convert.ToBoolean(dictTemp["bisUnlockHiden"]);
        bisCanUse = Convert.ToBoolean(dictTemp["bisCanUse"]);
        bisActtivate = Convert.ToBoolean(dictTemp["bisActtivate"]);
    }
    

    public virtual void SkillUnlock()//스킬 해금
    {
        if (fSkillLevel > fUnlockLevel)
        {
            bisUnlockSkill = true;
            SkillStat.Add("bisUnlockSkill", true.ToString());
        }
        SaveParams();
        //추가기능
    }
    public virtual void SkillHidenUnlock()
    {
        if (ChaStat.fLevel > fUnlockHidenLevel)
        {
            bisUnlockHiden = true;
            SkillStat.Add("bisUnlockHiden", true.ToString());
        }
        SaveParams();
        //추가기능

    }
    public virtual void SkillTriger()//스킬 발동(단발형)
    {//애니메이션, 효과음, 투사체발사, 범위내 대미지주기, 
                   
        
                       
    }
    
    public virtual void SkillExpUp(float exp)
    {
        fSkillExp += exp;
        if (fSkillExp >= fSkillRequireExp)
        {
            SkillLevelUp();
            fSkillExp -= fSkillRequireExp;
            SkillStat.Add("fSkillExp", fSkillExp.ToString());
        }
        else
            SkillStat.Add("fSkillExp", fSkillExp.ToString());
    }
    public virtual void SkillLevelUp()//스킬 레벨업(강화)
    {//상승후 딕셔너리에 다시 정보주기
        if (fSkillLevel % 5 == 0)
        {
            if (fSkillLevel % 5 == 0)
                checkLevel = 1f;
            else
                checkLevel = 0f;

            plusval = PLUS_VAL + (checkLevel * 10f);
            pulsmag = PLUS_MAG + (checkLevel * 10f);

        }
        fSkillLevel++;//레벨
        fValue += plusval;//기본대미지
        fMagnification += pulsmag;//대미지상승량
        fSkillRequireExp += fSkillLevel * 10;//요구경험치 증가

        SaveParams();
        SkillHidenUnlock();
    }
    public virtual IEnumerator SkillCoolDown()
    {
        yield return new WaitForSeconds(fCoolTime);
        bisCanUse = true;
        bisActtivate = false;
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