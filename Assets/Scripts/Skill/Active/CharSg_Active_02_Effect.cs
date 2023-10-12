using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSg_Active_02_Effect : SkillEffrct
{
    
    void OnEnable()
    {
        
        myFactory(GameManager.instance.objectFactory.CharSGActive02EffectFactory);
        EndEffect();

    }

   
   
}
