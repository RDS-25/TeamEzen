using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSg_Basic_Effect : SkillEffrct
{
    CharSg_Basic charSg_Basic;
    void Start()
    {
        charSg_Basic = GameObject.FindObjectOfType<CharSg_Basic>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
