using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ex_1Skill : DamageSkill
{//파라미터는 스크립터블 오브젝트에서 가져오기???해결
    public Skilldatas scriptabledata;//스크립터블오브젝트 인스펙터창

    Dictionary<string, string> dictSkillStat;//딕셔너리 사용
    
    void Start()
    {
       
    }
    public override void InitParams()
    {//데이터파일 있으면 LoadParams() 없으면 SetParams()

    }
    public override void SetParams( )
    {

        if(scriptabledata.Skills[0].fId == 1)
        {
            dictSkillStat = new Dictionary<string, string>();
            //scriptabledata.Skills[0].strName = "이름";//스크립터블 오브젝트에 정보 넣을때
            //scriptabledata.Skills[0].fSkillLevel = 100;
            float fId = scriptabledata.Skills[0].fId;
            dictSkillStat.Add("fId", scriptabledata.Skills[0].fId.ToString());
            string strname = scriptabledata.Skills[0].strName;//스크립터블 오브젝트에서 꺼내올때
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
    {//이펙트 나가게
        base.SkillTriger();
    }
   
    public override void SkillCoolDown()
    {
        base.SkillCoolDown();
    }
   
}
