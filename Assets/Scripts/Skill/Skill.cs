using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;
using System;


public class Skill: SkillParams
{//1.��ų �ر� 2.��ų �ߵ� 3.��ȭ 4.ȿ���Ÿ� 5.���ӽð�
    //��ų ����/�Ÿ�/�ð�
    protected string SkillPath;//�������
    protected string SkillParamsPath;//���ϰ��
    protected Dictionary<string, string> SkillStat;//��ųʸ� ���

    //��ų���� �����Ȱ� ���ֱ�
    protected float PLUS_VAL = 10f;
    protected float PLUS_MAG = 10f;
    protected float PLUS_TARGET_COUNT = 0f;
    protected float PLUS_ATTACK_COUNT = 0f;
    protected Stat ChaStat;


    public void SkillActivationInit(ref Stat activeObjectStat)//��ų �����Ҷ� �ҷ��޶�� ���ϱ�
    {
        ChaStat = activeObjectStat;
    }
    protected void LevelUpValue()
    {
        plusval = PLUS_VAL;
        pulsmag = PLUS_MAG;
        plustargetcount = PLUS_TARGET_COUNT;
        plusattackcount = PLUS_ATTACK_COUNT;
    }
    public virtual void InitParams()
    {//���������� ������ LoadParams() ������ SetParams()
        if (GameManager.instance.CheckExist(SkillParamsPath, SkillParamsPath))
        {
            LoadParams();
        }
        else
        {
            SetDefault();
            SaveParams();
        }
    }
    public virtual void SetType()
    {

    }
    public virtual void SetDefault()//ù ��ų�Ķ���� �Է�
    {

    }

    protected void SaveParams()//��ų �Ķ���� ����

    {
        //��ųŸ�� �ֱ�, �ȵ� �� �پ���
        Dictionary<string, string> dictTemp = new Dictionary<string, string>();
        dictTemp.Add("fSkillLevel", fSkillLevel.ToString());
        dictTemp.Add("fId", fId.ToString());
        dictTemp.Add("skillDetail", skillDetail);
        dictTemp.Add("strName", strName);
        dictTemp.Add("strDiscription", strDiscription);
        dictTemp.Add("strIconpath", strIconpath);
        dictTemp.Add("strEffectPath", strEffectPath);
        dictTemp.Add("fSkillExp", fSkillExp.ToString());
        dictTemp.Add("fSkillRequireExp", fSkillRequireExp.ToString());
        dictTemp.Add("fUnlockLevel", fUnlockLevel.ToString());
        dictTemp.Add("fUnlockHidenLevel", fUnlockHidenLevel.ToString());
        dictTemp.Add("fTimer", fTimer.ToString());
        dictTemp.Add("fCoolTime", fCoolTime.ToString());
        dictTemp.Add("fDuration", fDuration.ToString());
        dictTemp.Add("fSkillCoolReduce", fSkillCoolReduce.ToString());
        dictTemp.Add("fRange", fRange.ToString());
        dictTemp.Add("fMaxRange", fMaxRange.ToString());
        dictTemp.Add("fValue", fValue.ToString());
        dictTemp.Add("fHidenValue", fHidenValue.ToString());
        dictTemp.Add("fMagnification", fMagnification.ToString());
        dictTemp.Add("fTargetCount", fTargetCount.ToString());
        dictTemp.Add("fAttackCount", fAttackCount.ToString());
        dictTemp.Add("fBulletCount", fBulletCount.ToString());
        dictTemp.Add("bisUnlockSkill", bisUnlockSkill.ToString());
        dictTemp.Add("bisUnlockHiden", bisUnlockHiden.ToString());
        dictTemp.Add("bisCanUse", bisCanUse.ToString());
        dictTemp.Add("bisActtivate", bisActtivate.ToString());
        // ����Ʈ�̸�
        GameManager.instance.DataWrite(SkillPath + SkillParamsPath, dictTemp);
    }

