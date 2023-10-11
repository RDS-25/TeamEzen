using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;
using System;
using System.IO;
public class AttackType : Skill
{
    public Transform FirePoint;


    //스킬레벨업 변수들 스킬마다 써주기
    public override void ShotEffect(Vector3 Bulletpos)
    {
        GameObject bullet = myFactory.GetObject();
        bullet.transform.position = Bulletpos;
        bullet.SetActive(true);
    }

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

    
}
