using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSkill_03 : AttackType
{
    private void OnDisable()
    {
        strSkillFolderPath = FolderPath.PARAMS_COMMON_SKILL;
        strSkillParamsName = FileName.STR_JSON_COMMON3_PARAMS;
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
    {
        fSkillLevel = 1;
        fId = 200;
        strName = "Act1";
        strDiscription = "ok";
        strIconName = "CharArActive01.png";
        strEffectPath = FolderPath.PREFABS_COMMON_EFFECT;
        strEffectName = FileName.STR_JSON_COMMON3_PARAMS;
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
