using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSg_Basic_Bullet : SkillBullet
{
    // Start is called before the first frame update
    void Start()
    {
        skillinfo = new CharSg_Basic();
        myFactory(GameManager.instance.objectFactory.CharSg_Basic_Bullet_Factory);
        EffectFactory(GameManager.instance.objectFactory.CharSGBasicEffectFactory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
