using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSkill_01_Bullet : SkillBullet
{
    // Start is called before the first frame update
    void Start()
    {
        skillinfo = new CommonSkill_01();       
        myFactory(GameManager.instance.objectFactory.Common_01_BulletFactory);
        EffectFactory(GameManager.instance.objectFactory.Common01EffectFactory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
