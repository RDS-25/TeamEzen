using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class CharSg_Passive : BuffType
{
    private void OnDisable()
    {
        SkillPath = FolderPath.PARAMS_PASSIVE_SKILL;
        SkillParamsPath = FileName.STR_JSON_CHARSG_PASSIVE_PARAMS;
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
        base.SetType();
        skillType = "PASSIVE";
        enumSkillType = SkillType.PASSIVE;
    }
    public override void SetDefault()
    {
        fSkillLevel = 1;
        fId = 102;
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
   
}
