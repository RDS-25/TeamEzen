using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSg_Basic_Effect : SkillEffrct
{
    
    void Start()
    {        
        myFactory(GameManager.instance.objectFactory.CharSGBasicEffectFactory);
    }

}
