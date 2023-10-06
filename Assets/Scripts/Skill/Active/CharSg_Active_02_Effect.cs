using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSg_Active_02_Effect : SkillEffrct
{
    CharSg_Active_02 charSg_Active_02;
    void Start()
    {
        charSg_Active_02 = GameObject.FindObjectOfType<CharSg_Active_02>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
