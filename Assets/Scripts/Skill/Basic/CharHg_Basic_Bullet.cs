using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHg_Basic_Bullet : SkillBullet
{
    // Start is called before the first frame update
    void Start()
    {
        skillinfo = new CharHg_Basic();
        myFactory(GameManager.instance.objectFactory.CharHg_Basic_Bullet_Factory);
        EffectFactory(GameManager.instance.objectFactory.CharHGBasicEffectFactory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
