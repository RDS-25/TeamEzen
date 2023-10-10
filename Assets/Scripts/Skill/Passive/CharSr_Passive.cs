using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class CharSr_Passive : BuffType
{

    private void OnDisable()
    {
        strSkillFolderPath = FolderPath.PARAMS_PASSIVE_SKILL;
        strSkillParamsName = FileName.STR_JSON_CHARSR_PASSIVE_PARAMS;
        PLUS_VAL = 10f;
        PLUS_MAG = 10f;
        PLUS_TARGET_COUNT = 0f;
        PLUS_ATTACK_COUNT = 0f;
        SetType();
        LevelUpValue();
        InitParams();
        //CharaterStatUp(ref ChaStat.fCriticalPer,ref ChaStat.fCriticalDmg);
    }
    public override void SetType()
    {
        base.SetType();
        skillType = "PASSIVE";
        enumSkillType = SkillType.PASSIVE;
    }
    public override void CharaterStatUp(ref float stat1, ref float stat2)
    {
        base.CharaterStatUp(ref ChaStat.fCriticalPer, ref ChaStat.fCriticalDmg);
    }
    public override void SetDefault()
    {
        fSkillLevel = 1;
        fId = 103;
        fCharToUse = 4;
        strName = "Act1";
        strDiscription = "ok";
        strIconName = "CharSrPassive.png";      
        //strEffectPath=
        fSkillExp = 0;
        fSkillRequireExp = 100;
        fUnlockLevel = 1;
        fUnlockHidenLevel = 20;
        fValue = 1.2f;
        fHidenValue = 1.2f;
        fMagnification = 10;
        bisUnlockSkill = false;
        bisUnlockHiden = false;
        bisActtivate = false;
    }
    
}
