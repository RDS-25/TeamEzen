using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Bullet : SkillBullet
{
    // Start is called before the first frame update
    void Start()
    {
        myFactory(GameManager.instance.objectFactory.Char_Basic_Bullet_Factory);
        EffectFactory(GameManager.instance.objectFactory.CharBasicEffectFactory);
        switch (id)
        {
            case 1f:
                skillinfo = new CharAr_Basic();
                break;
            case 2f:
                skillinfo = new CharHg_Basic();
                break;
            case 3f:
                skillinfo = new CharSg_Basic();
                break;
            case 4f:
                skillinfo = new CharSr_Basic();
                break;                    
        }              
    }
    
}
