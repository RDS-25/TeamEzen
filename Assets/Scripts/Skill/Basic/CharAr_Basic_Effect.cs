using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAr_Basic_Effect : SkillEffrct
{
    CharAr_Basic charSr_Basic;
    void Start()
    {
        charSr_Basic = GameObject.FindObjectOfType<CharAr_Basic>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
