using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFactory
{
    private int nSize = 10;
    public FactoryManager roomFactory = new FactoryManager();
    public FactoryManager monsterFactory = new FactoryManager();
    public FactoryManager basicSkillFactory = new FactoryManager();
    public FactoryManager activeSkillFactory = new FactoryManager();
    public FactoryManager test = new FactoryManager();


    public void SelectCharacterInit()
    {

        //monsterFactory.     CreateFactory("", nSize);
        //basicSkillFactory.  CreateFactory(FilePath.STR_PREFAB_SKILL_EFFECT_1, nSize);
        //activeSkillFactory. CreateFactory("", nSize);
        //basicSkillFactory.CreateObject(basicSkillFactory.gPrefab);
        //test.CreateCharacterFactory("Prefabs/Character", 5);
    }
}
