using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSg_Active_01_Effect : SkillEffrct
{
    
    void Start()
    {        
        myFactory(GameManager.instance.objectFactory.CharSGActive01EffectFactory);
    }

}
