using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Ex_Active1Effect : SkillEffrct
{
    
    //public Charater1 Charater1;
    //public Ex_Active1Skill ex_Active1Skill;
    float fSpeed = 100f;
    public Action SkillHit;//��ų ����Ʈ�� ���Ϳ��� �浹������    
    public Vector3 Firepiont;

    private void OnDisable()
    {
        ChaStat = null;
    }

    public void SkillActivationInit(ref Stat activeObjectStat)
    {
        ChaStat = activeObjectStat;
    }


    void Start()
    {

        MoveEffect();
        fRancri = UnityEngine.Random.Range(0f, 100f);
        fRanmondod = UnityEngine.Random.Range(0f, 100f);
        Firepiont = gameObject.GetComponent<Transform>().position;
    }
    public  void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            Debug.Log(other.tag);
            var monsterStat= other.GetComponent<Stat>();
            fMonDadge = monsterStat.fMiss;
            fMonCriresi = monsterStat.fCriticalResist;
            fMonDefense = monsterStat.fDef;
            fMonProperty = monsterStat.fProperty;
            
            CalculDamage(ChaStat.fAtk,ChaStat.fCriticalPer,ChaStat.fCriticalDmg,ChaStat.fDefBreak,ChaStat.fProperty
                ,fMonDadge,fMonCriresi, fMonDefense,fMonProperty);
            // ���� ����
            monsterStat.fHealth -= fTotalDamage;                        
        }        
    }
    //public override float CheckPro(float Attacker, float Defender)
    //{
    //    return base.CheckPro(Attacker, Defender);
    //}
    //public float CalculDamage(float chadam, float chacriper, float chacridam, float chadefenpier, float Attacker,
    //    float mondadge, float moncrire, float mondefen, float Defender)
    //{
    //    return base.CalculDamage(chadam, chacriper, chacridam, chadefenpier, Attacker, mondadge, moncrire, mondefen, Defender);
    //}
    //public override float CalculDamage()
    //{
    //    if (fRanmondod < fMonDadge)//������ ȸ�Ǽ�����
    //    {
    //        Debug.Log("ȸ��+"+(fRanmondod - fMonDadge));
    //        float calculdamage = 0;
    //        fTotalDamage = calculdamage;
    //        //������ �ؽ�Ʈ
    //        Debug.Log("������"+fTotalDamage);
    //        return fTotalDamage;
    //    }
    //    else//������ ȸ�ǽ��н�
    //    {
    //        if (fRancri <= Charater1.critical - fMonCriresi)//ũ��Ƽ���� ���
    //        {
    //            float calculdamage =
    //                (Charater1.damage *(100+ Charater1.criticaldamage)/100 *
    //                (fMonDefense - Charater1.defensepierce) / (fMonDefense + 100));
    //            fTotalDamage = calculdamage;
    //            Debug.Log(fTotalDamage);
    //            return fTotalDamage;
    //        }
    //        else//ũ��Ƽ���� �ƴҰ��
    //        {
    //            float calculdamage = Charater1.damage * (fMonDefense - Charater1.defensepierce) / (fMonDefense + 100);
    //            fTotalDamage = calculdamage;
    //            Debug.Log(fTotalDamage);
    //            return fTotalDamage;
    //        }//�Ӽ�???
    //    }

    //}
    public override void CheckDistance(Vector3 firepoint, float range)
    {
        
        float distance = Vector3.Distance(Firepiont, this.transform.position);
        Debug.Log("ran" + range);
        Debug.Log("dis"+ distance);
       // Debug.Log("ran" + Ex_Active1Skill.Ex_Active1Params.fRange);
        if (distance > range)//Ex_Active1Params�� Range�� �������� ���??
        {

            Destroy(this.gameObject);
        }
        else
            return;
    }
    public void MoveEffect()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * fSpeed);
    }
    void Update()
    {
        //CheckDistance(Firepiont, ex_Active1Skill.fRange);
    }
}
