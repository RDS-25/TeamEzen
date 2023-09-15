using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;
using System;
using System.IO;
public class AttackType : Skill
{
    public Transform FirePoint;
    public GameObject EffectPrefab;
    string Path = "/Prefabs/Skill/Effect";

    //스킬레벨업 변수들 스킬마다 써주기


    public override void SetType()
    {
        skillDetail = "ATTACK";//딕셔너리 저장용 변수
        enumSkillDetail = SkillDetailType.ATTACK;
    }    
    public override void SetDefault()
    {//액티브스킬에 다시 복붙

        fSkillLevel = 1;
        fId = 10;
        strName = "Act1";
        strDiscription = "ok";
        skillDetail = "ATTACK";
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
        EffectPrefab = Resources.Load(Path) as GameObject;
    }

    public override void LoadParams()
    {
        Dictionary<string, string> dictTemp = GameManager.instance.DataRead(SkillPath + SkillParamsPath);
        fSkillLevel         = float.Parse(dictTemp["fSkillLevel"]);
        fId                 = float.Parse(dictTemp["fId"]);
        strName             = dictTemp["strName"];
        enumSkillDetail     = (SkillDetailType)Enum.Parse(typeof(SkillDetailType), dictTemp["skillDetail"]);

        fSkillExp           = float.Parse(dictTemp["fSkillExp"]);
        fSkillRequireExp    = float.Parse(dictTemp["fSkillRequireExp"]);
        strDiscription      = dictTemp["strDiscription"];
        fUnlockLevel        = float.Parse(dictTemp["fUnlockLevel"]);
        fUnlockHidenLevel   = float.Parse(dictTemp["fUnlockHidenLevel"]);
        fTimer              = float.Parse(dictTemp["fTimer"]);
        fCoolTime           = float.Parse(dictTemp["fCoolTime"]);
        fDuration           = float.Parse(dictTemp["fDuration"]);
        fSkillCoolReduce    = float.Parse(dictTemp["fSkillCoolReduce"]);
        fRange              = float.Parse(dictTemp["fRange"]);
        fValue              = float.Parse(dictTemp["fValue"]);
        fHidenValue         = float.Parse(dictTemp["fHidenValue"]);
        fMagnification      = float.Parse(dictTemp["fMagnification"]);
        fTargetCount        = float.Parse(dictTemp["fTargetCount"]);
        fAttackCount        = float.Parse(dictTemp["fAttackCount"]);
        fBuffDuration       = float.Parse(dictTemp["fBulletCount"]);
        bisUnlockSkill      = Convert.ToBoolean(dictTemp["bisUnlockSkill"]);
        bisUnlockHiden      = Convert.ToBoolean(dictTemp["bisUnlockHiden"]);
        bisCanUse           = Convert.ToBoolean(dictTemp["bisCanUse"]);
        bisActtivate        = Convert.ToBoolean(dictTemp["bisActtivate"]);
    }
   
    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
        fAttackCount += plusattackcount;//타격횟수 증가
        fTargetCount += plustargetcount;//타겟수 증가
    }


    public override void SkillTriger()
    {
        if (bisCanUse == true || bisActtivate == false)
        {
            bisCanUse = false;

            bisActtivate = true;

            fTimer = 0f;

            EffectStart();//이펙트 있는 스킬인 경우
            StartCoroutine(SkillCoolDown());
        }
        //skillTirger?.Invoke();
    }

    public void LoadEffect()
    {
        EffectPrefab = Resources.Load<GameObject>(strEffectPath + strEffectName);
    }

    public void EffectStart()
    {
        Instantiate(EffectPrefab, FirePoint.position, FirePoint.rotation);//팩토리로 바꾸기
    }
}
