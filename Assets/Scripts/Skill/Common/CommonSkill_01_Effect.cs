using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSkill_01_Effect : SkillEffrct
{
 
    void Start()
    {
        myFactory(GameManager.instance.objectFactory.Common01EffectFactory);
    }

}
