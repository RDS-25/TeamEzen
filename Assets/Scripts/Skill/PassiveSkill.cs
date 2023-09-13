using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Params;

public class PassiveSkill : Skill
{
    public override void InitParams()
    {
        if (GameManager.instance.CheckExist(SkillParamsPath, SkillParamsPath))
        {
            LoadParams();
        }
        else
        {
            SetDefault();
            SetParams();
        }

    }
    public override void SetType()
    {
        skillType = SkillType.PASSIVE;
        skillDetail = SkillDetailType.BUFF;
    }
    public override void SetDefault()
    {
        fSkillLevel = 1;
        fId = 10;
        strName = "Act1";
        strDiscription = "ok";
        //strIconpath=
        //strEffectPath=
        fSkillExp = 0;
        fSkillRequireExp = 100;
        fUnlockLevel = 1;
        fUnlockHidenLevel = 20;
        fValue = 10;
        fHidenValue = 10;
        fMagnification = 10;
        bisUnlockSkill = false;
        bisUnlockHiden = false;
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
        //dictTemp.Add("strEffectPath", strEffectPath);
        dictTemp.Add("fSkillExp", fSkillExp.ToString());
        dictTemp.Add("fSkillRequireExp", fSkillRequireExp.ToString());
        dictTemp.Add("fUnlockLevel", fUnlockLevel.ToString());
        dictTemp.Add("fUnlockHidenLevel", fUnlockHidenLevel.ToString());
        dictTemp.Add("fValue", fValue.ToString());
        dictTemp.Add("fHidenValue", fHidenValue.ToString());
        dictTemp.Add("fMagnification", fMagnification.ToString());
        dictTemp.Add("bisUnlockSkill", bisUnlockSkill.ToString());
        dictTemp.Add("bisUnlockHiden", bisUnlockHiden.ToString());
        dictTemp.Add("bisActtivate", bisActtivate.ToString());
        // 이펙트이름

        GameManager.instance.DataWrite(SkillPath + SkillParamsPath, dictTemp);



    }
    public override void LoadParams()
    {
        Dictionary<string, string> dicTemp = GameManager.instance.DataRead(SkillParamsPath);
        fSkillLevel = float.Parse(dicTemp["fSkillLevel"]);
        fId = float.Parse(dicTemp["fId"]);
        strName = dicTemp["strName"];
        strDiscription = dicTemp["fSkillLevel"];
        strIconpath = dicTemp["strIconpath"];
        strEffectPath = dicTemp["strEffectPath"];
        fSkillExp = float.Parse(dicTemp["fSkillExp"]);
        fSkillRequireExp = float.Parse(dicTemp["fSkillRequireExp"]);
        fUnlockLevel = float.Parse(dicTemp["fUnlockLevel"]);
        fUnlockHidenLevel = float.Parse(dicTemp["fUnlockHidenLevel"]);
        fValue = float.Parse(dicTemp["fValue"]);
        fHidenValue = float.Parse(dicTemp["fHidenValue"]);
        fMagnification = float.Parse(dicTemp["fMagnification"]);
        bisUnlockSkill = Convert.ToBoolean(dicTemp["bisUnlockSkill"]);
        bisUnlockHiden = Convert.ToBoolean(dicTemp["bisUnlockHiden"]);
        bisActtivate = Convert.ToBoolean(dicTemp["bisActtivate"]);
    }
    public override void SkillExpUp(float exp)
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
    public override void SkillLevelUp()
    {

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
        SetParams();
        SkillHidenUnlock();

    }
    public override void SkillUnlock()
    {
        if (ChaStat.fLevel > fUnlockLevel)
        {
            bisUnlockSkill = true;
            SkillStat.Add("bisUnlockSkill", true.ToString());
        }
        //추가기능

    }
    public override void SkillHidenUnlock()
    {
        if (fSkillLevel > fUnlockHidenLevel)
        {
            bisUnlockHiden = true;
            SkillStat.Add("bisUnlockHiden", true.ToString());
        }
        //추가기능

    }
    public void CharaterStatUp(ref float stat1,ref float stat2)//ref는 주는 쪽에도 영향을 줌 변수의 얕은 복사
    {
        stat1 = stat1 * fMagnification + fValue;
        
        //올린 스텟을 캐릭파람스에 적용시켜주기
        if (bisUnlockHiden)
        {
            stat2 = stat2 * fHidenValue;            
            //올린 스텟을 캐릭파람스에 적용시켜주기

        }


    }
}
