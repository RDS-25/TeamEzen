using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillEffrct : MonoBehaviour
    //�ش�ĳ�� 
{//������ �浹����,��������ð� �޾ƿ��� ���� ���(o)
    //���Ϳ� ĳ���Ϳ��� ������� ����
    
    protected float fRancri;
    protected float fRanmondod;
    protected float fMonDadge;
    protected float fMonDefense;
    protected float fMonCriresi;
    protected float fTotalDamage;
    public  float fRange;
    protected float fMonProperty;
    protected Stat ChaStat;

    public  float CalculDamage(float chadam, float chacriper, float chacridam, float chadefenpier, float Attacker,
        float mondadge, float moncrire, float mondefen, float Defender)//���� �������� �ٽþ���
    {
        if (fRanmondod < mondadge)
        {
            fTotalDamage = 0;
            return fTotalDamage;
        }
        else
        {
            if (fRancri <= chacriper - moncrire)
            {
                fTotalDamage = (chadam * chacridam * (mondefen - chadefenpier / mondefen + 100)) * CheckPro(Attacker, Defender);
            }
            else
            {
                fTotalDamage = chadam * (mondefen - chadefenpier / mondefen + 100) * CheckPro(Attacker, Defender);
            }
            return fTotalDamage;
        }
    }
    //public virtual float CalculDamage()
    //{//���� �����,ũ��Ƽ��Ȯ��,ũ��Ƽ�ô����,������,ĳ���ͼӼ�,
    // //����ȸ��,���͹��,����ũ�����׸��ͼӼ�
    // //����� ���
     
        
    //    if (fRanmondod < fMonDadge)//������ ȸ�Ǽ�����
    //    {
    //        float calculdamage = 0;
    //        fTotalDamage = calculdamage;
    //        //������ �ؽ�Ʈ
    //        return fTotalDamage;
    //    }
    //    else//������ ȸ�ǽ��н�
    //    {
    //        if (fRancri <= Charater1.critical - fMonCriresi)//ũ��Ƽ���� ���
    //        {                
    //            float calculdamage =
    //                (Charater1.damage * Charater1.criticaldamage *
    //                (fMonDefense - Charater1.defensepierce) / (fMonDefense + 100));
    //            fTotalDamage = calculdamage;
    //            return fTotalDamage;
    //        }
    //        else//ũ��Ƽ���� �ƴҰ��
    //        {
    //            float calculdamage = Charater1.damage * (fMonDefense - Charater1.defensepierce) / (fMonDefense + 100);
    //            fTotalDamage = calculdamage;
    //            return fTotalDamage;
    //        }//�Ӽ�???
    //    }        
    //}
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
        Debug.Log("ran" + range);
        Debug.Log("dis" + distance);
        // Debug.Log("ran" + Ex_Active1Skill.Ex_Active1Params.fRange);
        if (distance > range)//Ex_Active1Params�� Range�� �������� ���??
        {

            Destroy(this.gameObject);//�ȴ� �ʱ�ȭ
        }
        else
            return;
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