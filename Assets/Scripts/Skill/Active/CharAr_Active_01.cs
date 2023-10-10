using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Params;

public class CharAr_Active_01 : AttackType
{
    //스킬레벨업 변수들 스킬마다 써주기  
    //이펙트를 경로타고 넣기
    //디저블로 스타트를
    private void OnDisable()
    {
        myBulletFactory(GameManager.instance.objectFactory.CharAr_Active_01_Bullet_Factory);        
        strSkillFolderPath = FolderPath.PARAMS_ACTIVE_SKILL;
        strSkillParamsName = FileName.STR_JSON_CHARAR_ACTIVE_01_PARAMS;
        PLUS_VAL = 10f;
        PLUS_MAG = 10f;
        PLUS_TARGET_COUNT = 0f;
        PLUS_ATTACK_COUNT = 0f;
        SetType();
        LevelUpValue();
        InitParams();
      //LoadEffect();
    }

    //private void OnEnable()
    //{
    //       SkillTriger();

    //   }

    //지우고 스킬 스크립트에
   

    public override void SetType()
    {
        base.SetType();
        skillType = "ACTIVE";
        enumSkillType = SkillType.ACTIVE;
    }
    public override void SetDefault()
    {
        fCharToUse = 1;
        fSkillLevel = 1;
        fId = 201;
        strName = "";
        strDiscription = "ACTIVE010150";
        strIconName = "CharArActive01.png";
        strEffectPath = FolderPath.PREFABS_ACTIVE_BULLET;
        strEffectName = PrefabName.STR_CHA_AR_ACTIVE_01_BULLET;
        fSkillExp = 0;
        fSkillRequireExp = 100;
        fUnlockLevel = 1;
        fUnlockHidenLevel = 20;
        fTimer = 0;
        fCoolTime = 1;
        fDuration = 1;
        fSkillCoolReduce = 0;
        fRange = 10;
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
    }
    public override void SkillHidenUnlock()
    {
        base.SkillHidenUnlock();
    }
}
