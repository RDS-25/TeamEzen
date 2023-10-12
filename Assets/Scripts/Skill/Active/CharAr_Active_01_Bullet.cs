using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAr_Active_01_Bullet : SkillBullet
{
    private void OnDisable()
    {
        //fMaxRange = GameObject.FindObjectOfType<CharAr_Active_01>().fMaxRange;
        //AttackCount = GameObject.FindObjectOfType<CharAr_Active_01>().fAttackCount;
        //TartgetCount = GameObject.FindObjectOfType<CharAr_Active_01>().fTargetCount;
    }
    private void OnEnable()
    {
        skillParams = GameObject.Find("CharAr_Active_01").GetComponent<CharAr_Active_01>();
        Debug.Log(skillParams.fMaxRange);
        Firepiont = GameObject.FindWithTag("Player").transform.position;
        Debug.Log(Firepiont);
    }
    void Start()
    {

        //나중에 수정
        //skillinfo = GameManager.instance.objectFactory.AllSkill.listPool[0].GetComponent<Skill>();
        //skillParams = GameObject.FindObjectOfType<CharAr_Active_01>();
        myFactory(GameManager.instance.objectFactory.CharAr_Active_01_Bullet_Factory);
        EffectFactory(GameManager.instance.objectFactory.CharARActive01EffectFactory);
    }    
}
