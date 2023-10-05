using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHg_Active_02_Bullet : SkillBullet
{
    // Start is called before the first frame update
    void Start()
    {
        myFactory(GameManager.instance.objectFactory.CharHg_Active_02_Bullet_Factory);
        EffectFactory(GameManager.instance.objectFactory.CharHGActive02EffectFactory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
