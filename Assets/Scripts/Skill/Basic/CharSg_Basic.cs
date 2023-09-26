using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Params;
public class CharSg_Basic : AttackType
{
    private void OnDisable()
    {
        strSkillFolderPath = FolderPath.PARAMS_BASIC_SKILL;
        strSkillParamsName = FileName.STR_JSON_CHARSG_BASIC_PARAMS;
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
        skillType = "BASIC";
        enumSkillType = SkillType.BASIC;
    }
    public override void SetDefault()
    {//액티브스킬에 다시 복붙

        fSkillLevel = 1;
        fId = 2;
        strName = "Act1";
        strDiscription = "ok";
        strIconName = "CharSgBasic.png";
        strEffectPath = FolderPath.PREFABS_BASIC_EFFECT;
        strEffectName = FileName.STR_CHA_SG_BASIC_EFFECT;
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
