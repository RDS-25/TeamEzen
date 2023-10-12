using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHg_Active_02_Effect : SkillEffrct
{
    
    void OnEnable()
    {
        
        myFactory(GameManager.instance.objectFactory.CharHGActive02EffectFactory);
        EndEffect();
    }    
}
