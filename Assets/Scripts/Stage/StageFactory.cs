using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFactory
{
    public FactoryManager basicSkillFactory = new FactoryManager();
    public FactoryManager activeSkillFactory = new FactoryManager();
    public FactoryManager test = new FactoryManager();

    // 스테이지
    public FactoryManager roomFactory = new FactoryManager();

    // 캐릭터
    public FactoryManager characterFactory = new FactoryManager();
    public FactoryManager monsterFactory = new FactoryManager();

    // 스킬
    public FactoryManager skill1EffectFactory = new FactoryManager();
    public void SelectCharacterInit()
    {

        characterFactory.CreateFactory(FolderPath.PREFABS_CHARACTER);
        //roomFactory.CreateFactory()

        //monsterFactory.     CreateFactory("", nSize);
        //basicSkillFactory.  CreateFactory(FilePath.STR_PREFAB_SKILL_EFFECT_1, nSize);
        //activeSkillFactory. CreateFactory("", nSize);
        //basicSkillFactory.CreateObject(basicSkillFactory.gPrefab);
        //test.CreateCharacterFactory("Prefabs/Character", 5);
    }
}
