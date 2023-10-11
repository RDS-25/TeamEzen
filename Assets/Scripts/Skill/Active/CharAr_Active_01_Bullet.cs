using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAr_Active_01_Bullet : SkillBullet
{
    
    void Start()
    {

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
