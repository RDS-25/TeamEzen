using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class Ex_Active1Skill : DamageSkill
{
    private string _strExActive1SkillPath;//���ϰ��
    public Skilldatas scriptabledata;//��ũ���ͺ������Ʈ �ν�����â
    public Charater1 Charater1;    
    Dictionary<string, string> dictActive1SkillStat;//��ųʸ� ���
    public SkillParameter.SkilParams Ex_Active1Params = new SkillParameter.SkilParams();
    //public Action skillTirger;
    public Transform FirePoint;
    public GameObject EffectPrefab;
    void Start()
    {
        InitParams();
        
    }
    public override void InitParams()
    {//���������� ������ LoadParams() ������ SetParams()
        _strExActive1SkillPath = Application.persistentDataPath + "/ActiveSkill/";//������
        if (!GameManager.instance.FolderExists(_strExActive1SkillPath))
            //gamemanager.instance.createfolder(_sexactive1skillpath);
            Directory.CreateDirectory(_strExActive1SkillPath);

        _strExActive1SkillPath += "exActive1.json";//���ϸ� �߰�
        if (GameManager.instance.FileExists(_strExActive1SkillPath))
            LoadParams();
        else
            SetParams();
    }
    public override void SetParams( )
    {
        Debug.Log(scriptabledata.Skills[0].fId);

        if (scriptabledata.Skills[0].fId == 1)
        { //scriptabledata.Skills[0].strName = "�̸�";//��ũ���ͺ� ������Ʈ�� ���� ������
            //scriptabledata.Skills[0].fSkillLevel = 100;
            dictActive1SkillStat = new Dictionary<string, string>();
            Ex_Active1Params.fSkillLevel = scriptabledata.Skills[0].fSkillLevel;
            dictActive1SkillStat.Add("fSkillLevel", Ex_Active1Params.fSkillLevel.ToString());
            Ex_Active1Params.fId = scriptabledata.Skills[0].fId;            
            dictActive1SkillStat.Add("fId", Ex_Active1Params.fId.ToString());
            Ex_Active1Params.strName = scriptabledata.Skills[0].strName;//��ũ���ͺ� ������Ʈ���� �����ö�
            dictActive1SkillStat.Add("strName", Ex_Active1Params.strName);
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
            //dictActive1SkillStat.Add("fBuffDuration", Ex_Active1Params.fBuffDuration.ToString());//������Ƽ�꿡 ���
            Ex_Active1Params.fRange = scriptabledata.Skills[0].fRange;
            dictActive1SkillStat.Add("fRange", Ex_Active1Params.fRange.ToString());
            Ex_Active1Params.fValue = scriptabledata.Skills[0].fValue;
            dictActive1SkillStat.Add("fValue", Ex_Active1Params.fValue.ToString());
            Ex_Active1Params.fMagnification = scriptabledata.Skills[0].fMagnification;
            dictActive1SkillStat.Add("fMagnification", Ex_Active1Params.fMagnification.ToString());
            Ex_Active1Params.fTargetCount =   scriptabledata.Skills[0].fTargetCount;
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
            // ����Ʈ�̸�

            GameManager.instance.DataWrite(_strExActive1SkillPath, dictActive1SkillStat);

        }
        
    }
    public override void LoadParams()
    {
        Dictionary<string, string> dictTemp = GameManager.instance.DataRead(_strExActive1SkillPath);
        Ex_Active1Params.fSkillLevel        = float.Parse(dictTemp["fSkillLevel"]);
        Ex_Active1Params.fId                = float.Parse(dictTemp["fId"]);
        Ex_Active1Params.strName            = dictTemp["strName"];
        Ex_Active1Params.fSkillRequireExp   = float.Parse(dictTemp["fSkillRequireExp"]);
        Ex_Active1Params.strDiscription     = dictTemp["strDiscription"];
        Ex_Active1Params.fUnlockLevel       = float.Parse(dictTemp["fUnlockLevel"]);
        Ex_Active1Params.fUnlockHidenLevel  = float.Parse(dictTemp["fUnlockHidenLevel"]);
        Ex_Active1Params.fTimer             = float.Parse(dictTemp["fTimer"]);
        Ex_Active1Params.fCoolTime          = float.Parse(dictTemp["fCoolTime"]);
        Ex_Active1Params.fDuration          = float.Parse(dictTemp["fDuration"]);
        Ex_Active1Params.fSkillCoolReduce   = float.Parse(dictTemp["fSkillCoolReduce"]);
        Ex_Active1Params.fRange             = float.Parse(dictTemp["fRange"]);
        Ex_Active1Params.fValue             = float.Parse(dictTemp["fValue"]);
        Ex_Active1Params.fMagnification     = float.Parse(dictTemp["fMagnification"]);
        Ex_Active1Params.fTargetCount       = float.Parse(dictTemp["fTargetCount"]);
        Ex_Active1Params.fAttackCount       = float.Parse(dictTemp["fAttackCount"]);
        Ex_Active1Params.fBuffDuration      = float.Parse(dictTemp["fBulletCount"]);
        Ex_Active1Params.bisUnlockSkill     = Convert.ToBoolean(dictTemp["bisUnlockSkill"]);
        Ex_Active1Params.bisUnlockHiden     = Convert.ToBoolean(dictTemp["bisUnlockHiden"]);
        Ex_Active1Params.bisCanUse          = Convert.ToBoolean(dictTemp["bisCanUse"]);
        Ex_Active1Params.bisActtivate       = Convert.ToBoolean(dictTemp["bisActtivate"]);
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
        float plusval = 10f;
        float pulsmag = 10f;
        float plusattackcount = 0;
        float plustargetcount = 0;
        if(Ex_Active1Params.fSkillLevel==5|| Ex_Active1Params.fSkillLevel == 10)
        {
            plusval = 20;
            pulsmag = 20;
            plusattackcount = 1;
            plustargetcount = 1;
        }
        Ex_Active1Params.fSkillLevel++;//����
        dictActive1SkillStat.Add("fSkillLevel", Ex_Active1Params.fSkillLevel.ToString());        
        Ex_Active1Params.fValue += plusval;//�⺻�����
        dictActive1SkillStat.Add("fSkillLevel", Ex_Active1Params.fValue.ToString());        
        Ex_Active1Params.fMagnification += pulsmag;//�������·�
        dictActive1SkillStat.Add("fSkillLevel", Ex_Active1Params.fMagnification.ToString());
        Ex_Active1Params.fSkillRequireExp += Ex_Active1Params.fSkillLevel * 10;//�䱸����ġ ����
        dictActive1SkillStat.Add("fSkillLevel", Ex_Active1Params.fSkillRequireExp.ToString());
        Ex_Active1Params.fAttackCount += plusattackcount;//Ÿ��Ƚ�� ����
        dictActive1SkillStat.Add("fSkillLevel", Ex_Active1Params.fAttackCount.ToString());
        Ex_Active1Params.fTargetCount += plustargetcount;//Ÿ�ټ� ����
        dictActive1SkillStat.Add("fSkillLevel", Ex_Active1Params.fTargetCount.ToString());
        GameManager.instance.DataWrite(_strExActive1SkillPath, dictActive1SkillStat);//����
        SkillHidenUnlock();
        SkillUnlock();
    }
    public override void SkillUnlock()
    {
        if (Charater1.Level > Ex_Active1Params.fUnlockLevel)
        {
            dictActive1SkillStat.Add("bisUnlockSkill", true.ToString());
        }
        //�߰����

    }
    public override void SkillHidenUnlock()
    {
        if (Charater1.Level > Ex_Active1Params.fUnlockHidenLevel)
        {
            dictActive1SkillStat.Add("bisUnlockSkill", true.ToString());
        }
        //�߰����

    }
    public override void SkillTriger()
    {//����Ʈ ������
        if(Ex_Active1Params.bisCanUse==true|| Ex_Active1Params.bisActtivate == false)
        {
            Ex_Active1Params.bisCanUse = false;

            Ex_Active1Params.bisActtivate = true;

            Ex_Active1Params.fTimer = 0f;
            
            EffectStart();//����Ʈ �ִ� ��ų�� ���
            StartCoroutine(SkillCoolDown());
        }

        //skillTirger?.Invoke();
    }
    
   public override IEnumerator SkillCoolDown()
    {
        yield return new WaitForSeconds(Ex_Active1Params.fCoolTime);
        Ex_Active1Params.bisCanUse = true;
        Ex_Active1Params.bisActtivate = false;
    }
    
    public void EffectStart()
    {
        EffectPrefab.GetComponent<Ex_Active1Effect>().fRange = this.Ex_Active1Params.fRange;//����Ʈ�� ��Ÿ�
        Instantiate(EffectPrefab, FirePoint.position, FirePoint.rotation);//���丮�� �ٲٱ�
    }
    private void Update()
    {
        
    }
}
