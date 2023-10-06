using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSr_Ulti_Effect : SkillEffrct
{
    CharSr_Ulti charSr_Ulti;
    void Start()
    {
        charSr_Ulti = GameObject.FindObjectOfType<CharSr_Ulti>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
