using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanelButtonControl : MonoBehaviour
{
    public SelectCharactorUIManager charactorUIManager;
    public Skilldatas scriptable;

    float fPassiveSkillId;
    float fActiveSkillId;
    float fBasicSkillId;
    float fUltimateSkillId;
    void Start()
    {
        charactorUIManager = GameObject.Find("CharManager").GetComponent<SelectCharactorUIManager>();
        fPassiveSkillId = charactorUIManager.OwnChar[charactorUIManager.curCharID].GetComponent<Stat>().fId;
        fActiveSkillId = charactorUIManager.OwnChar[charactorUIManager.curCharID].GetComponent<Stat>().fId;
        fBasicSkillId = charactorUIManager.OwnChar[charactorUIManager.curCharID].GetComponent<Stat>().fId;
        fUltimateSkillId = charactorUIManager.OwnChar[charactorUIManager.curCharID].GetComponent<Stat>().fId;



        //GameObject s = charactorUIManager.OwnChar[charactorUIManager.curCharID];

        //foreach(SkillParameter.SkilParams skill in scriptable.Skills)
        //{
        //    if(skill.fId == s.GetComponent<Stat>().skill1)
        //    {
        //        SkillParameter.SkilParams myPassive = scriptable.Skills[];
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
