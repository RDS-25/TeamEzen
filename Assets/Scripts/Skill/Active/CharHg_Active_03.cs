using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Params;

public class CharHg_Active_03 : BuffType
{
    private void OnDisable()
    {
        
        strSkillFolderPath = FolderPath.PARAMS_ACTIVE_SKILL;
        strSkillParamsName = FileName.STR_JSON_CHARHG_ACTIVE_03_PARAMS;
        PLUS_VAL = 10f;
        PLUS_MAG = 10f;
        PLUS_TARGET_COUNT = 0f;
        PLUS_ATTACK_COUNT = 0f;
        SetType();
        LevelUpValue();
        InitParams();
     //LoadEffect();
    }
    private void Starrt()
    {
        stat1 = ChaStat.fMoveSpeed;
        stat2 = ChaStat.fAtkSpeed;
    }
    public override void SetType()
    {
        base.SetType();
        skillType = "ACTIVE";
        enumSkillType = SkillType.ACTIVE;
    }
    public override void SetDefault()
    {//액티브스킬에 다시 복붙
        fCharToUse = 3f;
        fSkillLevel = 1f;
        fId = 205f;
        strName = "HgActive03";
        strDiscription = "ok";
        strIconName = "CharHgActive03.png";
        strEffectPath = FolderPath.PREFABS_ACTIVE_EFFECT;
        strEffectName = FileName.STR_CHA_HG_ACTIVE_03_EFFECT;
        fSkillExp = 0f;
        fSkillRequireExp = 100f;
        fUnlockLevel = 1f;
        fUnlockHidenLevel = 20f;
        fCoolTime = 30f;
        fDuration = 1f;
        fSkillCoolReduce = 1f;
        fBuffDuration = 10f;
        fValue = 10f;
        fHidenValue = 10;
        fMagnification = 10f;
        bisUnlockSkill = false;
        bisUnlockHiden = false;
        bisCanUse = false;
        bisActtivate = false;
    }
}
