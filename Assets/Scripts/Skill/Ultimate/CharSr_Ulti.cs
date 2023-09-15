using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Params;

public class CharSr_Ulti : AttackType
{
    private void OnDisable()
    {
        SkillFolderPath = FolderPath.PARAMS_ULTIMATE_SKILL;
        SkillParamsPath = FileName.STR_JSON_CHARSR_ULTIMATE_PARAMS;
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
        skillType = "ULTIMATE";
        enumSkillType = SkillType.ULTIMATE;
    }
    public override void SetDefault()
    {//액티브스킬에 다시 복붙

        fSkillLevel = 1;
        fId = 303;
        strName = "Act1";
        strDiscription = "ok";
        //strIconpath=
        strEffectPath = FolderPath.PREFABS_ULTIMATE_EFFECT;
        strEffectName = FileName.STR_CHA_SR_ULTIMATE_EFFECT;
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
    
}
