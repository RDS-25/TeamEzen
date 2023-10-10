using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillEffrct : MonoBehaviour
{
    
    FactoryManager factoryManager;
    //파티클 실행시간 이후 없애기
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
{//계산된 대미지,크리티컬확률,크리티컬대미지,방어구관통,캐릭터속성,
 //몬스터회피,몬스터방어,몬스터크리저항몬스터속성
 //대미지 계산
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
        }//속성???
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
    SkillHit?.Invoke();//X?  X가 만족하면 뒤에거 실행  나중 실제 이펙트쪽으로 옮기기
                       //몬스터 피해입는곳
}*/