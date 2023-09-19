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

    //��ų������ ������ ��ų���� ���ֱ�


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


    public override void SkillTriger()
    {
        if (bisCanUse == true || bisActtivate == false)
        {
            bisCanUse = false;

            bisActtivate = true;

            fTimer = 0f;

            EffectStart();//����Ʈ �ִ� ��ų�� ���
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
        //Instantiate(EffectPrefab, FirePoint.position, FirePoint.rotation);//���丮�� �ٲٱ�
    }
}
