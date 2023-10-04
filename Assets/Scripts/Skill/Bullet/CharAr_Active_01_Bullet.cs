using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAr_Active_01_Bullet :SkillBullet
{
    // Start is called before the first frame update
    void Start()
    {
        myFactory(GameManager.instance.objectFactory.BulletFactory);
        EffectFactory(GameManager.instance.objectFactory.CharARActive01EffectFactory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
