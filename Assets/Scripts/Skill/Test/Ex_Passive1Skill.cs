using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Ex_Passive1Skill : PassiveSkill
{
    private string _strExPassive1SkillPath;//파일경로
    string Passive1Params;//파일명
    public Skilldatas scriptabledata;
    public Charater1 Charater1;
    Dictionary<string, string> dic_Passive1SkillStat;

    public float UpStatVale;//올라간 스텟
    public float UpStatHiden;//해금된 효과로 올라간 스텟
    float HidenValue;
    public List<GameObject> EquipDatas = new List<GameObject>();

    const float PLUS_VAL = 10f;
    const float PLUS_MAG = 10f;
    const float PLUS_TARGET_COUNT = 0f;
    const float PLUS_ATTACK_COUNT = 0f;
    void Start()
    {
        //EquipDatas.Add()
        _strExPassive1SkillPath = FolderPath.PARAMS_PASSIVE_SKILL;
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
    {//스크립터블 지우고 새로 쓰기
        if (scriptabledata.Skills[1].fId == 1)
        {
            dic_Passive1SkillStat = new Dictionary<string, string>();
            fSkillLevel = scriptabledata.Skills[1].fSkillLevel;
            dic_Passive1SkillStat.Add("fSkillLevel", fSkillLevel.ToString());
            fId = scriptabledata.Skills[1].fId;
            dic_Passive1SkillStat.Add("fId",  fId.ToString());
            strName = scriptabledata.Skills[1].strName;//스크립터블 오브젝트에서 꺼내올때
            dic_Passive1SkillStat.Add("strName",  strName);
            strDiscription = scriptabledata.Skills[1].strDiscription;
            dic_Passive1SkillStat.Add("strDiscription",  strDiscription);
            fSkillExp = scriptabledata.Skills[1].fSkillExp;
            dic_Passive1SkillStat.Add("fSkillExp",  strDiscription);
            fSkillRequireExp = scriptabledata.Skills[1].fSkillRequireExp;
            dic_Passive1SkillStat.Add("fSkillRequireExp",  fSkillRequireExp.ToString());
            fUnlockLevel = scriptabledata.Skills[1].fUnlockLevel;
            dic_Passive1SkillStat.Add("fUnlockLevel",  fUnlockLevel.ToString());
            fUnlockHidenLevel = scriptabledata.Skills[1].fUnlockHidenLevel;
            dic_Passive1SkillStat.Add("fUnlockHidenLevel",  fUnlockHidenLevel.ToString());            
            //Ex_Active1Params.fBuffDuration = scriptabledata.Skills[0].fBuffDuration;
            //dictActive1SkillStat.Add("fBuffDuration", Ex_Active1Params.fBuffDuration.ToString());//버프액티브에 사용
            fValue = scriptabledata.Skills[1].fValue;
            dic_Passive1SkillStat.Add("fValue",  fValue.ToString());
            fHidenValue = scriptabledata.Skills[1].fHidenValue;
            dic_Passive1SkillStat.Add("fHidenValue",  fHidenValue.ToString());
            fMagnification = scriptabledata.Skills[1].fMagnification;
            dic_Passive1SkillStat.Add("fMagnification",  fMagnification.ToString());
            bisUnlockSkill = scriptabledata.Skills[1].bisUnlockSkill;
            dic_Passive1SkillStat.Add("bisUnlockSkill",  bisUnlockSkill.ToString());
            bisUnlockHiden = scriptabledata.Skills[1].bisUnlockHiden;
            dic_Passive1SkillStat.Add("bisUnlockHiden",  bisUnlockHiden.ToString());
            bisActtivate = scriptabledata.Skills[1].bisActtivate;
            dic_Passive1SkillStat.Add("bisActtivate",  bisActtivate.ToString());
            GameManager.instance.DataWrite(_strExPassive1SkillPath, dic_Passive1SkillStat);
        }
    }
    public override void LoadParams()
    {
        Dictionary<string, string> dicTemp      = GameManager.instance.DataRead(Passive1Params);
        fSkillLevel       = float.Parse(dicTemp["fSkillLevel"]);
        fId               = float.Parse(dicTemp["fId"]);
        strName           = dicTemp["strName"];
        strDiscription    = dicTemp["fSkillLevel"];
        fSkillExp         = float.Parse(dicTemp["fSkillExp"]);
        fSkillRequireExp  = float.Parse(dicTemp["fSkillRequireExp"]);
        fUnlockLevel      = float.Parse(dicTemp["fUnlockLevel"]);
        fUnlockHidenLevel = float.Parse(dicTemp["fUnlockHidenLevel"]);
        fValue            = float.Parse(dicTemp["fValue"]);
        fHidenValue       = float.Parse(dicTemp["fHidenValue"]);
        fMagnification    = float.Parse(dicTemp["fMagnification"]);
        bisUnlockSkill    = Convert.ToBoolean(dicTemp["bisUnlockSkill"]);
        bisUnlockHiden    = Convert.ToBoolean(dicTemp["bisUnlockHiden"]);
        bisCanUse         = Convert.ToBoolean(dicTemp["bisCanUse"]);
        bisActtivate      = Convert.ToBoolean(dicTemp["bisActtivate"]);
    }
    public override void SkillExpUp(float exp)
    {
        fSkillExp += exp;
        if (fSkillExp >=  fSkillRequireExp)
        {
            SkillLevelUp();
            fSkillExp -=  fSkillRequireExp;
            dic_Passive1SkillStat.Add("fSkillExp", fSkillExp.ToString());
        }
        else
            dic_Passive1SkillStat.Add("fSkillExp", fSkillExp.ToString());
    }
    public override void SkillLevelUp()
    {      
        
        if ( fSkillLevel%5==0)
        {
            if ( fSkillLevel % 5 == 0)
                checkLevel = 1f;
            else
                checkLevel = 0f;

            plusval = PLUS_VAL + (checkLevel * 10f);
            pulsmag = PLUS_MAG + (checkLevel * 10f);
           
        }
        fSkillLevel++;//레벨
        dic_Passive1SkillStat.Add("fSkillLevel", fSkillLevel.ToString());
        fValue += plusval;//기본대미지
        dic_Passive1SkillStat.Add("fValue",  fValue.ToString());
        fMagnification += pulsmag;//대미지상승량
        dic_Passive1SkillStat.Add("fMagnification", fMagnification.ToString());
        fSkillRequireExp +=  fSkillLevel * 10;//요구경험치 증가
        dic_Passive1SkillStat.Add("fSkillRequireExp", fSkillRequireExp.ToString());        
        GameManager.instance.DataWrite(_strExPassive1SkillPath, dic_Passive1SkillStat);//쓰기
        SkillHidenUnlock();
        SkillUnlock();
    }
    public override void SkillUnlock()
    {
        if (Charater1.Level >  fUnlockLevel)
        {
            bisUnlockSkill = true;
            dic_Passive1SkillStat.Add("bisUnlockSkill", true.ToString());
        }
        //추가기능

    }
    public override void SkillHidenUnlock()
    {
        if (Charater1.Level >  fUnlockHidenLevel)
        {
            bisUnlockHiden = true;
            dic_Passive1SkillStat.Add("bisUnlockHiden", true.ToString());
        }
        //추가기능

    }
    public void CharaterStatUp(float stat1,float stat2)
    {
        UpStatVale = stat1 *  fMagnification +  fValue;
        //올린 스텟을 캐릭파람스에 적용시켜주기
        if (bisUnlockHiden)
        {
            UpStatHiden = stat2 * HidenValue;
            //올린 스텟을 캐릭파람스에 적용시켜주기
            
        }        
        
        
    }
    
}
