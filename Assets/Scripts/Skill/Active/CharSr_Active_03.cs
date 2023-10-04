using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Params;

public class CharSr_Active_03 : BuffType
{
    private void OnDisable()
    {
        strSkillFolderPath = FolderPath.PARAMS_ACTIVE_SKILL;
        strSkillParamsName = FileName.STR_JSON_CHARSR_ACTIVE_03_PARAMS;
        PLUS_VAL = 10f;
        PLUS_MAG = 10f;
        PLUS_TARGET_COUNT = 0f;
        PLUS_ATTACK_COUNT = 0f;
        SetType();
        LevelUpValue();
        InitParams();
        LoadEffect();
    }
    public override void SetType()
    {
        base.SetType();
        skillType = "ACTIVE";
        enumSkillType = SkillType.ACTIVE;
    }
    public override void SetDefault()
    {//액티브스킬에 다시 복붙
        fCharToUse = 2;
        fSkillLevel = 1;
        fId = 211;
        strName = "Act1";
        strDiscription = "ok";
        strIconName = "CharSrActive03.png";
        strEffectPath = FolderPath.PREFABS_ACTIVE_EFFECT;
        strEffectName = FileName.STR_CHA_SR_ACTIVE_03_EFFECT;
        fSkillExp = 0;
        fSkillRequireExp = 100;
        fUnlockLevel = 1;
        fUnlockHidenLevel = 20;
        fCoolTime = 30;
        fDuration = 1;
        fSkillCoolReduce = 1;
        fBuffDuration = 10;
        fValue = 10;
        fHidenValue = 10;
        fMagnification = 10;
        bisUnlockSkill = false;
        bisUnlockHiden = false;
        bisCanUse = false;
        bisActtivate = false;
    }
    public override void CharaterStatUp(ref float stat1, ref float stat2)
    {
        base.CharaterStatUp(ref ChaStat.fCriticalPer, ref ChaStat.fCriticalDmg);
    }


    public override void SkillHidenUnlock()
    {
        base.SkillHidenUnlock();
    }
}
