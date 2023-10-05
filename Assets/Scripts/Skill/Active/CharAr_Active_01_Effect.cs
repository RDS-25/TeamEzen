using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAr_Active_01_Effect : SkillEffrct
{
    Skill charAr_Active_01;
    void Start()
    {
        charAr_Active_01 = GameObject.FindObjectOfType<CharAr_Active_01>();
        myFactory(GameManager.instance.objectFactory.CharARActive01EffectFactory);

    }
    
    // Update is called once per frame
    void Update()
    {
    
    }
    
}
