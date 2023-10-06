using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSkill_02_Bullet : SkillBullet
{
    // Start is called before the first frame update
    void Start()
    {
        skillinfo = new CommonSkill_02();
        myFactory(GameManager.instance.objectFactory.Common_02_BulletFactory);
        EffectFactory(GameManager.instance.objectFactory.Common02EffectFactory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
