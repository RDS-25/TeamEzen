using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAr_Ulti_Effect : SkillEffrct
{
    CharAr_Ulti charAr_Ulti;
    void Start()
    {
        charAr_Ulti = GameObject.FindObjectOfType<CharAr_Ulti>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
