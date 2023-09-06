using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory
{
    public FactoryManager basicSkillFactory = new FactoryManager();
    public FactoryManager activeSkillFactory = new FactoryManager();
    public FactoryManager test = new FactoryManager();

    // ��������
    public FactoryManager roomFactory = new FactoryManager();
    
    // ĳ����
    public FactoryManager characterFactory = new FactoryManager();
    //���� ĳ����
    public FactoryManager ownCharFactory = new FactoryManager();

    // ���� ����� ���
    public FactoryManager CharSlotFactory = new FactoryManager();
    public FactoryManager ItemSlotFactory = new FactoryManager();

    //���� �������� �����

    //���Ÿ� ���� 
    public FactoryManager MeleeMonsterFactory = new FactoryManager();
    //�ٰŸ� ����
    public FactoryManager RangedMonsterFactory = new FactoryManager();


    // ��ų
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
