using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class Ex_Active1Skill : ActiveSkill
{
    private string _strExActive1SkillPath;//���ϰ��
    string ActiveParams;
    public Skilldatas scriptabledata;//��ũ���ͺ������Ʈ �ν�����â
    public Charater1 Charater1;    
    Dictionary<string, string> dictActive1SkillStat;//��ųʸ� ���
    //public Action skillTirger;
    public Transform FirePoint;
    public GameObject EffectPrefab;
    //��ų������ ������ ��ų���� ���ֱ�
    const float PLUS_VAL = 10f;
    const float PLUS_MAG = 10f;
    const float PLUS_TARGET_COUNT = 0f;
    const float PLUS_ATTACK_COUNT = 0f;



    void Start()
    {
        _strExActive1SkillPath = Application.persistentDataPath + "/ActiveSkill/";//������
        ActiveParams = FileName.STR_JSON_ACTIVESKILL1_PARAS;//���ϸ� �߰�
        LevelUpValue();
        InitParams();
    }
    public override void InitParams()
    {//���������� ������ LoadParams() ������ SetParams()

        if (GameManager.instance.CheckExist(_strExActive1SkillPath, ActiveParams))
        {
            LoadParams();
        }
        else
        {
            SetDefault();
            SetParams();
        }
    }
    void LevelUpValue()
    {
        plusval = PLUS_VAL;
        pulsmag = PLUS_MAG;
        plustargetcount = PLUS_TARGET_COUNT;
        plusattackcount = PLUS_ATTACK_COUNT;
    }
    public void SetDefault()
    {//��ũ���ͺ� ����� ���� �����ϱ�
        SkillParameter.SkilParams scriptable = scriptabledata.Skills[0];
        fSkillLevel = scriptable.fSkillLevel;
        fId = scriptable.fId;
        strName = scriptable.strName;//��ũ���ͺ� ������Ʈ���� �����ö�
        strDiscription = scriptable.strDiscription;
        fSkillExp = scriptable.fSkillExp;
        fSkillRequireExp = scriptable.fSkillRequireExp;
        fUnlockLevel = scriptable.fUnlockLevel;
        fUnlockHidenLevel = scriptable.fUnlockHidenLevel;
        fTimer = scriptable.fTimer;
        fCoolTime = scriptable.fCoolTime;
        fDuration = scriptable.fDuration;
        fSkillCoolReduce = scriptable.fSkillCoolReduce;
        fRange = scriptable.fRange;
        fValue = scriptable.fValue;
        fHidenValue = scriptable.fHidenValue;
        fMagnification = scriptable.fMagnification;
        fTargetCount = scriptable.fTargetCount;
        fAttackCount = scriptable.fAttackCount;
        fBulletCount = scriptable.fBulletCount;
        bisUnlockSkill = scriptable.bisUnlockSkill;
        bisUnlockHiden = scriptable.bisUnlockHiden;
        bisCanUse = scriptable.bisCanUse;
        bisActtivate = scriptable.bisActtivate;
    }
    public override void SetParams()
    {      
            Dictionary<string, string> dictTemp = new Dictionary<string, string>();
            dictTemp.Add("fSkillLevel", fSkillLevel.ToString());
            dictTemp.Add("fId", fId.ToString());
            dictTemp.Add("strName", strName);
            dictTemp.Add("strDiscription", strDiscription);
            dictTemp.Add("fSkillExp", strDiscription);
            dictTemp.Add("fSkillRequireExp", fSkillRequireExp.ToString());
            dictTemp.Add("fUnlockLevel", fUnlockLevel.ToString());
            dictTemp.Add("fUnlockHidenLevel", fUnlockHidenLevel.ToString());
            dictTemp.Add("fTimer", fTimer.ToString());
            dictTemp.Add("fCoolTime", fCoolTime.ToString());
            dictTemp.Add("fDuration", fDuration.ToString());
            dictTemp.Add("fSkillCoolReduce", fSkillCoolReduce.ToString());
            dictTemp.Add("fRange", fRange.ToString());
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

            GameManager.instance.DataWrite(_strExActive1SkillPath, dictTemp);

        
        
    }
    public override void LoadParams()
    {
        Dictionary<string, string> dictTemp = GameManager.instance.DataRead(_strExActive1SkillPath);
        fSkillLevel        = float.Parse(dictTemp["fSkillLevel"]);
        fId                = float.Parse(dictTemp["fId"]);
        strName            = dictTemp["strName"];
        fSkillExp          = float.Parse(dictTemp["fSkillExp"]);
        fSkillRequireExp   = float.Parse(dictTemp["fSkillRequireExp"]);
        strDiscription     = dictTemp["strDiscription"];
        fUnlockLevel       = float.Parse(dictTemp["fUnlockLevel"]);
        fUnlockHidenLevel  = float.Parse(dictTemp["fUnlockHidenLevel"]);
        fTimer             = float.Parse(dictTemp["fTimer"]);
        fCoolTime          = float.Parse(dictTemp["fCoolTime"]);
        fDuration          = float.Parse(dictTemp["fDuration"]);
        fSkillCoolReduce   = float.Parse(dictTemp["fSkillCoolReduce"]);
        fRange             = float.Parse(dictTemp["fRange"]);
        fValue             = float.Parse(dictTemp["fValue"]);
        fHidenValue        = float.Parse(dictTemp["fHidenValue"]);
        fMagnification     = float.Parse(dictTemp["fMagnification"]);
        fTargetCount       = float.Parse(dictTemp["fTargetCount"]);
        fAttackCount       = float.Parse(dictTemp["fAttackCount"]);
        fBuffDuration      = float.Parse(dictTemp["fBulletCount"]);
        bisUnlockSkill     = Convert.ToBoolean(dictTemp["bisUnlockSkill"]);
        bisUnlockHiden     = Convert.ToBoolean(dictTemp["bisUnlockHiden"]);
        bisCanUse          = Convert.ToBoolean(dictTemp["bisCanUse"]);
        bisActtivate       = Convert.ToBoolean(dictTemp["bisActtivate"]);
    }
    public override void SkillExpUp(float exp)
    {
        fSkillExp += exp;
        if(fSkillExp>= fSkillRequireExp)
        {
            SkillLevelUp();
            fSkillExp -= fSkillRequireExp;
            SetParams();
            // dictActive1SkillStat.Add("fSkillExp", fSkillExp.ToString());


            // GameManager.instance.DataWrite()
        }
        else
            SetParams();
        //dictActive1SkillStat.Add("fSkillExp", fSkillExp.ToString());
    }
    public override void SkillLevelUp()
    {

        if (fSkillLevel % 5 == 0)
            checkLevel = 1f;
        else
            checkLevel = 0f;

        plusval = PLUS_VAL + (checkLevel * 10f);
        pulsmag = PLUS_MAG + (checkLevel * 10f);
        plusattackcount = PLUS_ATTACK_COUNT + (checkLevel * 1f);
        plustargetcount = PLUS_TARGET_COUNT + (checkLevel * 1f);

        fSkillLevel++;//����
        fValue += plusval;//�⺻�����
        fMagnification += pulsmag;//�������·�
        fSkillRequireExp += fSkillLevel * 10;//�䱸����ġ ����
        fAttackCount += plusattackcount;//Ÿ��Ƚ�� ����
        fTargetCount += plustargetcount;//Ÿ�ټ� ����

        SetParams();
        SkillHidenUnlock();
        SkillUnlock();
    }
    public override void SkillUnlock()
    {
        if (Charater1.Level > fUnlockLevel)
        {
            bisUnlockSkill = true;
            dictActive1SkillStat.Add("bisUnlockSkill", true.ToString());
            
        }
        SetParams();
        //�߰����

    }
    public override void SkillHidenUnlock()
    {
        if (Charater1.Level > fUnlockHidenLevel)
        {
            bisUnlockHiden = true;
            dictActive1SkillStat.Add("bisUnlockHiden", true.ToString());
        }
        SetParams();
        //�߰����

    }
    public override void SkillTriger()
    {//����Ʈ ������
        if(bisCanUse==true|| bisActtivate == false)
        {
            bisCanUse = false;

            bisActtivate = true;

            fTimer = 0f;
            
            EffectStart();//����Ʈ �ִ� ��ų�� ���
            StartCoroutine(SkillCoolDown());
        }

        //skillTirger?.Invoke();
    }
    
   public override IEnumerator SkillCoolDown()
    {
        yield return new WaitForSeconds(fCoolTime);
        bisCanUse = true;
        bisActtivate = false;
    }
    
    public void EffectStart()
    {
        EffectPrefab.GetComponent<Ex_Active1Effect>().fRange = this.fRange;//����Ʈ�� ��Ÿ�
        Instantiate(EffectPrefab, FirePoint.position, FirePoint.rotation);//���丮�� �ٲٱ�
    }
   
}
