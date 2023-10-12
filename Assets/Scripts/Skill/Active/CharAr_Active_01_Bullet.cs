using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAr_Active_01_Bullet : SkillBullet
{
    CharAr_Active_01 charAr_Active_01;
    void Start()
    {
        skillParams = GameObject.FindObjectOfType<CharAr_Active_01>();
        //나중에 수정
        skillinfo = GameManager.instance.objectFactory.AllSkill.listPool[0].GetComponent<Skill>();

        myFactory(GameManager.instance.objectFactory.CharAr_Active_01_Bullet_Factory);
        EffectFactory(GameManager.instance.objectFactory.CharARActive01EffectFactory);        
    }

    protected override void moveBullet()
    {
        base.moveBullet();
    }

 
}
