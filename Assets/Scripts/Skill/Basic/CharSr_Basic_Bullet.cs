using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSr_Basic_Bullet : SkillBullet
{
    // Start is called before the first frame update
    void Start()
    {
        skillinfo = new CharSr_Basic();
        myFactory(GameManager.instance.objectFactory.CharSr_Basic_Bullet_Factory);
        EffectFactory(GameManager.instance.objectFactory.CharSRBasicEffectFactory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
