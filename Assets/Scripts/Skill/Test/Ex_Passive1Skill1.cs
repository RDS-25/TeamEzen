using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Ex_Passive1Skill1 : PassiveSkill
{
    private string _strExPassive1SkillPath;//파일경로
    string Passive1Params;//파일명
    public Skilldatas scriptabledata;
    public Charater1 Charater1;
    Dictionary<string, string> dic_Passive1SkillStat;
    public SkillParameter.SkilParams ExPassive1SkillParams = new SkillParameter.SkilParams();
    float UpStatVale;
    float UpStatHiden;
    float HidenValue;

    void Start()
    {
        _strExPassive1SkillPath = FolderPath.PARAMS_SKILL + "/PassiveSkill/";
        Passive1Params = FileName.STR_JSON_PASSIVESKILL1_PARAS;
        InitParams();
        
    }
    public override void InitParams()
    {
        
        if(GameManager.instance.CheckExist(_strExPassive1SkillPath, Passive1Params))
        {
            LoadParams();
        }
        else
        {
            SetParams();
        }
        
    }
   public override void SetParams()
    {
        if (scriptabledata.Skills[1].fId == 1)
        {
            dic_Passive1SkillStat = new Dictionary<string, string>();
            ExPassive1SkillParams.fSkillLevel = scriptabledata.Skills[0].fSkillLevel;
            dic_Passive1SkillStat.Add("fSkillLevel", ExPassive1SkillParams.fSkillLevel.ToString());
            ExPassive1SkillParams.fId = scriptabledata.Skills[0].fId;
            dic_Passive1SkillStat.Add("fId", ExPassive1SkillParams.fId.ToString());
            ExPassive1SkillParams.strName = scriptabledata.Skills[0].strName;//스크립터블 오브젝트에서 꺼내올때
            dic_Passive1SkillStat.Add("strName", ExPassive1SkillParams.strName);
            ExPassive1SkillParams.strDiscription = scriptabledata.Skills[0].strDiscription;
            dic_Passive1SkillStat.Add("strDiscription", ExPassive1SkillParams.strDiscription);
            ExPassive1SkillParams.fSkillExp = scriptabledata.Skills[0].fSkillExp;
            dic_Passive1SkillStat.Add("fSkillExp", ExPassive1SkillParams.strDiscription);
            ExPassive1SkillParams.fSkillRequireExp = scriptabledata.Skills[0].fSkillRequireExp;
            dic_Passive1SkillStat.Add("fSkillRequireExp", ExPassive1SkillParams.fSkillRequireExp.ToString());
            ExPassive1SkillParams.fUnlockLevel = scriptabledata.Skills[0].fUnlockLevel;
            dic_Passive1SkillStat.Add("fUnlockLevel", ExPassive1SkillParams.fUnlockLevel.ToString());
            ExPassive1SkillParams.fUnlockHidenLevel = scriptabledata.Skills[0].fUnlockHidenLevel;
            dic_Passive1SkillStat.Add("fUnlockHidenLevel", ExPassive1SkillParams.fUnlockHidenLevel.ToString());            
            //Ex_Active1Params.fBuffDuration = scriptabledata.Skills[0].fBuffDuration;
            //dictActive1SkillStat.Add("fBuffDuration", Ex_Active1Params.fBuffDuration.ToString());//버프액티브에 사용
            ExPassive1SkillParams.fValue = scriptabledata.Skills[0].fValue;
            dic_Passive1SkillStat.Add("fValue", ExPassive1SkillParams.fValue.ToString());
            ExPassive1SkillParams.fMagnification = scriptabledata.Skills[0].fMagnification;
            dic_Passive1SkillStat.Add("fMagnification", ExPassive1SkillParams.fMagnification.ToString());
            ExPassive1SkillParams.bisUnlockSkill = scriptabledata.Skills[0].bisUnlockSkill;
            dic_Passive1SkillStat.Add("bisUnlockSkill", ExPassive1SkillParams.bisUnlockSkill.ToString());
            ExPassive1SkillParams.bisUnlockHiden = scriptabledata.Skills[0].bisUnlockHiden;
            dic_Passive1SkillStat.Add("bisUnlockHiden", ExPassive1SkillParams.bisUnlockHiden.ToString());
            ExPassive1SkillParams.bisActtivate = scriptabledata.Skills[0].bisActtivate;
            dic_Passive1SkillStat.Add("bisActtivate", ExPassive1SkillParams.bisActtivate.ToString());
            GameManager.instance.DataWrite(_strExPassive1SkillPath, dic_Passive1SkillStat);
        }
    }
    public override void LoadParams()
    {
        Dictionary<string, string> dicTemp      = GameManager.instance.DataRead(Passive1Params);
        ExPassive1SkillParams.fSkillLevel       = float.Parse(dicTemp["fSkillLevel"]);
        ExPassive1SkillParams.fId               = float.Parse(dicTemp["fId"]);
        ExPassive1SkillParams.strName           = dicTemp["strName"];
        ExPassive1SkillParams.strDiscription    = dicTemp["fSkillLevel"];
        ExPassive1SkillParams.fSkillExp         = float.Parse(dicTemp["fSkillExp"]);
        ExPassive1SkillParams.fSkillRequireExp  = float.Parse(dicTemp["fSkillRequireExp"]);
        ExPassive1SkillParams.fUnlockLevel      = float.Parse(dicTemp["fUnlockLevel"]);
        ExPassive1SkillParams.fUnlockHidenLevel = float.Parse(dicTemp["fUnlockHidenLevel"]);
        ExPassive1SkillParams.fValue            = float.Parse(dicTemp["fValue"]);
        ExPassive1SkillParams.fMagnification    = float.Parse(dicTemp["fMagnification"]);
        ExPassive1SkillParams.bisUnlockSkill    = Convert.ToBoolean(dicTemp["bisUnlockSkill"]);
        ExPassive1SkillParams.bisUnlockHiden    = Convert.ToBoolean(dicTemp["bisUnlockHiden"]);
        ExPassive1SkillParams.bisCanUse         = Convert.ToBoolean(dicTemp["bisCanUse"]);
        ExPassive1SkillParams.bisActtivate      = Convert.ToBoolean(dicTemp["bisActtivate"]);

    }
    public override void SkillExpUp(float exp)
    {
        ExPassive1SkillParams.fSkillExp += exp;
        if (ExPassive1SkillParams.fSkillExp >= ExPassive1SkillParams.fSkillRequireExp)
        {
            SkillLevelUp();
            ExPassive1SkillParams.fSkillExp -= ExPassive1SkillParams.fSkillRequireExp;
            dic_Passive1SkillStat.Add("fSkillExp", ExPassive1SkillParams.fSkillExp.ToString());
        }
        else
            dic_Passive1SkillStat.Add("fSkillExp", ExPassive1SkillParams.fSkillExp.ToString());
    }
    public override void SkillLevelUp()
    {
        float plusval = 10f;
        float pulsmag = 10f;
        
        if (ExPassive1SkillParams.fSkillLevel == 5 || ExPassive1SkillParams.fSkillLevel == 10)
        {
            plusval = 20;
            pulsmag = 20;           
        }
        ExPassive1SkillParams.fSkillLevel++;//레벨
        dic_Passive1SkillStat.Add("fSkillLevel", ExPassive1SkillParams.fSkillLevel.ToString());
        ExPassive1SkillParams.fValue += plusval;//기본대미지
        dic_Passive1SkillStat.Add("fValue", ExPassive1SkillParams.fValue.ToString());
        ExPassive1SkillParams.fMagnification += pulsmag;//대미지상승량
        dic_Passive1SkillStat.Add("fMagnification", ExPassive1SkillParams.fMagnification.ToString());
        ExPassive1SkillParams.fSkillRequireExp += ExPassive1SkillParams.fSkillLevel * 10;//요구경험치 증가
        dic_Passive1SkillStat.Add("fSkillRequireExp", ExPassive1SkillParams.fSkillRequireExp.ToString());        
        GameManager.instance.DataWrite(_strExPassive1SkillPath, dic_Passive1SkillStat);//쓰기
        SkillHidenUnlock();
        SkillUnlock();
    }
    public override void SkillUnlock()
    {
        if (Charater1.Level > ExPassive1SkillParams.fUnlockLevel)
        {
            ExPassive1SkillParams.bisUnlockSkill = true;
            dic_Passive1SkillStat.Add("bisUnlockSkill", true.ToString());
        }
        //추가기능

    }
    public override void SkillHidenUnlock()
    {
        if (Charater1.Level > ExPassive1SkillParams.fUnlockHidenLevel)
        {
            ExPassive1SkillParams.bisUnlockHiden = true;
            dic_Passive1SkillStat.Add("bisUnlockHiden", true.ToString());
        }
        //추가기능

    }
    public float CharaterStatUp(float stat1,float stat2)
    {
        if (ExPassive1SkillParams.bisUnlockHiden)
        {
            UpStatHiden = stat2 * HidenValue;
            return UpStatHiden;
        }
        UpStatVale = stat1 * ExPassive1SkillParams.fMagnification+ ExPassive1SkillParams.fValue;
        return UpStatVale;
        
    }
    void Update()
    {
        
    }
}
