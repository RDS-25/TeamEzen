using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSr_Active_01_Effect : SkillEffrct
{
    CharSr_Active_01 charSr_Active_01;
    void Start()
    {
        charSr_Active_01 = GameObject.FindObjectOfType<CharSr_Active_01>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
