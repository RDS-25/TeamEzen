using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSkill_04_Bullet : SkillBullet
{
    // Start is called before the first frame update
    void Start()
    {
        skillinfo = new CommonSkill_04();
        myFactory(GameManager.instance.objectFactory.Common_04_BulletFactory);
        EffectFactory(GameManager.instance.objectFactory.Common04EffectFactory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
