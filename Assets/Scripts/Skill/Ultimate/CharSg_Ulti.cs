using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Params;

public class CharSg_Ulti : ActiveSkill
{
    //스킬레벨업 변수들 스킬마다 써주기  


    void Start()
    {
        SkillParamsPath = FileName.STR_JSON_CHARSG_ULTIMATE_PARAMS;
        PLUS_VAL = 10f;
        PLUS_MAG = 10f;
        PLUS_TARGET_COUNT = 0f;
        PLUS_ATTACK_COUNT = 0f;
        SetType();
        LevelUpValue();
        InitParams();
    }
    public override void SetType()
    {
        skillType = SkillType.ULTIMATE;
        skillDetail = SkillDetailType.ATTACK;
    }
    public override void SetDefault()
    {//액티브스킬에 다시 복붙

        fSkillLevel = 1;
        fId = 302;
        strName = "Act1";
        strDiscription = "ok";
        //strIconpath=
        //strEffectPath=
        fSkillExp = 0;
        fSkillRequireExp = 100;
        fUnlockLevel = 1;
        fUnlockHidenLevel = 20;
        fTimer = 0;
        fCoolTime = 1;
        fDuration = 1;
        fSkillCoolReduce = 0;
        fRange = 50;
        fMaxRange = 10;
        fValue = 10;
        fHidenValue = 10;
        fMagnification = 10;
        fTargetCount = 1;
        fAttackCount = 1;
        fBulletCount = 1;
        bisUnlockSkill = false;
        bisUnlockHiden = false;
        bisCanUse = false;
        bisActtivate = false;
    }
    public override void SetParams()
    {      //스킬타입 넣기
        Dictionary<string, string> dictTemp = new Dictionary<string, string>();
        dictTemp.Add("fSkillLevel", fSkillLevel.ToString());
        dictTemp.Add("fId", fId.ToString());
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



    public override void SkillHidenUnlock()
    {
        if (ChaStat.fLevel > fUnlockHidenLevel)
        {
            bisUnlockHiden = true;
            SkillStat.Add("bisUnlockHiden", true.ToString());
        }
        SetParams();
        //추가기능
    }
}
