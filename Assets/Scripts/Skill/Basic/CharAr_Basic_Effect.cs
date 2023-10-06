using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAr_Basic_Effect : SkillEffrct
{
    
    void Start()
    {
        
        myFactory(GameManager.instance.objectFactory.CharARBasicEffectFactory);      
    }

}
