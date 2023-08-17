using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillEffrct : MonoBehaviour
    //해당캐릭 
{//적과의 충돌감지,대미지관련값 받아오고 마저 계산(o)
    //몬스터와 캐릭터에게 대미지값 전달
    public Charater1 Charater1;
    float fRancri;
    float fRanmondod;
    float fMonDadge;
    float fMonDefense;
    float fMonCriresi;
    float fTotalDamage;
    public Action SkillHit;//스킬 이펙트가 몬스터에게 충돌했을때

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
            SkillHit?.Invoke();//X?  X가 만족하면 뒤에거 실행  나중 실제 이펙트쪽으로 옮기기
            //몬스터 피해입는곳
        }
    }
    public virtual float CalculDamage()
    {//계산된 대미지,크리티컬확률,크리티컬대미지,방어구관통,캐릭터속성,
     //몬스터회피,몬스터방어,몬스터크리저항몬스터속성
     //대미지 계산
     
        
        if (fRanmondod < fMonDadge)//몬스터의 회피성공시
        {
            float calculdamage = 0;
            fTotalDamage = calculdamage;
            //빗나감 텍스트
            return fTotalDamage;
        }
        else//몬스터의 회피실패시
        {
            if (fRancri <= Charater1.critical - fMonCriresi)//크리티컬일 경우
            {                
                float calculdamage =
                    (Charater1.damage * Charater1.criticaldamage *
                    (fMonDefense - Charater1.defensepierce) / (fMonDefense + 100));
                fTotalDamage = calculdamage;
                return fTotalDamage;
            }
            else//크리티컬이 아닐경우
            {
                float calculdamage = Charater1.damage * (fMonDefense - Charater1.defensepierce) / (fMonDefense + 100);
                fTotalDamage = calculdamage;
                return fTotalDamage;
            }//속성???
        }
        
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