using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSr_Active_03_Effect : SkillEffrct
{
    CharSr_Active_03 charSr_Active_03;
    void Start()
    {
        charSr_Active_03 = GameObject.FindObjectOfType<CharSr_Active_03>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
