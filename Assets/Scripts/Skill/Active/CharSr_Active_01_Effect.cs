using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSr_Active_01_Effect : SkillEffrct
{
    
    void Start()
    {
    
        myFactory(GameManager.instance.objectFactory.CharSRActive01EffectFactory);

    }

}
