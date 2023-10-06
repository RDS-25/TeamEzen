using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSg_Active_03_Effect : SkillEffrct
{
    CharSg_Active_03 charSg_Active_03;
    void Start()
    {
        charSg_Active_03 = GameObject.FindObjectOfType<CharSg_Active_03>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
