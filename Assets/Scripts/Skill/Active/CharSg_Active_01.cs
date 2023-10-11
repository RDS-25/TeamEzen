using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Params;

public class CharSg_Active_01 : AttackType
{
    private void OnDisable()
    {
        myBulletFactory(GameManager.instance.objectFactory.CharSg_Active_01_Bullet_Factory);
        strSkillFolderPath = FolderPath.PARAMS_ACTIVE_SKILL;
        strSkillParamsName = FileName.STR_JSON_CHARSG_ACTIVE_01_PARAMS;
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
        fCharToUse = 4f;
        fSkillLevel = 1f;
        fId = 206f;
        strName = "SgActive01";
        strDiscription = "ok";
        strIconName = "CharSgActive01.png";
        strEffectPath = FolderPath.PREFABS_ACTIVE_BULLET;
        strEffectName = PrefabName.STR_CHA_SG_ACTIVE_01_BULLET;
        fSkillExp = 0f;
        fSkillRequireExp = 100f;
        fUnlockLevel = 1f;
        fUnlockHidenLevel = 20f;
        fTimer = 0f;
        fCoolTime = 1f;
        fDuration = 1f;
        fSkillCoolReduce = 0f;
        fRange = 50f;
        fMaxRange = 13f;
        fValue = 20f;
        fHidenValue = 10f;
        fMagnification = 10f;
        fTargetCount = 1f;
        fAttackCount = 1f;
        fBulletCount = 1f;
        bisUnlockSkill = false;
        bisUnlockHiden = false;
        bisCanUse = false;
        bisActtivate = false;
    }
   
}
