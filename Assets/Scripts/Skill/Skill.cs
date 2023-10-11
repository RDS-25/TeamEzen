using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;
using System;


public class Skill : SkillParams
{//1.��ų �ر� 2.��ų �ߵ� 3.��ȭ 4.ȿ���Ÿ� 5.���ӽð�
    //��ų ����/�Ÿ�/�ð�
    //protected string SkillFolderPath;//�������
    //protected string SkillParamsPath;//���ϰ��
    protected Dictionary<string, string> SkillStat;//��ųʸ� ���

    //��ų���� �����Ȱ� ���ֱ�
    protected float PLUS_VAL = 10f;
    protected float PLUS_MAG = 10f;
    protected float PLUS_TARGET_COUNT = 0f;
    protected float PLUS_ATTACK_COUNT = 0f;
    protected Stat ChaStat;
    public GameObject EffectPrefab;
    protected FactoryManager myFactory;

    public virtual void myBulletFactory(FactoryManager myFactoryManager)
    {
        myFactory = myFactoryManager;
    }
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
        if (GameManager.instance.CheckExist(strSkillFolderPath, strSkillParamsName))
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
        fCharToUse = -999;
        fSkillLevel = 1;
        fId = -1;
        strName = "Act1";
        strDiscription = "ok";
        strIconName = "1";
        strSkillFolderPath = FolderPath.PARAMS_ACTIVE_SKILL;
        strSkillParamsName = FileName.STR_JSON_CHARAR_ACTIVE_01_PARAMS;
        strEffectPath = FolderPath.PREFABS_ACTIVE_EFFECT;
        strEffectName = FileName.STR_CHA_AR_ACTIVE_01_EFFECT;
        fSkillExp = 0;
        fSkillRequireExp = 0;
        fUnlockLevel = 0;
        fUnlockHidenLevel = 0;
        fTimer = 0;
        fCoolTime = 0;
        fDuration = 0;
        fSkillCoolReduce = 0;
        fBuffDuration = 0;
        fRange = 0;
        fMaxRange = 0;
        fValue = 0;
        fHidenValue = 0;
        fMagnification = 0;
        fTargetCount = 1;
        fAttackCount = 1;
        fBulletCount = 1;
        fSpeed = 100;
        checkLevel = 1000;
    }
    //���丮 �Ŵ�����  �Ѿ� ��ġ ã�Ƽ�  �ֱ� 
    public virtual void ShotEffect(Vector3 Bulletpos, Quaternion firePointRotate)
    {

    }

    protected void SaveParams()//��ų �Ķ���� ����

    {
        //��ųŸ�� �ֱ�, �ȵ� �� �پ���
        Dictionary<string, string> dictTemp = new Dictionary<string, string>();
        dictTemp.Add("skillType", skillType);
        dictTemp.Add("skillDetail", skillDetail);
        dictTemp.Add("fCharToUse", fCharToUse.ToString());
        dictTemp.Add("fId", fId.ToString());
        dictTemp.Add("strName", strName);
        dictTemp.Add("fSkillLevel", fSkillLevel.ToString());
        dictTemp.Add("strDiscription", strDiscription);
        dictTemp.Add("strIconName", strIconName);
        dictTemp.Add("strSkillFolderPath", strSkillFolderPath);
        dictTemp.Add("strSkillParamsName", strSkillParamsName);
        dictTemp.Add("strEffectPath", strEffectPath);
        dictTemp.Add("strEffectName", strEffectName);
        dictTemp.Add("fSkillRequireExp", fSkillRequireExp.ToString());
        dictTemp.Add("fSkillExp", fSkillExp.ToString());
        dictTemp.Add("fUnlockLevel", fUnlockLevel.ToString());
        dictTemp.Add("fUnlockHidenLevel", fUnlockHidenLevel.ToString());
        dictTemp.Add("fTimer", fTimer.ToString());
        dictTemp.Add("fCoolTime", fCoolTime.ToString());
        dictTemp.Add("fDuration", fDuration.ToString());
        dictTemp.Add("fSkillCoolReduce", fSkillCoolReduce.ToString());
        dictTemp.Add("fBuffDuration", fBuffDuration.ToString());
        dictTemp.Add("fRange", fRange.ToString());
        dictTemp.Add("fMaxRange", fMaxRange.ToString());
        dictTemp.Add("fValue", fValue.ToString());
        dictTemp.Add("fHidenValue", fHidenValue.ToString());
        dictTemp.Add("fMagnification", fMagnification.ToString());
        dictTemp.Add("fTargetCount", fTargetCount.ToString());
        dictTemp.Add("fAttackCount", fAttackCount.ToString());
        dictTemp.Add("fBulletCount", fBulletCount.ToString());
        dictTemp.Add("fSpeed", fSpeed.ToString());
        dictTemp.Add("bisUnlockSkill", bisUnlockSkill.ToString());
        dictTemp.Add("bisCanUse", bisCanUse.ToString());
        dictTemp.Add("bisActtivate", bisActtivate.ToString());
        dictTemp.Add("bisUnlockHiden", bisUnlockHiden.ToString());
        // ����Ʈ�̸�
        GameManager.instance.DataWrite(strSkillFolderPath + strSkillParamsName, dictTemp);
    }

    public virtual void LoadParams()
    {
        Dictionary<string, string> dictTemp = GameManager.instance.DataRead(strSkillFolderPath + strSkillParamsName);
        SkillStat = GameManager.instance.DataRead(strSkillFolderPath + strSkillParamsName);

        enumSkillType = (SkillType)Enum.Parse(typeof(SkillType), dictTemp["skillType"]);
        enumSkillDetail = (SkillDetailType)Enum.Parse(typeof(SkillDetailType), dictTemp["skillDetail"]);
        skillType = dictTemp["skillType"];
        skillDetail = dictTemp["skillDetail"];
        fCharToUse = float.Parse(dictTemp["fCharToUse"]);
        fId = float.Parse(dictTemp["fId"]);
        strName = dictTemp["strName"];
        fSkillLevel = float.Parse(dictTemp["fSkillLevel"]);
        strDiscription = dictTemp["strDiscription"];
        strIconName = dictTemp["strIconName"];
        strSkillFolderPath = dictTemp["strSkillFolderPath"];
        strSkillParamsName = dictTemp["strSkillParamsName"];
        strEffectPath = dictTemp["strEffectPath"];
        strEffectName = dictTemp["strEffectName"];
        fSkillRequireExp = float.Parse(dictTemp["fSkillRequireExp"]);
        fSkillExp = float.Parse(dictTemp["fSkillExp"]);
        fUnlockLevel = float.Parse(dictTemp["fUnlockLevel"]);
        fUnlockHidenLevel = float.Parse(dictTemp["fUnlockHidenLevel"]);
        fTimer = float.Parse(dictTemp["fTimer"]);
        fCoolTime = float.Parse(dictTemp["fCoolTime"]);
        fDuration = float.Parse(dictTemp["fDuration"]);
        fSkillCoolReduce = float.Parse(dictTemp["fSkillCoolReduce"]);
        fRange = float.Parse(dictTemp["fRange"]);
        fMaxRange = float.Parse(dictTemp["fMaxRange"]);
        fValue = float.Parse(dictTemp["fValue"]);
        fHidenValue = float.Parse(dictTemp["fHidenValue"]);
        fMagnification = float.Parse(dictTemp["fMagnification"]);
        fTargetCount = float.Parse(dictTemp["fTargetCount"]);
        fAttackCount = float.Parse(dictTemp["fAttackCount"]);
        fSpeed = float.Parse(dictTemp["fSpeed"]);
        fBuffDuration = float.Parse(dictTemp["fBulletCount"]);
        bisUnlockSkill = Convert.ToBoolean(dictTemp["bisUnlockSkill"]);
        bisCanUse = Convert.ToBoolean(dictTemp["bisCanUse"]);
        bisActtivate = Convert.ToBoolean(dictTemp["bisActtivate"]);
        bisUnlockHiden = Convert.ToBoolean(dictTemp["bisUnlockHiden"]);
    }


    public virtual void SkillUnlock()//��ų �ر�
    {
        if (fSkillLevel > fUnlockLevel)
        {
            bisUnlockSkill = true;
            SkillStat["bisUnlockSkill"] = true.ToString();
            //SkillStat.Add("bisUnlockSkill", true.ToString());
        }
        SaveParams();
        //�߰����
    }
    public virtual void SkillHidenUnlock()
    {
        if (ChaStat.fLevel > fUnlockHidenLevel)
        {
            bisUnlockHiden = true;
            SkillStat["bisUnlockHiden"] = true.ToString();
            //SkillStat.Add("bisUnlockHiden", true.ToString());
        }
        SaveParams();
        //�߰����

    }
    public virtual void SkillTriger(Vector3 playerposition, Quaternion firePointRotate)//��ų �ߵ�(�ܹ���)
    {//�ִϸ��̼�, ȿ����, ����ü�߻�, ������ ������ֱ�, 
        Debug.Log("x����ü �߻� ");

        ShotEffect(playerposition, firePointRotate);
        Debug.Log("�߻�");
        if (bisCanUse == true || bisActtivate == false)
        {
            bisCanUse = false;

            bisActtivate = true;

            fTimer = 0f;

            StartCoroutine(SkillCoolDown());
        }

    }

    public virtual void SkillExpUp(float exp)
    {
        fSkillExp += exp;
        if (fSkillExp >= fSkillRequireExp)
        {
            SkillLevelUp();
            fSkillExp -= fSkillRequireExp;
            SkillStat["fSkillExp"] = fSkillExp.ToString();
            //SkillStat.Add("fSkillExp", fSkillExp.ToString());//�ֵ尡 �ƴ϶� �ٲ��ֱ�
        }
        else
            SkillStat["fSkillExp"] = fSkillExp.ToString();
        //SkillStat.Add("fSkillExp", fSkillExp.ToString());
        SaveParams();
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
        yield return new WaitForSeconds(fCoolTime * fSkillCoolReduce);
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