using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ex_1Skill : DamageSkill
{//�Ķ���ʹ� ��ũ���ͺ� ������Ʈ���� ��������???�ذ�
    public Skilldatas scriptabledata;//��ũ���ͺ������Ʈ �ν�����â

    Dictionary<string, string> dictSkillStat;//��ųʸ� ���
    
    void Start()
    {
       
    }
    public override void InitParams()
    {//���������� ������ LoadParams() ������ SetParams()

    }
    public override void SetParams( )
    {

        if(scriptabledata.Skills[0].fId == 1)
        {
            dictSkillStat = new Dictionary<string, string>();
            //scriptabledata.Skills[0].strName = "�̸�";//��ũ���ͺ� ������Ʈ�� ���� ������
            //scriptabledata.Skills[0].fSkillLevel = 100;
            float fId = scriptabledata.Skills[0].fId;
            dictSkillStat.Add("fId", scriptabledata.Skills[0].fId.ToString());
            string strname = scriptabledata.Skills[0].strName;//��ũ���ͺ� ������Ʈ���� �����ö�
            dictSkillStat.Add("strName", scriptabledata.Skills[0].strName);
            float fskilllevel = scriptabledata.Skills[0].fSkillLevel;
            dictSkillStat.Add("fSkillLevel", scriptabledata.Skills[0].fSkillLevel.ToString());
            string strdiscription = scriptabledata.Skills[0].strDiscription;
            dictSkillStat.Add("strDiscription", scriptabledata.Skills[0].strDiscription);
            float fskillrequireexp = scriptabledata.Skills[0].fSkillRequireExp;
            dictSkillStat.Add("fSkillRequireExp", scriptabledata.Skills[0].fSkillRequireExp.ToString());
            float funlocklevel = scriptabledata.Skills[0].fUnlockHidenLevel;
            dictSkillStat.Add("fUnlockHidenLevel", scriptabledata.Skills[0].fUnlockHidenLevel.ToString());
            float ftimer = scriptabledata.Skills[0].fTimer;
            dictSkillStat.Add("fTimer", scriptabledata.Skills[0].fTimer.ToString());
            float fcooltime = scriptabledata.Skills[0].fCoolTime;
            dictSkillStat.Add("fCoolTime", scriptabledata.Skills[0].fCoolTime.ToString());
            float fduration = scriptabledata.Skills[0].fDuration;
            dictSkillStat.Add("fDuration", scriptabledata.Skills[0].fDuration.ToString());
            float fskillcoolreduce = scriptabledata.Skills[0].fSkillCoolReduce;
            dictSkillStat.Add("fSkillCoolReduce", scriptabledata.Skills[0].fSkillCoolReduce.ToString());
            float fbuffduration = scriptabledata.Skills[0].fBuffDuration;
            dictSkillStat.Add("fBuffDuration", scriptabledata.Skills[0].fBuffDuration.ToString());
            float frange = scriptabledata.Skills[0].fRange;
            dictSkillStat.Add("fRange", scriptabledata.Skills[0].fRange.ToString());
            float fvalue = scriptabledata.Skills[0].fValue;
            dictSkillStat.Add("fValue", scriptabledata.Skills[0].fValue.ToString());
            float fmagnification = scriptabledata.Skills[0].fMagnification;
            dictSkillStat.Add("fMagnification", scriptabledata.Skills[0].fMagnification.ToString());
            float ftargetcount = scriptabledata.Skills[0].fTargetCount;
            dictSkillStat.Add("fTargetCount", scriptabledata.Skills[0].fTargetCount.ToString());
            float fattackcount = scriptabledata.Skills[0].fAttackCount;
            dictSkillStat.Add("fAttackCount", scriptabledata.Skills[0].fAttackCount.ToString());
            float fbulletcount = scriptabledata.Skills[0].fBulletCount;
            dictSkillStat.Add("fBulletCount", scriptabledata.Skills[0].fBulletCount.ToString());
            bool bisunlockskill = scriptabledata.Skills[0].bisUnlockSkill;
            //dictSkillStat.Add("", scriptabledata.Skills[0].bisUnlockSkill.t)
        }

    }
    public override void LoadParams()
    {
        
    }
    public override void SkillUnLock(float CharacterLevel)
    {
        base.SkillUnLock(CharacterLevel);
    }
    public override void SkillLevelUp(float damage, float magnification, float attackcount, float targetcount)
    {
        base.SkillLevelUp(damage, magnification, attackcount, targetcount);
    }
    public override void SkillTriger()
    {//����Ʈ ������
        base.SkillTriger();
    }
   
    public override void SkillCoolDown()
    {
        base.SkillCoolDown();
    }
   
}
