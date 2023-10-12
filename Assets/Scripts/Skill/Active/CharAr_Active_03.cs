using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Params;

public class CharAr_Active_03 : BuffType
{
    private void OnDisable()
    {
        skillinfo = new CharAr_Active_01();
        
        strSkillFolderPath = FolderPath.PARAMS_ACTIVE_SKILL;
        strSkillParamsName = FileName.STR_JSON_CHARAR_ACTIVE_03_PARAMS;
        PLUS_VAL = 10f;
        PLUS_MAG = 10f;
        PLUS_TARGET_COUNT = 0f;
        PLUS_ATTACK_COUNT = 0f;
        SetType();
        LevelUpValue();
        InitParams();
     //LoadEffect();
    }
    private void Start()
    {
        stat1 = ChaStat.fCriticalDmg;
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
        fCharToUse = 5f;
        fSkillLevel = 1f;
        fId = 202f;
        strName = "ArActive03";
        strDiscription = "ok";
        strIconName = "CharArActive03.png";
        strEffectPath = FolderPath.PREFABS_ACTIVE_EFFECT;
        strEffectName = PrefabName.STR_CHA_AR_ACTIVE_03_BULLET;
        fSkillExp = 0f;
        fSkillRequireExp = 100f;
        fUnlockLevel = 1f;
        fUnlockHidenLevel = 20f;
        fCoolTime = 30f;
        fDuration = 1f;
        fSkillCoolReduce = 1f;
        fBuffDuration = 10f; 
        fValue = 1.2f;
        fHidenValue = 1.2f;
        fMagnification = 10f;        
        bisUnlockSkill = false;
        bisUnlockHiden = false;
        bisCanUse = false;
        bisActtivate = false;
    }
    
}
