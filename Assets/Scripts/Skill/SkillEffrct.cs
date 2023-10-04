using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillEffrct : MonoBehaviour
    //�ش�ĳ�� 
{//������ �浹����,��������ð� �޾ƿ��� ���� ���(o)
 //���Ϳ� ĳ���Ϳ��� ������� ����
    FactoryManager factoryManager;
    
    protected float fSpeed=100f;
    protected Vector3 Firepiont;
    protected float fRancri;
    protected float fRanmondod;
    protected float fMonDadge;
    protected float fMonDefense;
    protected float fMonCriresi;
    protected float fTotalDamage;    
    protected float fMonProperty;
    protected Stat ChaStat;
    protected float fAttackCount;
    protected float fTargetCount;     
    protected Rigidbody rig;
    int count;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        fRancri = UnityEngine.Random.Range(0f, 100f);
        fRanmondod = UnityEngine.Random.Range(0f, 100f);
        Firepiont = gameObject.GetComponent<Transform>().position;
        count = 0;
    }
    
    public void SkillActivationInit(ref Stat activeObjectStat)
    {
        ChaStat = activeObjectStat;
    }
    public  float CalculDamage(float attackcount)//���� �������� �ٽþ���
    {
        if (fRanmondod < fMonDadge)
        {
            fTotalDamage = 0;
            return fTotalDamage;
        }
        else
        {
            if (fRancri <= ChaStat.fCriticalPer - fMonCriresi)
            {
                fTotalDamage = (ChaStat.fAtk * ChaStat.fCriticalDmg * (fMonDefense - ChaStat.fDefBreak / fMonDefense + 100)) * CheckPro(ChaStat.fProperty, fMonProperty)* attackcount;
            }
            else
            {
                fTotalDamage = ChaStat.fAtk * (fMonDefense - ChaStat.fDefBreak / fMonDefense + 100) * CheckPro(ChaStat.fProperty, fMonProperty) * attackcount;
            }
            return fTotalDamage;
        }
    }
    public void OnTriggerEnter(Collider other)
    {        
        if (other.tag == "Enemy")
        {
            count++;
            Debug.Log(other.tag);
            var monsterStat = other.GetComponent<Stat>();
            fMonDadge = monsterStat.fMiss;
            fMonCriresi = monsterStat.fCriticalResist;
            fMonDefense = monsterStat.fDef;
            fMonProperty = monsterStat.fProperty;

            CalculDamage(fAttackCount);
            // ���� ����
            monsterStat.fHealth -= fTotalDamage;
            if(count>= fTargetCount)
            {
                factoryManager.SetObject(gameObject);
            }
        }
        //����Ʈ ���丮 ����� ������Ű�� 
    }
    public virtual float CheckPro(float Attacker, float Defender)
    {
        if (Attacker - Defender == -1 || Attacker - Defender == 2)
        {//AttackerWin;
            return 1.3f;
        }
        if (Attacker - Defender == 1 || Attacker - Defender == -2)
        {//AttackerLose;
            return 0.7f;
        }
        else
            return 1f;
    }
    public virtual void CheckDistance(Vector3 firepoint,float range)
    {

        float distance = Vector3.Distance(firepoint, this.transform.position);
        //Debug.Log("ran" + range);
        //Debug.Log("dis" + distance);
        // Debug.Log("ran" + Ex_Active1Skill.Ex_Active1Params.fRange);
        if (distance > range)//Ex_Active1Params�� Range�� �������� ���??
        {
            // setactive ���ֱ�
            factoryManager.SetObject(gameObject);          

        }
        else
            return;
    }
    public virtual void MoveEffect()
    {        
        //GetComponent<Rigidbody>().AddForce(transform.forward * fSpeed*Time.deltaTime);
             
    }
    public virtual void myFactory(FactoryManager myFactoryManager)
    {
        factoryManager = myFactoryManager;
    }
    
}


/*public virtual float CalculDamage(float damage, float critical, float criticaldamage,
        float defensepierce, int chaprotype, float mondodge, float mondsfense, float moncriresi, int monprotype)
{//���� �����,ũ��Ƽ��Ȯ��,ũ��Ƽ�ô����,������,ĳ���ͼӼ�,
 //����ȸ��,���͹��,����ũ�����׸��ͼӼ�
 //����� ���
 // float calculdamage= damage
    damage = Charater1.damage;
    if (fRanmondod < mondodge)
    {
        float calculdamage = 0;
        return calculdamage;
    }
    else
    {
        if (fRancri <= critical - moncriresi)
        {

            float calculdamage =
                (damage * criticaldamage * (mondsfense - defensepierce) / (mondsfense + 100));
            return calculdamage;
        }
        else
        {
            float calculdamage = damage * (mondsfense - defensepierce) / (mondsfense + 100);
            return calculdamage;
        }//�Ӽ�???
    }
}*/
/*if (other.tag == "Monster")
{
    var component = other.GetComponent<Monster>();
    fMonDadge = component.dodge;
    fMonCriresi = component.criticalresist;
    fMonDefense = component.defense;
    float fRancri = UnityEngine.Random.Range(0f, 100f);
    float fRanmondod = UnityEngine.Random.Range(0f, 100f);
    CalculDamage();
    SkillHit?.Invoke();//X?  X�� �����ϸ� �ڿ��� ����  ���� ���� ����Ʈ������ �ű��
                       //���� �����Դ°�
}*/