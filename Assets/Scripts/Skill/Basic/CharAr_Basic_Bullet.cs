using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAr_Basic_Bullet : SkillBullet
{
    // Start is called before the first frame update
    void Start()
    {
        skillinfo = new CharAr_Basic();
        myFactory(GameManager.instance.objectFactory.CharAr_Basic_Bullet_Factory);
        EffectFactory(GameManager.instance.objectFactory.CharARBasicEffectFactory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
