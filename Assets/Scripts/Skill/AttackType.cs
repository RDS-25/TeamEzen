using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;
using System;
using System.IO;
public class AttackType : Skill
{
    public Transform FirePoint;
    public GameObject EffectPrefab;

    //스킬레벨업 변수들 스킬마다 써주기


    public override void SetType()
    {
        skillDetail = "ATTACK";//딕셔너리 저장용 변수
        enumSkillDetail = SkillDetailType.ATTACK;
    }
    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
        fAttackCount += plusattackcount;//타격횟수 증가
        fTargetCount += plustargetcount;//타겟수 증가
    }


    public override void SkillTriger()
    {
        if (bisCanUse == true || bisActtivate == false)
        {
            bisCanUse = false;

            bisActtivate = true;

            fTimer = 0f;

            EffectStart();//이펙트 있는 스킬인 경우
            StartCoroutine(SkillCoolDown());
        }
        //skillTirger?.Invoke();
    }

    public void LoadEffect()
    {
        EffectPrefab = Resources.Load<GameObject>(strEffectPath + strEffectName);
    }

    public void EffectStart()
    {
        //GameObject obj = GameObject.FindWithTag("Player");
        //FirePoint = obj.transform.GetChild(3);
        //Instantiate(EffectPrefab, FirePoint.position, FirePoint.rotation);//팩토리로 바꾸기
    }
}
