using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory
{
    public FactoryManager basicSkillFactory = new FactoryManager();
    public FactoryManager activeSkillFactory = new FactoryManager();
    public FactoryManager test = new FactoryManager();

    // 스테이지
    public FactoryManager roomFactory = new FactoryManager();
    
    // 캐릭터
    public FactoryManager characterFactory = new FactoryManager();
    //보유 캐릭터
    public FactoryManager ownCharFactory = new FactoryManager();

    // 슬롯 만들기 고민
    public FactoryManager CharSlotFactory = new FactoryManager();
    public FactoryManager ItemSlotFactory = new FactoryManager();

    //몬스터 종류별로 만들기

    //원거리 몬스터 
    public FactoryManager MeleeMonsterFactory = new FactoryManager();
    //근거리 몬스터
    public FactoryManager RangedMonsterFactory = new FactoryManager();


    // 스킬
    public FactoryManager CharAR01BasicEffectFactory = new FactoryManager();





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
