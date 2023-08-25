using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Ex_Passive1Skill : PassiveSkill
{
    public Skilldatas scriptabledata;//��ũ���ͺ������Ʈ �ν�����â
    public Charater1 Charater1;
    private string _strExPassive1SkillPath;//���ϰ��
    Dictionary<string, string> dictPassive1SkillStat;
    SkillParameter.SkilParams Ex_Passive1Params = new SkillParameter.SkilParams();
    public override void InitParams()
    {
        
    }
    public override void SetParams()
    {
        if (scriptabledata.Skills[1].fId == 2)
        {
            dictPassive1SkillStat = new Dictionary<string, string>();
            Ex_Passive1Params.fSkillLevel = scriptabledata.Skills[1].fSkillLevel;//��ũ���ͺ��� ��������
            dictPassive1SkillStat.Add("fSkillLevel", Ex_Passive1Params.fSkillLevel.ToString());
            Ex_Passive1Params.fId = scriptabledata.Skills[1].fId;
            dictPassive1SkillStat.Add("fId", Ex_Passive1Params.fId.ToString());
            Ex_Passive1Params.strName = scriptabledata.Skills[1].strName;
            dictPassive1SkillStat.Add("strName", Ex_Passive1Params.strName);
            Ex_Passive1Params.fSkillLevel = scriptabledata.Skills[1].fSkillLevel;
            dictPassive1SkillStat.Add("fSkillLevel", Ex_Passive1Params.fSkillLevel.ToString());
            Ex_Passive1Params.strDiscription = scriptabledata.Skills[1].strDiscription;
            dictPassive1SkillStat.Add("strDiscription", Ex_Passive1Params.strDiscription);
            Ex_Passive1Params.fSkillRequireExp = scriptabledata.Skills[1].fSkillRequireExp;
            dictPassive1SkillStat.Add("fSkillRequireExp", Ex_Passive1Params.fSkillRequireExp.ToString());
            Ex_Passive1Params.fUnlockLevel = scriptabledata.Skills[1].fUnlockLevel;
            dictPassive1SkillStat.Add("fUnlockLevel", Ex_Passive1Params.fUnlockLevel.ToString());
            Ex_Passive1Params.fUnlockHidenLevel = scriptabledata.Skills[1].fUnlockHidenLevel;
            dictPassive1SkillStat.Add("fUnlockHidenLevel", Ex_Passive1Params.fUnlockHidenLevel.ToString());
            Ex_Passive1Params.fValue = scriptabledata.Skills[1].fValue;
            dictPassive1SkillStat.Add("fValue", Ex_Passive1Params.fValue.ToString());
            Ex_Passive1Params.bisActtivate = scriptabledata.Skills[0].bisActtivate;
            dictPassive1SkillStat.Add("bisActtivate", Ex_Passive1Params.bisActtivate.ToString());
            GameManager.instance.DataWrite(_strExPassive1SkillPath, dictPassive1SkillStat);//��������
        }

    }
    public override void LoadParams()
    {
        base.LoadParams();
    }
    public override void SkillExpUp(float exp)
    {
        Ex_Passive1Params.fSkillExp += exp;
        if(Ex_Passive1Params.fSkillExp>= Ex_Passive1Params.fSkillRequireExp)
        {
            SkillLevelUp();
        }
    }
    public override void SkillLevelUp()
    {
        float plusval = 10f;
        if (Ex_Passive1Params.fSkillLevel == 5 || Ex_Passive1Params.fSkillLevel == 10)
        {
            plusval = 20f;
        }
        Ex_Passive1Params.fSkillLevel++;//����
        dictPassive1SkillStat.Add("fSkillLevel", Ex_Passive1Params.fSkillLevel.ToString());
        Ex_Passive1Params.fValue += plusval;//�⺻����
        dictPassive1SkillStat.Add("fSkillLevel", Ex_Passive1Params.fValue.ToString());
        Ex_Passive1Params.fSkillRequireExp += Ex_Passive1Params.fSkillLevel * 10;//�䱸����ġ ����
        dictPassive1SkillStat.Add("fSkillLevel", Ex_Passive1Params.fSkillRequireExp.ToString());
    }
    
    public override void SkillUnlock()
    {
        Ex_Passive1Params.bisUnlockSkill = true;
        dictPassive1SkillStat.Add("bisUnlockSkill", Ex_Passive1Params.bisUnlockSkill.ToString());
        //����
    }
    public override void SkillHidenUnlock()
    {
        Ex_Passive1Params.bisUnlockHiden = true;
        dictPassive1SkillStat.Add("bisUnlockHiden", Ex_Passive1Params.bisUnlockHiden.ToString());
        //����
    }
    public override void CheckAcitvate()
    {
        if (Ex_Passive1Params.bisActtivate == true)
        {
            OnPassive();
        }
        else
            OffPAssive();
    }
    public override void OnPassive()
    {//ĳ���� �ʵ忡 �����
     //����� ���� ��������
        Charater1.damage = Charater1.damage * (100 + Ex_Passive1Params.fValue) / 100;


    }
    public override void OffPAssive()
    {//���0
        
    }

}
