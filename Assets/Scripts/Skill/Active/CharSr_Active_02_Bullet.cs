using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSr_Active_02_Bullet : SkillBullet
{
    // Start is called before the first frame update
    void Start()
    {
        skillinfo = new CharSr_Active_02();        
        myFactory(GameManager.instance.objectFactory.CharSr_Active_02_Bullet_Factory);
        EffectFactory(GameManager.instance.objectFactory.CharSRActive02EffectFactory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
