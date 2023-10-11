using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Params;

public class CharAr_Basic : AttackType
{
    private void OnDisable()
    {
        myBulletFactory(GameManager.instance.objectFactory.Char_Basic_Bullet_Factory);                
        strSkillFolderPath = FolderPath.PARAMS_BASIC_SKILL;
        strSkillParamsName = FileName.STR_JSON_CHAR_BASIC_PARAMS;
        PLUS_VAL = 10f;
        PLUS_MAG = 10f;
        PLUS_TARGET_COUNT = 0f;
        PLUS_ATTACK_COUNT = 0f;
        SetType();
        LevelUpValue();
        InitParams();
     //LoadEffect();
    }
    // 지우고 skill 스크
    

    public override void SetType()
    {
        base.SetType();
        skillType = "BASIC";
        enumSkillType = SkillType.BASIC;
    }
    public override void SetDefault()
    {//액티브스킬에 다시 복붙

        fSkillLevel = 1;
        fId = 0;
        fCharToUse = 1;//??
        strName = "Act1";
        strDiscription = "ok";
        strIconName = "CharArBasic.png";
        strEffectPath = FolderPath.PREFABS_BASIC_BULLET;
        strEffectName = PrefabName.STR_CHA_BASIC_BULLET;
        fSkillExp = 0;
        fSkillRequireExp = 100;
        fUnlockLevel = 1;
        fUnlockHidenLevel = 20;
        fTimer = 0;
        fCoolTime = 1;
        fDuration = 1;
        fSkillCoolReduce = 0;
        fRange = 15;
        fMaxRange = 20;
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
        fCharToUse = 1;
    }
    
}
