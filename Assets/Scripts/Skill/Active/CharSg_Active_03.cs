using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Params;

public class CharSg_Active_03 : BuffType
{
    private void OnDisable()
    {
       
        strSkillFolderPath = FolderPath.PARAMS_ACTIVE_SKILL;
        strSkillParamsName = FileName.STR_JSON_CHARSG_ACTIVE_03_PARAMS;
        PLUS_VAL = 10f;
        PLUS_MAG = 10f;
        PLUS_TARGET_COUNT = 0f;
        PLUS_ATTACK_COUNT = 0f;
        SetType();
        LevelUpValue();
        InitParams();
        //LoadEffect();
    }
    private void Start()
    {
        stat1 = ChaStat.fCriticalDmg;
        stat2 = ChaStat.fCriticalResist;
    }
    public override void SetType()
    {
        base.SetType();
        skillType = "ACTIVE";
        enumSkillType = SkillType.ACTIVE;
    }
    public override void SetDefault()
    {//액티브스킬에 다시 복붙
        fCharToUse = 4f;
        fSkillLevel = 1f;
        fId = 208f;
        strName = "SgActive03";
        strDiscription = "ok";
        strIconName = "CharSgActive03.png";
        strEffectPath = FolderPath.PREFABS_ACTIVE_EFFECT;
        strEffectName = FileName.STR_CHA_SG_ACTIVE_03_EFFECT;
        fSkillExp = 0f;
        fSkillRequireExp = 100f;
        fUnlockLevel = 1f;
        fUnlockHidenLevel = 20f;
        fCoolTime = 30f;
        fDuration = 1f;
        fSkillCoolReduce = 1f;
        fBuffDuration = 10f;
        fValue = 10f;
        fHidenValue = 10f;
        fMagnification = 10f;
        bisUnlockSkill = false;
        bisUnlockHiden = false;
        bisCanUse = false;
        bisActtivate = false;
    }

    

}
