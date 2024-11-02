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
     //LoadEffect();
    }
    private void Start()
    {
        /*stat1 = ChaStat.fAtk;
        stat2 = ChaStat.fDefBreak;*/
    }
    public override void SetType()
    {
        base.SetType();
        skillType = "ACTIVE";
        enumSkillType = SkillType.ACTIVE;
    }
    public override void SetDefault()
    {//액티브스킬에 다시 복붙
        fCharToUse = 2f;
        fSkillLevel = 1f;
        fId = 211f;
        strName = "SrActive03";
        strDiscription = "ok";
        strIconName = "CharSrActive03.png";
        strEffectPath = FolderPath.PREFABS_ACTIVE_EFFECT;
        strEffectName = PrefabName.STR_CHA_SR_ACTIVE_03_BULLET;
        fSkillExp = 0f;
        fSkillRequireExp = 100f;
        fUnlockLevel = 1f;
        fUnlockHidenLevel = 20f;
        fCoolTime = 30f;
        fDuration = 1f;
        fSkillCoolReduce = 1f;
        fBuffDuration = 10f;
        fValue = 10f;
        fHidenValue = 10f;
        fMagnification = 10f;
        bisUnlockSkill = false;
        bisUnlockHiden = false;
        bisCanUse = false;
        bisActtivate = false;
    }



    
}
