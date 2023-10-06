using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSg_Active_02_Bullet : SkillBullet
{
    // Start is called before the first frame update
    void Start()
    {
        skillinfo = new CharSg_Active_02();
        myFactory(GameManager.instance.objectFactory.CharSg_Active_02_Bullet_Factory);
        EffectFactory(GameManager.instance.objectFactory.CharSGActive02EffectFactory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
