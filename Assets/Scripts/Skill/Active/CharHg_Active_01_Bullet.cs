using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHg_Active_01_Bullet : SkillBullet
{
    // Start is called before the first frame update
    void Start()
    {
        myFactory(GameManager.instance.objectFactory.CharHg_Active_01_Bullet_Factory);
        EffectFactory(GameManager.instance.objectFactory.CharHGActive01EffectFactory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
