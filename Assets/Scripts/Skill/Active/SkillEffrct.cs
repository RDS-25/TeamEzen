using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillEffrct : MonoBehaviour
    //�ش�ĳ�� 
{//������ �浹����,��������ð� �޾ƿ��� ���� ���(o)
    //���Ϳ� ĳ���Ϳ��� ������� ����
    public Charater1 Charater1;
    float fRancri;
    float fRanmondod;
    float fMonDadge;
    float fMonDefense;
    float fMonCriresi;
    float fTotalDamage;
    public Action SkillHit;//��ų ����Ʈ�� ���Ϳ��� �浹������

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
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
        }
    }
    public virtual float CalculDamage()
    {//���� �����,ũ��Ƽ��Ȯ��,ũ��Ƽ�ô����,������,ĳ���ͼӼ�,
     //����ȸ��,���͹��,����ũ�����׸��ͼӼ�
     //����� ���
     
        
        if (fRanmondod < fMonDadge)//������ ȸ�Ǽ�����
        {
            float calculdamage = 0;
            fTotalDamage = calculdamage;
            //������ �ؽ�Ʈ
            return fTotalDamage;
        }
        else//������ ȸ�ǽ��н�
        {
            if (fRancri <= Charater1.critical - fMonCriresi)//ũ��Ƽ���� ���
            {                
                float calculdamage =
                    (Charater1.damage * Charater1.criticaldamage *
                    (fMonDefense - Charater1.defensepierce) / (fMonDefense + 100));
                fTotalDamage = calculdamage;
                return fTotalDamage;
            }
            else//ũ��Ƽ���� �ƴҰ��
            {
                float calculdamage = Charater1.damage * (fMonDefense - Charater1.defensepierce) / (fMonDefense + 100);
                fTotalDamage = calculdamage;
                return fTotalDamage;
            }//�Ӽ�???
        }
        
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