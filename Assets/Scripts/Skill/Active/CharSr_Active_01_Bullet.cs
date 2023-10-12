using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSr_Active_01_Bullet : SkillBullet
{
    // Start is called before the first frame update
    void Start()
    {
        skillParams = GameObject.FindObjectOfType<CharSr_Active_01>();
        myFactory(GameManager.instance.objectFactory.CharSr_Active_01_Bullet_Factory);
        EffectFactory(GameManager.instance.objectFactory.CharSRActive01EffectFactory);
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
