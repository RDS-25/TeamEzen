using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Effect : SkillEffrct
{
    void OnEnable()
    {        
        myFactory(GameManager.instance.objectFactory.CharBasicEffectFactory);
        EndEffect();
    }
}
