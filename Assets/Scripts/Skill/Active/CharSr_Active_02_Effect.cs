using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSr_Active_02_Effect : SkillEffrct
{
    CharSr_Active_02 charSr_Active_02;
    void Start()
    {
        charSr_Active_02 = GameObject.FindObjectOfType<CharSr_Active_02>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
