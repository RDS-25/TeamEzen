using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSr_Basic_Effect : SkillEffrct
{
    CharSr_Basic charSr_Basic;
    void Start()
    {
        charSr_Basic = GameObject.FindObjectOfType<CharSr_Basic>();
        myFactory(GameManager.instance.objectFactory.CharHGActive03EffectFactory);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
