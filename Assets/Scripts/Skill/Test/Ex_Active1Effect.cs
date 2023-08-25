using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Ex_Active1Effect : SkillEffrct
{
    //public Charater1 Charater1;
    public Ex_Active1Skill ex_Active1Skill;
    float fSpeed = 100f;
    public Action SkillHit;//��ų ����Ʈ�� ���Ϳ��� �浹������    
    public Vector3 Firepiont;


    void Start()
    {
        
        MoveEffect();
        fRancri = UnityEngine.Random.Range(0f, 100f);
        fRanmondod = UnityEngine.Random.Range(0f, 100f);
        Firepiont = gameObject.GetComponent<Transform>().position;
    }
    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            var component = other.GetComponent<Monster>();
            fMonDadge = component.dodge;
            fMonCriresi = component.criticalresist;
            fMonDefense = component.defense;            
            CalculDamage();
            // ���� ����
            SkillHit?.Invoke("1",1);//X?  X�� �����ϸ� �ڿ��� ����  ���� ���� ����Ʈ������ �ű��
            //���� �����Դ°�
            Debug.Log(other.tag);
        }
    }
    public override float CalculDamage()
    {
        if (fRanmondod < fMonDadge)//������ ȸ�Ǽ�����
        {

            Debug.Log("ȸ��+"+(fRanmondod - fMonDadge));
            float calculdamage = 0;
            fTotalDamage = calculdamage;
            //������ �ؽ�Ʈ
            Debug.Log("������"+fTotalDamage);
            return fTotalDamage;
        }
        else//������ ȸ�ǽ��н�
        {
            if (fRancri <= Charater1.critical - fMonCriresi)//ũ��Ƽ���� ���
            {
                float calculdamage =
                    (Charater1.damage *(100+ Charater1.criticaldamage)/100 *
                    (fMonDefense - Charater1.defensepierce) / (fMonDefense + 100));
                fTotalDamage = calculdamage;
                Debug.Log(fTotalDamage);
                return fTotalDamage;
            }
            else//ũ��Ƽ���� �ƴҰ��
            {
                float calculdamage = Charater1.damage * (fMonDefense - Charater1.defensepierce) / (fMonDefense + 100);
                fTotalDamage = calculdamage;
                Debug.Log(fTotalDamage);
                return fTotalDamage;
            }//�Ӽ�???
        }

    }
    public void CheckDistance()
    {
        
        float distance = Vector3.Distance(Firepiont, this.transform.position);
        Debug.Log("ran" + fRange);
        Debug.Log("dis"+ distance);
       // Debug.Log("ran" + Ex_Active1Skill.Ex_Active1Params.fRange);
        if (distance > fRange)//Ex_Active1Params�� Range�� �������� ���??
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
        CheckDistance();
    }
}
