using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Ex_Passive2Skill : PassiveSkill
{
    private string _strExPassive2SkillPath;//파일경로
    string Passive1Params;//파일명
    public Skilldatas scriptabledata;
    public Charater1 Charater1;
    Dictionary<string, string> dic_Passive2SkillStat;
    public SkillParameter.SkilParams ExPassive2SkillParams = new SkillParameter.SkilParams();
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
        _strExPassive2SkillPath = FolderPath.PARAMS_SKILL + "/PassiveSkill/";
        Passive1Params = FileName.STR_JSON_PASSIVESKILL2_PARAS;
        InitParams();


    }
    public override void InitParams()
    {

        if (GameManager.instance.CheckExist(_strExPassive2SkillPath, Passive1Params))
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
            dic_Passive2SkillStat = new Dictionary<string, string>();
            ExPassive2SkillParams.fSkillLevel = scriptabledata.Skills[1].fSkillLevel;
            dic_Passive2SkillStat.Add("fSkillLevel", ExPassive2SkillParams.fSkillLevel.ToString());
            ExPassive2SkillParams.fId = scriptabledata.Skills[1].fId;
            dic_Passive2SkillStat.Add("fId", ExPassive2SkillParams.fId.ToString());
            ExPassive2SkillParams.strName = scriptabledata.Skills[1].strName;//스크립터블 오브젝트에서 꺼내올때
            dic_Passive2SkillStat.Add("strName", ExPassive2SkillParams.strName);
            ExPassive2SkillParams.strDiscription = scriptabledata.Skills[1].strDiscription;
            dic_Passive2SkillStat.Add("strDiscription", ExPassive2SkillParams.strDiscription);
            ExPassive2SkillParams.fSkillExp = scriptabledata.Skills[1].fSkillExp;
            dic_Passive2SkillStat.Add("fSkillExp", ExPassive2SkillParams.strDiscription);
            ExPassive2SkillParams.fSkillRequireExp = scriptabledata.Skills[1].fSkillRequireExp;
            dic_Passive2SkillStat.Add("fSkillRequireExp", ExPassive2SkillParams.fSkillRequireExp.ToString());
            ExPassive2SkillParams.fUnlockLevel = scriptabledata.Skills[1].fUnlockLevel;
            dic_Passive2SkillStat.Add("fUnlockLevel", ExPassive2SkillParams.fUnlockLevel.ToString());
            ExPassive2SkillParams.fUnlockHidenLevel = scriptabledata.Skills[1].fUnlockHidenLevel;
            dic_Passive2SkillStat.Add("fUnlockHidenLevel", ExPassive2SkillParams.fUnlockHidenLevel.ToString());
            //Ex_Active1Params.fBuffDuration = scriptabledata.Skills[0].fBuffDuration;
            //dictActive1SkillStat.Add("fBuffDuration", Ex_Active1Params.fBuffDuration.ToString());//버프액티브에 사용
            ExPassive2SkillParams.fValue = scriptabledata.Skills[1].fValue;
            dic_Passive2SkillStat.Add("fValue", ExPassive2SkillParams.fValue.ToString());
            ExPassive2SkillParams.fHidenValue = scriptabledata.Skills[1].fHidenValue;
            dic_Passive2SkillStat.Add("fHidenValue", ExPassive2SkillParams.fHidenValue.ToString());
            ExPassive2SkillParams.fMagnification = scriptabledata.Skills[1].fMagnification;
            dic_Passive2SkillStat.Add("fMagnification", ExPassive2SkillParams.fMagnification.ToString());
            ExPassive2SkillParams.bisUnlockSkill = scriptabledata.Skills[1].bisUnlockSkill;
            dic_Passive2SkillStat.Add("bisUnlockSkill", ExPassive2SkillParams.bisUnlockSkill.ToString());
            ExPassive2SkillParams.bisUnlockHiden = scriptabledata.Skills[1].bisUnlockHiden;
            dic_Passive2SkillStat.Add("bisUnlockHiden", ExPassive2SkillParams.bisUnlockHiden.ToString());
            ExPassive2SkillParams.bisActtivate = scriptabledata.Skills[1].bisActtivate;
            dic_Passive2SkillStat.Add("bisActtivate", ExPassive2SkillParams.bisActtivate.ToString());
            GameManager.instance.DataWrite(_strExPassive2SkillPath, dic_Passive2SkillStat);
        }
    }
    public override void LoadParams()
    {
        Dictionary<string, string> dicTemp = GameManager.instance.DataRead(Passive1Params);
        ExPassive2SkillParams.fSkillLevel = float.Parse(dicTemp["fSkillLevel"]);
        ExPassive2SkillParams.fId = float.Parse(dicTemp["fId"]);
        ExPassive2SkillParams.strName = dicTemp["strName"];
        ExPassive2SkillParams.strDiscription = dicTemp["fSkillLevel"];
        ExPassive2SkillParams.fSkillExp = float.Parse(dicTemp["fSkillExp"]);
        ExPassive2SkillParams.fSkillRequireExp = float.Parse(dicTemp["fSkillRequireExp"]);
        ExPassive2SkillParams.fUnlockLevel = float.Parse(dicTemp["fUnlockLevel"]);
        ExPassive2SkillParams.fUnlockHidenLevel = float.Parse(dicTemp["fUnlockHidenLevel"]);
        ExPassive2SkillParams.fValue = float.Parse(dicTemp["fValue"]);
        ExPassive2SkillParams.fHidenValue = float.Parse(dicTemp["fHidenValue"]);
        ExPassive2SkillParams.fMagnification = float.Parse(dicTemp["fMagnification"]);
        ExPassive2SkillParams.bisUnlockSkill = Convert.ToBoolean(dicTemp["bisUnlockSkill"]);
        ExPassive2SkillParams.bisUnlockHiden = Convert.ToBoolean(dicTemp["bisUnlockHiden"]);
        ExPassive2SkillParams.bisCanUse = Convert.ToBoolean(dicTemp["bisCanUse"]);
        ExPassive2SkillParams.bisActtivate = Convert.ToBoolean(dicTemp["bisActtivate"]);

    }
    public override void SkillExpUp(float exp)
    {
        ExPassive2SkillParams.fSkillExp += exp;
        if (ExPassive2SkillParams.fSkillExp >= ExPassive2SkillParams.fSkillRequireExp)
        {
            SkillLevelUp();
            ExPassive2SkillParams.fSkillExp -= ExPassive2SkillParams.fSkillRequireExp;
            dic_Passive2SkillStat.Add("fSkillExp", ExPassive2SkillParams.fSkillExp.ToString());
        }
        else
            dic_Passive2SkillStat.Add("fSkillExp", ExPassive2SkillParams.fSkillExp.ToString());
    }
    public override void SkillLevelUp()
    {

        if (ExPassive2SkillParams.fSkillLevel % 5 == 0)
        {
            if (ExPassive2SkillParams.fSkillLevel % 5 == 0)
                checkLevel = 1f;
            else
                checkLevel = 0f;

            plusval = PLUS_VAL + (checkLevel * 10f);
            pulsmag = PLUS_MAG + (checkLevel * 10f);
        }
        ExPassive2SkillParams.fSkillLevel++;//레벨
        dic_Passive2SkillStat.Add("fSkillLevel", ExPassive2SkillParams.fSkillLevel.ToString());
        ExPassive2SkillParams.fValue += plusval;//기본대미지
        dic_Passive2SkillStat.Add("fValue", ExPassive2SkillParams.fValue.ToString());
        ExPassive2SkillParams.fMagnification += pulsmag;//대미지상승량
        dic_Passive2SkillStat.Add("fMagnification", ExPassive2SkillParams.fMagnification.ToString());
        ExPassive2SkillParams.fSkillRequireExp += ExPassive2SkillParams.fSkillLevel * 10;//요구경험치 증가
        dic_Passive2SkillStat.Add("fSkillRequireExp", ExPassive2SkillParams.fSkillRequireExp.ToString());
        GameManager.instance.DataWrite(_strExPassive2SkillPath, dic_Passive2SkillStat);//쓰기
        SkillHidenUnlock();
        SkillUnlock();
    }
    public override void SkillUnlock()
    {
        if (Charater1.Level > ExPassive2SkillParams.fUnlockLevel)
        {
            ExPassive2SkillParams.bisUnlockSkill = true;
            dic_Passive2SkillStat.Add("bisUnlockSkill", true.ToString());
        }
        //추가기능

    }
    public override void SkillHidenUnlock()
    {
        if (Charater1.Level > ExPassive2SkillParams.fUnlockHidenLevel)
        {
            ExPassive2SkillParams.bisUnlockHiden = true;
            dic_Passive2SkillStat.Add("bisUnlockHiden", true.ToString());
        }
        //추가기능

    }
    public void CharaterStatUp(float stat1, float stat2)
    {
        UpStatVale = stat1 * ExPassive2SkillParams.fMagnification + ExPassive2SkillParams.fValue;
        //올린 스텟을 캐릭파람스에 적용시켜주기
        if (ExPassive2SkillParams.bisUnlockHiden)
        {
            UpStatHiden = stat2 * HidenValue;
            //올린 스텟을 캐릭파람스에 적용시켜주기

        }


    }

}

