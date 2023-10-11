using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Params;

public class CharHg_Active_01 : AttackType
{
    private void OnDisable()
    {
        myBulletFactory(GameManager.instance.objectFactory.CharHg_Active_01_Bullet_Factory);
        strSkillFolderPath = FolderPath.PARAMS_ACTIVE_SKILL;
        strSkillParamsName = FileName.STR_JSON_CHARHG_ACTIVE_01_PARAMS;
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
    {//��Ƽ�꽺ų�� �ٽ� ����
        fCharToUse = 3f;
        fSkillLevel = 1f;
        fId = 203f;
        strName = "HgActive01";
        strDiscription = "ok";
        strIconName = "CharHgActive01.png";
        strEffectPath = FolderPath.PREFABS_ACTIVE_BULLET;
        strEffectName = PrefabName.STR_CHA_HG_ACTIVE_01_BULLET;
        fSkillExp = 0f;
        fSkillRequireExp = 100f;
        fUnlockLevel = 1f;
        fUnlockHidenLevel = 20f;
        fTimer = 0f;
        fCoolTime = 1f;
        fDuration = 1f;
        fSkillCoolReduce = 0f;
        fRange = 12f;
        fMaxRange = 20f;
        fValue = 10f;
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
