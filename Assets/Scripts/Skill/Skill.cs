using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;
using System;


public class Skill: SkilParams
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

    }
    public virtual void SetType()
    {

    }
    public virtual void SetDefault()//ù ��ų�Ķ���� �Է�
    {

    }

    public virtual void SetParams()//��ų �Ķ���� ����
    {

    }
    
      public virtual void LoadParams()
    {

    }
    

    public virtual void SkillUnlock()//��ų �ر�
    {
    //    if (CharacterLevel > SkilParams.fUnlockLevel)
    //        SkilParams.bisUnlockSkill = true;
    //    //Ȱ��ȭ ��Ű��
    }
   public virtual void SkillHidenUnlock()
    {
        //if (CharacterLevel > SkilParams.fUnlockHidenLevel)
        //    SkilParams.bisUnlockHiden = true;
    }
    public virtual void SkillTriger()//��ų �ߵ�(�ܹ���)
    {//�ִϸ��̼�, ȿ����, ����ü�߻�, ������ ������ֱ�, 
                   
        
                       
    }
    
    public virtual void SkillExpUp(float exp)
    {

    }
    public virtual void SkillLevelUp()//��ų ������(��ȭ)
    {//����� ��ųʸ��� �ٽ� �����ֱ�
        /*SkilParams.fSkillLevel++;
        SkilParams.fValue += damage;//�⺻����� ����
        SkilParams.fMagnification += magnification;//��ų���� ����
        SkilParams.fAttackCount += attackcount;//Ÿ��Ƚ�� ����
        SkilParams.fTargetCount += targetcount;//Ÿ�ټ� ����
        SkilParams.fSkillRequireExp += SkilParams.fSkillLevel *10;//�䱸����ġ ����
        float plusdam, float pulsmag,
        float plusattackcount,float plustargetcount*/
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