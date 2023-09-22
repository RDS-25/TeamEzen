using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Ex_Active1Effect : SkillEffrct
{

    //public Charater1 Charater1;
    //public Ex_Active1Skill ex_Active1Skill;
    Rigidbody rig;
    

    private void OnDisable()
    {
        ChaStat = null;
    }


    void Start()
    {
        rig = GetComponent<Rigidbody>();
        fSpeed = 100f;
        myFactory(GameManager.instance.objectFactory.CharARActive01EffectFactory);
        //MoveEffect();
        fRancri = UnityEngine.Random.Range(0f, 100f);
        fRanmondod = UnityEngine.Random.Range(0f, 100f);
        Firepiont = gameObject.GetComponent<Transform>().position;
    }
    
    //public override float CheckPro(float Attacker, float Defender)
    //{
    //    return base.CheckPro(Attacker, Defender);
    //}
    //public float CalculDamage(float chadam, float chacriper, float chacridam, float chadefenpier, float Attacker,
    //    float mondadge, float moncrire, float mondefen, float Defender)
    //{
    //    return base.CalculDamage(chadam, chacriper, chacridam, chadefenpier, Attacker, mondadge, moncrire, mondefen, Defender);
    //}
    //public override float CalculDamage()
    //{
    //    if (fRanmondod < fMonDadge)//������ ȸ�Ǽ�����
    //    {
    //        Debug.Log("ȸ��+"+(fRanmondod - fMonDadge));
    //        float calculdamage = 0;
    //        fTotalDamage = calculdamage;
    //        //������ �ؽ�Ʈ
    //        Debug.Log("������"+fTotalDamage);
    //        return fTotalDamage;
    //    }
    //    else//������ ȸ�ǽ��н�
    //    {
    //        if (fRancri <= Charater1.critical - fMonCriresi)//ũ��Ƽ���� ���
    //        {
    //            float calculdamage =
    //                (Charater1.damage *(100+ Charater1.criticaldamage)/100 *
    //                (fMonDefense - Charater1.defensepierce) / (fMonDefense + 100));
    //            fTotalDamage = calculdamage;
    //            Debug.Log(fTotalDamage);
    //            return fTotalDamage;
    //        }
    //        else//ũ��Ƽ���� �ƴҰ��
    //        {
    //            float calculdamage = Charater1.damage * (fMonDefense - Charater1.defensepierce) / (fMonDefense + 100);
    //            fTotalDamage = calculdamage;
    //            Debug.Log(fTotalDamage);
    //            return fTotalDamage;
    //        }//�Ӽ�???
    //    }

    //}
    public override void CheckDistance(Vector3 firepoint, float range)
    {
        
        float distance = Vector3.Distance(Firepiont, this.transform.position);
        Debug.Log("ran" + range);
        Debug.Log("dis"+ distance);
       // Debug.Log("ran" + Ex_Active1Skill.Ex_Active1Params.fRange);
        if (distance > range)//Ex_Active1Params�� Range�� �������� ���??
        {

            Destroy(this.gameObject);
        }
        else
            return;
    }
    public override void MoveEffect()
    {
        rig.AddForce(transform.forward * fSpeed * Time.deltaTime);
        Debug.Log("sad");
    }
    void Update()
    {
        MoveEffect();
        //CheckDistance(Firepiont, ex_Active1Skill.fRange);
    }
}
