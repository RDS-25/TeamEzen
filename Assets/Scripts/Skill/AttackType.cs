using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;
using System;
using System.IO;
public class AttackType : Skill
{
    public Transform FirePoint;


    //��ų������ ������ ��ų���� ���ֱ�
    public override void ShotEffect(Vector3 Bulletpos)
    {
        GameObject bullet = myFactory.GetObject();
        bullet.transform.position = Bulletpos;
        bullet.SetActive(true);
    }

    public override void SetType()
    {
        skillDetail = "ATTACK";//��ųʸ� ����� ����
        enumSkillDetail = SkillDetailType.ATTACK;
    }
    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
        fAttackCount += plusattackcount;//Ÿ��Ƚ�� ����
        fTargetCount += plustargetcount;//Ÿ�ټ� ����
    }   

    
}
