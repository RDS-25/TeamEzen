using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class Ex_Active1Skill : DamageSkill
{
    private string _sExActive1SkillPath;//파일경로
    public Skilldatas scriptabledata;//스크립터블오브젝트 인스펙터창
    public Charater1 Charater1;
    Dictionary<string, string> dictActive1SkillStat;//딕셔너리 사용
    SkillParameter.SkilParams Ex_Active1Params = new SkillParameter.SkilParams();
    public Action skillTirger;
    void Start()
    {
       
    }
    public override void InitParams()
    {//데이터파일 있으면 LoadParams() 없으면 SetParams()
        _sExActive1SkillPath = Application.persistentDataPath + "/ActiveSkill/";//폴더명
        if (!GameManager.instance.FolderExists(_sExActive1SkillPath))
            //GameManager.instance.CreateFolder(_sExActive1SkillPath);
            Directory.CreateDirectory(_sExActive1SkillPath);

        _sExActive1SkillPath += "exActive1.json";//파일명 추가
        if (GameManager.instance.FileExists(_sExActive1SkillPath))
            LoadParams();
        else
            SetParams();
    }
    public override void SetParams( )
    {
        
        if (scriptabledata.Skills[0].fId == 1)
        { //scriptabledata.Skills[0].strName = "이름";//스크립터블 오브젝트에 정보 넣을때
            //scriptabledata.Skills[0].fSkillLevel = 100;
            dictActive1SkillStat = new Dictionary<string, string>();
            Ex_Active1Params.fSkillLevel = scriptabledata.Skills[0].fSkillLevel;
            dictActive1SkillStat.Add("fSkillLevel", Ex_Active1Params.fSkillLevel.ToString());
            Ex_Active1Params.fId = scriptabledata.Skills[0].fId;            
            dictActive1SkillStat.Add("fId", Ex_Active1Params.fId.ToString());
            Ex_Active1Params.strName = scriptabledata.Skills[0].strName;//스크립터블 오브젝트에서 꺼내올때
            dictActive1SkillStat.Add("strName", Ex_Active1Params.strName);
            Ex_Active1Params.fSkillLevel = scriptabledata.Skills[0].fSkillLevel;
            dictActive1SkillStat.Add("fSkillLevel", Ex_Active1Params.fSkillLevel.ToString());
            Ex_Active1Params.strDiscription = scriptabledata.Skills[0].strDiscription;
            dictActive1SkillStat.Add("strDiscription", Ex_Active1Params.strDiscription);
            Ex_Active1Params.fSkillRequireExp = scriptabledata.Skills[0].fSkillRequireExp;
            dictActive1SkillStat.Add("fSkillRequireExp", Ex_Active1Params.fSkillRequireExp.ToString());
            Ex_Active1Params.fUnlockLevel = scriptabledata.Skills[0].fUnlockLevel;
            dictActive1SkillStat.Add("fUnlockLevel", Ex_Active1Params.fUnlockLevel.ToString());
            Ex_Active1Params.fUnlockHidenLevel = scriptabledata.Skills[0].fUnlockHidenLevel;
            dictActive1SkillStat.Add("fUnlockHidenLevel", Ex_Active1Params.fUnlockHidenLevel.ToString());
            Ex_Active1Params.fTimer = scriptabledata.Skills[0].fTimer;
            dictActive1SkillStat.Add("fTimer", Ex_Active1Params.fTimer.ToString());
            Ex_Active1Params.fCoolTime = scriptabledata.Skills[0].fCoolTime;
            dictActive1SkillStat.Add("fCoolTime", Ex_Active1Params.fCoolTime.ToString());
            Ex_Active1Params .fDuration= scriptabledata.Skills[0].fDuration;
            dictActive1SkillStat.Add("fDuration", Ex_Active1Params.fDuration.ToString());
            Ex_Active1Params.fSkillCoolReduce = scriptabledata.Skills[0].fSkillCoolReduce;
            dictActive1SkillStat.Add("fSkillCoolReduce", Ex_Active1Params.fSkillCoolReduce.ToString());
            //Ex_Active1Params.fBuffDuration = scriptabledata.Skills[0].fBuffDuration;
            //dictActive1SkillStat.Add("fBuffDuration", Ex_Active1Params.fBuffDuration.ToString());//버프액티브에 사용
            Ex_Active1Params.fRange = scriptabledata.Skills[0].fRange;
            dictActive1SkillStat.Add("fRange", Ex_Active1Params.fRange.ToString());
            Ex_Active1Params.fValue = scriptabledata.Skills[0].fValue;
            dictActive1SkillStat.Add("fValue", Ex_Active1Params.fValue.ToString());
            Ex_Active1Params.fMagnification = scriptabledata.Skills[0].fMagnification;
            dictActive1SkillStat.Add("fMagnification", Ex_Active1Params.fMagnification.ToString());
            Ex_Active1Params.fTargetCount = scriptabledata.Skills[0].fTargetCount;
            dictActive1SkillStat.Add("fTargetCount", Ex_Active1Params.fTargetCount.ToString());
            Ex_Active1Params.fAttackCount = scriptabledata.Skills[0].fAttackCount;
            dictActive1SkillStat.Add("fAttackCount", Ex_Active1Params.fAttackCount.ToString());
            Ex_Active1Params.fBulletCount = scriptabledata.Skills[0].fBulletCount;
            dictActive1SkillStat.Add("fBulletCount", Ex_Active1Params.fBulletCount.ToString());
            Ex_Active1Params.bisUnlockSkill = scriptabledata.Skills[0].bisUnlockSkill;
            dictActive1SkillStat.Add("bisUnlockSkill", Ex_Active1Params.bisUnlockSkill.ToString());
            Ex_Active1Params.bisUnlockHiden = scriptabledata.Skills[0].bisUnlockHiden;
            dictActive1SkillStat.Add("bisUnlockHiden", Ex_Active1Params.bisUnlockHiden.ToString());
            Ex_Active1Params.bisCanUse = scriptabledata.Skills[0].bisCanUse;
            dictActive1SkillStat.Add("bisCanUse", Ex_Active1Params.bisCanUse.ToString());
            Ex_Active1Params.bisActtivate = scriptabledata.Skills[0].bisActtivate;
            dictActive1SkillStat.Add("bisActtivate", Ex_Active1Params.bisActtivate.ToString());
            GameManager.instance.DataWrite(_sExActive1SkillPath, dictActive1SkillStat);
        }
        
    }
    public override void LoadParams()
    {
        
    }
    public override void SkillExpUp(float exp)
    {
        Ex_Active1Params.fSkillExp += exp;
        if(Ex_Active1Params.fSkillExp>= Ex_Active1Params.fSkillRequireExp)
        {
            SkillLevelUp();
            Ex_Active1Params.fSkillExp -= Ex_Active1Params.fSkillRequireExp;
            dictActive1SkillStat.Add("fSkillExp", Ex_Active1Params.fSkillExp.ToString());
        }
        else
            dictActive1SkillStat.Add("fSkillExp", Ex_Active1Params.fSkillExp.ToString());
    }
    public override void SkillLevelUp()
    {
        float plusdam = 10f;
        float pulsmag = 10f;
        float plusattackcount = 0;
        float plustargetcount = 0;
        if(Ex_Active1Params.fSkillLevel==5|| Ex_Active1Params.fSkillLevel == 10)
        {
            plusdam = 20;
            pulsmag = 20;
            plusattackcount = 1;
            plustargetcount = 1;
        }
        Ex_Active1Params.fSkillLevel++;//레벨
        dictActive1SkillStat.Add("fSkillLevel", Ex_Active1Params.fSkillLevel.ToString());        
        Ex_Active1Params.fValue += plusdam;//기본대미지
        dictActive1SkillStat.Add("fSkillLevel", Ex_Active1Params.fValue.ToString());        
        Ex_Active1Params.fMagnification += pulsmag;//대미지상승량
        dictActive1SkillStat.Add("fSkillLevel", Ex_Active1Params.fMagnification.ToString());
        Ex_Active1Params.fSkillRequireExp += Ex_Active1Params.fSkillLevel * 10;//요구경험치 증가
        dictActive1SkillStat.Add("fSkillLevel", Ex_Active1Params.fSkillRequireExp.ToString());
        Ex_Active1Params.fAttackCount += plusattackcount;//타격횟수 증가
        dictActive1SkillStat.Add("fSkillLevel", Ex_Active1Params.fAttackCount.ToString());
        Ex_Active1Params.fTargetCount += plustargetcount;//타겟수 증가
        dictActive1SkillStat.Add("fSkillLevel", Ex_Active1Params.fTargetCount.ToString());
        GameManager.instance.DataWrite(_sExActive1SkillPath, dictActive1SkillStat);//쓰기
        SkillHidenUnlock();
        SkillUnlock();
    }
    public override void SkillUnlock()
    {
        if (Charater1.Level > Ex_Active1Params.fUnlockLevel)
        {
            dictActive1SkillStat.Add("bisUnlockSkill", true.ToString());
        }
        //추가기능

    }
    public override void SkillHidenUnlock()
    {
        if (Charater1.Level > Ex_Active1Params.fUnlockHidenLevel)
        {
            dictActive1SkillStat.Add("bisUnlockSkill", true.ToString());
        }
        //추가기능

    }
    public override void SkillTriger()
    {//이펙트 나가게
        base.SkillTriger();
        skillTirger?.Invoke();
    }
   
    public override void SkillCoolDown()
    {
        Ex_Active1Params.fTimer += Time.deltaTime;
        if (Ex_Active1Params.fTimer >= Ex_Active1Params.fCoolTime)
            Ex_Active1Params.bisCanUse = true;
    }
   
}
