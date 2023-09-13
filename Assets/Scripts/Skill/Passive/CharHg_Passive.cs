using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class CharHg_Passive : PassiveSkill
{

    void Start()
    {
        SkillPath = FolderPath.PARAMS_PASSIVE_SKILL;
        SkillParamsPath = FileName.STR_JSON_CHARHG_PASSIVE_PARAMS;
        PLUS_VAL = 10f;
        PLUS_MAG = 10f;
        PLUS_TARGET_COUNT = 0f;
        PLUS_ATTACK_COUNT = 0f;
        InitParams();
    }
    public override void SetDefault()
    {
        fSkillLevel = 1;
        fId = 101;
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
}
