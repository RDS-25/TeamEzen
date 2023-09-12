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
    public FactoryManager OrganizingSlotFactory = new FactoryManager();
    public FactoryManager ItemSlotFactory = new FactoryManager();

    //���� �������� �����

    //���Ÿ� ���� 
    public FactoryManager MeleeMonsterFactory = new FactoryManager();
    //�ٰŸ� ����
    public FactoryManager RangedMonsterFactory = new FactoryManager();


    // ��ų
    public FactoryManager CharAR01BasicEffectFactory = new FactoryManager();

    // ������
    public FactoryManager ItemObjectFactory = new FactoryManager();
    public FactoryManager SetItemFactory = new FactoryManager();

    public void InitFactory()
    {
        characterFactory.CreateFactory(FolderPath.PREFABS_CHARACTER);
        SelectCharacterInit();
        CharSlotFactory.CreateFactory(FolderPath.PREFABS_CHAR_SLOT + PrefabName.STR_SLOT_PREFAB
                                    , characterFactory.listPool.Count);
        OrganizingSlotFactory.CreateFactory(FolderPath.PREFABS_CHAR_SLOT + PrefabName.STR_SLOT_PREFAB
                                            , characterFactory.listPool.Count);

    }

    public void SelectCharacterInit()
    {
        List<string> list = new();
        List<Dictionary<string, string>> listTemp = GameManager.instance.DataReadAll(FolderPath.PARAMS_CHARACTER);
        foreach (Dictionary<string, string> dictTemp in listTemp)
        {
            if (dictTemp[CharPath.ISOWN] == "True")
            {
                list.Add(dictTemp[CharPath.ID]);
            }
        }


        for (int i = 0; i < characterFactory.listPool.Count; i++)
        {
            for (int j = 0; j < list.Count; j++)
            {
                if (characterFactory.listPool[i].GetComponent<Stat>().fId == float.Parse(list[j]))
                    ownCharFactory.listPool.Add(characterFactory.listPool[i]);
            }
        }
    }


}
