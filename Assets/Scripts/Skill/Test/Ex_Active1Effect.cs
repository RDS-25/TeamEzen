using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Ex_Active1Effect : SkillEffrct
{
    //public Charater1 Charater1;
    public Ex_Active1Skill ex_Active1Skill;
    float fSpeed = 100f;
    public Action SkillHit;//스킬 이펙트가 몬스터에게 충돌했을때    
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
            // 오류 있음
            SkillHit?.Invoke("1",1);//X?  X가 만족하면 뒤에거 실행  나중 실제 이펙트쪽으로 옮기기
            //몬스터 피해입는곳
            Debug.Log(other.tag);
        }
    }
    public override float CalculDamage()
    {
        if (fRanmondod < fMonDadge)//몬스터의 회피성공시
        {

            Debug.Log("회피+"+(fRanmondod - fMonDadge));
            float calculdamage = 0;
            fTotalDamage = calculdamage;
            //빗나감 텍스트
            Debug.Log("데미지"+fTotalDamage);
            return fTotalDamage;
        }
        else//몬스터의 회피실패시
        {
            if (fRancri <= Charater1.critical - fMonCriresi)//크리티컬일 경우
            {
                float calculdamage =
                    (Charater1.damage *(100+ Charater1.criticaldamage)/100 *
                    (fMonDefense - Charater1.defensepierce) / (fMonDefense + 100));
                fTotalDamage = calculdamage;
                Debug.Log(fTotalDamage);
                return fTotalDamage;
            }
            else//크리티컬이 아닐경우
            {
                float calculdamage = Charater1.damage * (fMonDefense - Charater1.defensepierce) / (fMonDefense + 100);
                fTotalDamage = calculdamage;
                Debug.Log(fTotalDamage);
                return fTotalDamage;
            }//속성???
        }

    }
    public void CheckDistance()
    {
        
        float distance = Vector3.Distance(Firepiont, this.transform.position);
        Debug.Log("ran" + fRange);
        Debug.Log("dis"+ distance);
       // Debug.Log("ran" + Ex_Active1Skill.Ex_Active1Params.fRange);
        if (distance > fRange)//Ex_Active1Params의 Range를 가져오는 방법??
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
