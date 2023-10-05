using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAr_Active_02_Effect : SkillEffrct
{
    CharAr_Active_02 charAr_Active_02 ;
    void Start()
    {
        charAr_Active_02 = GameObject.FindObjectOfType<CharAr_Active_02>();
        myFactory(GameManager.instance.objectFactory.CharARActive02EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
