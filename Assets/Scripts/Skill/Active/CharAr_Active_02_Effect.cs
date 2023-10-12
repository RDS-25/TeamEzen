using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAr_Active_02_Effect : SkillEffrct
{
    
    void OnEnable()
    {        
        myFactory(GameManager.instance.objectFactory.CharARActive02EffectFactory);
        EndEffect();
    }

}
