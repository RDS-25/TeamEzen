using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSr_Active_02_Effect : SkillEffrct
{
    
    void OnEnable()
    {
        
        myFactory(GameManager.instance.objectFactory.CharSRActive02EffectFactory);
        EndEffect();
    }

}
