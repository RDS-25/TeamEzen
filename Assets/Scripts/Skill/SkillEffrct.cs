using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillEffrct : MonoBehaviour
{
    
    FactoryManager factoryManager;
    //��ƼŬ ����ð� ���� ���ֱ�
    private void Start()
    {
        EndEffect();
    }
    public virtual void myFactory(FactoryManager myFactoryManager)
    {
        factoryManager = myFactoryManager;
    }
    protected virtual void EndEffect()
    {
        StartCoroutine("time");
        //factoryManager.SetObject(gameObject);

    }
    IEnumerator time()
    {
        yield return new WaitForSeconds(GetComponent<ParticleSystem>().main.duration);
        factoryManager.SetObject(gameObject);
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