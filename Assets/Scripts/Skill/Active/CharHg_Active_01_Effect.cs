using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHg_Active_01_Effect : SkillEffrct
{
    CharHg_Active_01 charHg_Active_01;
    void Start()
    {
        charHg_Active_01 = GameObject.FindObjectOfType<CharHg_Active_01>();
        myFactory(GameManager.instance.objectFactory.CharHGActive01EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
