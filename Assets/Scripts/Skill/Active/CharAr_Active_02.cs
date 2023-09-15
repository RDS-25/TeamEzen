using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Params;

public class CharAr_Active_02 : AttackType
{
    //��ų������ ������ ��ų���� ���ֱ�  

    private void OnDisable()
    {
        strSkillFolderPath = FolderPath.PARAMS_ACTIVE_SKILL;
        strSkillParamsName = FileName.STR_JSON_CHARAR_ACTIVE_02_PARAMS;
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
    {//��Ƽ�꽺ų�� �ٽ� ����

        fSkillLevel = 1;
        fId = 201;
        strName = "Act1";
        strDiscription = "ok";
        strIconName = "CharArActive02.png";
        strEffectPath = FolderPath.PREFABS_ACTIVE_EFFECT;
        strEffectName = FileName.STR_CHA_AR_ACTIVE_02_EFFECT;
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
