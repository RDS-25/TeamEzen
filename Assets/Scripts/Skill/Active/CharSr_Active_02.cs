using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Params;

public class CharSr_Active_02 : AttackType
{
    private void OnDisable()
    {
        myBulletFactory(GameManager.instance.objectFactory.CharSr_Active_02_Bullet_Factory);
        strSkillFolderPath = FolderPath.PARAMS_ACTIVE_SKILL;
        strSkillParamsName = FileName.STR_JSON_CHARSR_ACTIVE_02_PARAMS;
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
        fCharToUse = 2;
        fSkillLevel = 1;
        fId = 210;
        strName = "SrActive02";
        strDiscription = "ok";
        strIconName = "CharSrActive02.png";
        strEffectPath = FolderPath.PREFABS_ACTIVE_BULLET;
        strEffectName = PrefabName.STR_CHA_SR_ACTIVE_02_BULLET;
        fSkillExp = 0f;
        fSkillRequireExp = 100f;
        fUnlockLevel = 1f;
        fUnlockHidenLevel = 20f;
        fTimer = 0f;
        fCoolTime = 1f;
        fDuration = 1f;
        fSkillCoolReduce = 0f;
        fRange = 50f;
        fMaxRange = 18f;
        fValue = 22f;
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
    


    public override void SkillHidenUnlock()
    {
        base.SkillHidenUnlock();
    }
}
