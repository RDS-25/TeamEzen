using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHg_Active_02_Effect : SkillEffrct
{
    CharHg_Active_02 charHg_Active_02;
    void Start()
    {
        charHg_Active_02 = GameObject.FindObjectOfType<CharHg_Active_02>();
        myFactory(GameManager.instance.objectFactory.CharHGActive02EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
