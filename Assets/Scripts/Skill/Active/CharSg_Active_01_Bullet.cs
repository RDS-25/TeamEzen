using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSg_Active_01_Bullet : SkillBullet
{
    // Start is called before the first frame update
    void Start()
    {
        skillinfo = new CharSg_Active_01();
        myFactory(GameManager.instance.objectFactory.CharSg_Active_01_Bullet_Factory);
        EffectFactory(GameManager.instance.objectFactory.CharSGActive01EffectFactory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
