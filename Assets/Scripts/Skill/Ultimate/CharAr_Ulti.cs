using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Params;

public class CharAr_Ulti : AttackType
{
    //스킬레벨업 변수들 스킬마다 써주기  


    private void OnDisable()
    {
        strSkillFolderPath = FolderPath.PARAMS_ULTIMATE_SKILL;
        strSkillParamsName = FileName.STR_JSON_CHARAR_ULTIMATE_PARAMS;
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
        fId = 300;
        strName = "Act1";
        strDiscription = "ok";
        strIconName = "CharArUlti.png";
        strEffectPath = FolderPath.PREFABS_ULTIMATE_EFFECT;
        strEffectName = FileName.STR_CHA_AR_ULTIMATE_EFFECT;
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
