using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHg_Active_01_Effect : SkillEffrct
{
    
    void OnEnable()
    {
        
        myFactory(GameManager.instance.objectFactory.CharHGActive01EffectFactory);
        EndEffect();
    }

}
