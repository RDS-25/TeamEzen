using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;
using System;
using System.IO;
public class AttackType : Skill
{
    public Transform FirePoint;
    public FactoryManager EffectFactoryManager;

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


    public override void SkillTriger(Vector3 Pos)
    {
        if (bisCanUse == true || bisActtivate == false)
        {
            bisCanUse = false;

            bisActtivate = true;

            fTimer = 0f;

            EffectStart(Pos);//이펙트 있는 스킬인 경우

            StartCoroutine(SkillCoolDown());
        }
        //skillTirger?.Invoke();
    }

    public void LoadEffect(FactoryManager factoryManager)
    {
        EffectFactoryManager = factoryManager;
    }

    public void EffectStart(Vector3 Pos)
    {
        Debug.Log("이펙트 발사");
        GameObject obj = GameObject.FindWithTag("Player");
        FirePoint = obj.transform.GetChild(3);

		GameObject effect = EffectFactoryManager.GetObject();
        effect.SetActive(true);
        effect.transform.position = Pos;

    }
}
