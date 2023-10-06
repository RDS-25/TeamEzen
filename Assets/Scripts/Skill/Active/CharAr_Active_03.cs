using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Params;

public class CharAr_Active_03 : BuffType
{
    private void OnDisable()
    {
        strSkillFolderPath = FolderPath.PARAMS_ACTIVE_SKILL;
        strSkillParamsName = FileName.STR_JSON_CHARAR_ACTIVE_03_PARAMS;
        PLUS_VAL = 10f;
        PLUS_MAG = 10f;
        PLUS_TARGET_COUNT = 0f;
        PLUS_ATTACK_COUNT = 0f;
        SetType();
        LevelUpValue();
        InitParams();
     //LoadEffect();
    }
    
    public override void SetType()
    {
        base.SetType();
        skillType = "ACTIVE";
        enumSkillType = SkillType.ACTIVE;
    }
    public override void SetDefault()
    {//액티브스킬에 다시 복붙
        fCharToUse = 1;
        fSkillLevel = 1;
        fId = 202;
        strName = "Act1";
        strDiscription = "ok";
        strIconName = "CharArActive03.png";
        strEffectPath = FolderPath.PREFABS_ACTIVE_EFFECT;
        strEffectName = FileName.STR_CHA_AR_ACTIVE_03_EFFECT;
        fSkillExp = 0;
        fSkillRequireExp = 100;
        fUnlockLevel = 1;
        fUnlockHidenLevel = 20;        
        fCoolTime = 30;
        fDuration = 1;
        fSkillCoolReduce = 1;
        fBuffDuration = 10;        
        fValue = 1.2f;
        fHidenValue = 1.2f;
        fMagnification = 10;        
        bisUnlockSkill = false;
        bisUnlockHiden = false;
        bisCanUse = false;
        bisActtivate = false;
    }
    public override void CharaterStatUp(ref float stat1, ref float stat2)//스킬 버튼 눌렀을때
    {
        base.CharaterStatUp(ref ChaStat.fAtkSpeed, ref ChaStat.fCriticalPer);
    }
}
