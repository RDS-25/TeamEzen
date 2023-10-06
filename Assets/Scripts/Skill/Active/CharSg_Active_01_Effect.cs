using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSg_Active_01_Effect : SkillEffrct
{
    CharSg_Active_01 charSg_Active_01;
    void Start()
    {
        charSg_Active_01 = GameObject.FindObjectOfType<CharSg_Active_01>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
