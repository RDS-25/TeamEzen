using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSkill_03_Bullet : SkillBullet
{
    // Start is called before the first frame update
    void Start()
    {
        myFactory(GameManager.instance.objectFactory.Common_03_BulletFactory);
        EffectFactory(GameManager.instance.objectFactory.Common03EffectFactory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
