using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;
using System;
using System.IO;

public class ActiveSkill : Skill
{

    public Transform FirePoint;
    public GameObject EffectPrefab;

    //��ų������ ������ ��ų���� ���ֱ�


    public override void SetType()
    {
        skillType = SkillType.ACTIVE;
        skillDetail = SkillDetailType.ATTACK;
    }
    public override void InitParams()
    {//���������� ������ LoadParams() ������ SetParams()

        if (GameManager.instance.CheckExist(SkillPath, SkillParamsPath))
        {
            LoadParams();
        }
        else
        {
            SetDefault();
            SetParams();
        }
    }


    public override void SetDefault()
    {//��Ƽ�꽺ų�� �ٽ� ����

        fSkillLevel = 1;
        fId = 10;
        strName = "Act1";
        strDiscription = "ok";
        //strIconpath=
        //strEffectPath=
        fSkillExp = 0;
        fSkillRequireExp = 100;
        fUnlockLevel = 1;
        fUnlockHidenLevel = 20;
        fTimer = 0;
        fCoolTime = 1;
        fDuration = 1;
        fSkillCoolReduce = 0;
        fRange = 50;
        fMaxRange = 10;
        fValue = 10;
        fHidenValue = 10;
        fMagnification = 10;
        fTargetCount = 1;
        fAttackCount = 1;
        fBulletCount = 1;
        bisUnlockSkill = false;
        bisUnlockHiden = false;
        bisCanUse = false;
        bisActtivate = false;
    }
    public override void SetParams()
    {      //��ųŸ�� �ֱ�
        Dictionary<string, string> dictTemp = new Dictionary<string, string>();
        dictTemp.Add("fSkillLevel", fSkillLevel.ToString());
        dictTemp.Add("fId", fId.ToString());
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
    public override void LoadParams()
    {
        Dictionary<string, string> dictTemp = GameManager.instance.DataRead(SkillPath);
        fSkillLevel = float.Parse(dictTemp["fSkillLevel"]);
        fId = float.Parse(dictTemp["fId"]);
        strName = dictTemp["strName"];
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
    public override void SkillExpUp(float exp)
    {
        fSkillExp += exp;
        if (fSkillExp >= fSkillRequireExp)
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

    }
    public override void SkillUnlock()
    {
        if (fSkillLevel > fUnlockLevel)
        {
            bisUnlockSkill = true;
            SkillStat.Add("bisUnlockSkill", true.ToString());

        }
        SetParams();
        //�߰����

    }
    public override void SkillHidenUnlock()
    {
        if (ChaStat.fLevel > fUnlockHidenLevel)
        {
            bisUnlockHiden = true;
            SkillStat.Add("bisUnlockHiden", true.ToString());
        }
        SetParams();
        //�߰����

    }
    public override void SkillTriger()
    {
        if (bisCanUse == true || bisActtivate == false)
        {
            bisCanUse = false;

            bisActtivate = true;

            fTimer = 0f;

            EffectStart();//����Ʈ �ִ� ��ų�� ���
            StartCoroutine(SkillCoolDown());
        }

        //skillTirger?.Invoke();
    }

    public virtual IEnumerator SkillCoolDown()
    {
        yield return new WaitForSeconds(fCoolTime);
        bisCanUse = true;
        bisActtivate = false;
    }

    public void EffectStart()
    {
        Instantiate(EffectPrefab, FirePoint.position, FirePoint.rotation);//���丮�� �ٲٱ�
    }


    //��Ÿ�ӵ��� ���Ұ� ��Ÿ�� ����� ��밡��
    //skilParams.fTimer += Time.deltaTime;
    //if (skilParams.fTimer >= skilParams.fCoolTime)
    //    skilParams.bisCanUse = true;   
}
/*public virtual void SkillCoolDown()
{//��Ÿ�ӵ��� ���Ұ� ��Ÿ�� ����� ��밡��
    SkilParams.fTimer += Time.deltaTime;
    if (SkilParams.fTimer >= SkilParams.fCoolTime)
        SkilParams.bisCanUse = true;
}*/