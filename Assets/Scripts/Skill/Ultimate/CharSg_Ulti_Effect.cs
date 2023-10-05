using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSg_Ulti_Effect : SkillEffrct
{
    CharSg_Ulti charSg_Ulti;
    void Start()
    {
        charSg_Ulti = GameObject.FindObjectOfType<CharSg_Ulti>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