    public virtual void LoadParams()
    {
        Dictionary<string, string> dictTemp = GameManager.instance.DataRead(SkillPath);
        fSkillLevel = float.Parse(dictTemp["fSkillLevel"]);
        fId = float.Parse(dictTemp["fId"]);
        strName = dictTemp["strName"];
        enumSkillDetail = (SkillDetailType)Enum.Parse(typeof(SkillDetailType), dictTemp["skillDetail"]);

        fSkillExp = float.Parse(dictTemp["fSkillExp"]);
        fSkillRequireExp = float.Parse(dictTemp["fSkillRequireExp"]);
        strDiscription = dictTemp["strDiscription"];
        fUnlockLevel = float.Parse(dictTemp["fUnlockLevel"]);
        fUnlockHidenLevel = float.Parse(dictTemp["fUnlockHidenLevel"]);
        fTimer = float.Parse(dictTemp["fTimer"]);
        fCoolTime = float.Parse(dictTemp["fCoolTime"]);
        fDuration = float.Parse(dictTemp["fDuration"]);
        fSkillCoolReduce = float.Parse(dictTemp["fSkillCoolReduce"]);
        fRange = float.Parse(dictTemp["fRange"]);
        fValue = float.Parse(dictTemp["fValue"]);
        fHidenValue = float.Parse(dictTemp["fHidenValue"]);
        fMagnification = float.Parse(dictTemp["fMagnification"]);
        fTargetCount = float.Parse(dictTemp["fTargetCount"]);
        fAttackCount = float.Parse(dictTemp["fAttackCount"]);
        fBuffDuration = float.Parse(dictTemp["fBulletCount"]);
        bisUnlockSkill = Convert.ToBoolean(dictTemp["bisUnlockSkill"]);
        bisUnlockHiden = Convert.ToBoolean(dictTemp["bisUnlockHiden"]);
        bisCanUse = Convert.ToBoolean(dictTemp["bisCanUse"]);
        bisActtivate = Convert.ToBoolean(dictTemp["bisActtivate"]);
    }
    

    public virtual void SkillUnlock()//��ų �ر�
    {
        if (fSkillLevel > fUnlockLevel)
        {
            bisUnlockSkill = true;
            SkillStat.Add("bisUnlockSkill", true.ToString());
        }
        SaveParams();
        //�߰����
    }
    public virtual void SkillHidenUnlock()
    {
        if (ChaStat.fLevel > fUnlockHidenLevel)
        {
            bisUnlockHiden = true;
            SkillStat.Add("bisUnlockHiden", true.ToString());
        }
        SaveParams();
        //�߰����

    }
    public virtual void SkillTriger()//��ų �ߵ�(�ܹ���)
    {//�ִϸ��̼�, ȿ����, ����ü�߻�, ������ ������ֱ�, 
                   
        
                       
    }
    
    public virtual void SkillExpUp(float exp)
    {
        fSkillExp += exp;
        if (fSkillExp >= fSkillRequireExp)
        {
            SkillLevelUp();
            fSkillExp -= fSkillRequireExp;
            SkillStat.Add("fSkillExp", fSkillExp.ToString());
        }
        else
            SkillStat.Add("fSkillExp", fSkillExp.ToString());
    }
    public virtual void SkillLevelUp()//��ų ������(��ȭ)
    {//����� ��ųʸ��� �ٽ� �����ֱ�
        if (fSkillLevel % 5 == 0)
        {
            if (fSkillLevel % 5 == 0)
                checkLevel = 1f;
            else
                checkLevel = 0f;

            plusval = PLUS_VAL + (checkLevel * 10f);
            pulsmag = PLUS_MAG + (checkLevel * 10f);

        }
        fSkillLevel++;//����
        fValue += plusval;//�⺻�����
        fMagnification += pulsmag;//�������·�
        fSkillRequireExp += fSkillLevel * 10;//�䱸����ġ ����

        SaveParams();
        SkillHidenUnlock();
    }
    public virtual IEnumerator SkillCoolDown()
    {
        yield return new WaitForSeconds(fCoolTime);
        bisCanUse = true;
        bisActtivate = false;
    }



}
/*public virtual void ActSkill(float characterstat, float value, float magnification,
       float attackcount, float tartgetcount, float fduration)//��ų�۵�(�������)
{//��ų�⺻ ��, ����, Ÿ��Ƚ��, Ÿ�ټ�, ���ӽð�
    float skilldamage = value + characterstat * magnification;
public virtual void ActSkill(float characterstat, float value, float magnification,
       float attackcount, float tartgetcount, float fduration)//��ų�۵�(�������)
        //���� ���� �ʿ� ���� ����Ʈ������
    {//��ų�⺻ ��, ����, Ÿ��Ƚ��, Ÿ�ټ�, ���ӽð�
        skilParams.isAtctivate = false;
    }
    public virtual void ActSkill(float characterstat ,float value, float magnification,
        float fbuffduration)//��ų�۵�(������)
    {//ĳ���� ����, �⺻ ��ų��, ����, ���� ���ӽð�
        skilParams.fTimer = 0;        
        float buffstat = characterstat + value + characterstat * magnification;
        if (skilParams.isAtctivate == true)
        {

        }
        
        if (skilParams.fTimer >= fbuffduration)
        {
            buffstat = characterstat;
            skilParams.isAtctivate = false;
        }   
    }
public virtual void SkillCoolDown()
    {//��Ÿ�ӵ��� ���Ұ� ��Ÿ�� ����� ��밡��
        skilParams.fTimer += Time.deltaTime;
        if (skilParams.fTimer >= skilParams.fCoolTime)
            skilParams.canUse = true;
    }
}*/