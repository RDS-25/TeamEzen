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


    public override void SkillTriger(Vector3 Pos)
    {
        if (bisCanUse == true || bisActtivate == false)
        {
            bisCanUse = false;

            bisActtivate = true;

            fTimer = 0f;

            EffectStart(Pos);//����Ʈ �ִ� ��ų�� ���

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
        Debug.Log("����Ʈ �߻�");
        GameObject obj = GameObject.FindWithTag("Player");
        FirePoint = obj.transform.GetChild(3);

		GameObject effect = EffectFactoryManager.GetObject();
        effect.SetActive(true);
        effect.transform.position = Pos;

    }
}
