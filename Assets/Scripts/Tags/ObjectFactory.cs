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
    public FactoryManager SelectingSkillSlotFactory = new FactoryManager();

    //���� �������� �����

    //�ٰŸ� ����
    public FactoryManager MeleeMonsterFactory = new FactoryManager();
    //���Ÿ�
    public FactoryManager RangedMonsterFactory = new FactoryManager();


    // ��ų
    public FactoryManager AllSkill = new FactoryManager();
    public FactoryManager CharAR01BasicEffectFactory = new FactoryManager();
    public FactoryManager SelectingSkillObjectFactory = new FactoryManager();

    // ������
    public FactoryManager ItemObjectFactory = new FactoryManager();
    public FactoryManager SetItemFactory = new FactoryManager();

    // ��ͷ�
    public FactoryManager MonsterRoomFactory = new FactoryManager();
    public FactoryManager GimmickRoomFactory = new FactoryManager();

    public void InitFactory()
	{
        // ĳ����
		characterFactory.CreateFactory(FolderPath.PREFABS_CHARACTER);
        MeleeMonsterFactory.CreateFactory(FolderPath.PREFABS_ENEMY);
        
        SelectCharacterInit();

        // ��ų
        SelectingSkillObjectFactory.CreateFactory(FolderPath.PREFABS_ACTIVE_SKILL);
        SelectingSkillObjectFactory.CreateObject(Resources.LoadAll<GameObject>(FolderPath.PREFABS_COMMON_SKILL));
        AllSkill.CreateFactory(FolderPath.PREFABS_SKILL);

        // ����
        CharSlotFactory.CreateFactory(FolderPath.PREFABS_CHAR_SLOT + PrefabName.STR_SLOT_PREFAB
                            , characterFactory.listPool.Count);
        OrganizingSlotFactory.CreateFactory(FolderPath.PREFABS_CHAR_SLOT + PrefabName.STR_SLOT_PREFAB
                                            , characterFactory.listPool.Count);
        SelectingSkillSlotFactory.CreateFactory(FolderPath.PREFABS_SKILL_SLOT + PrefabName.STR_SKILL_SLOT);

        // ��ͷ�
        MonsterRoomFactory.CreateFactory(FolderPath.PREFABS_ROOM + PrefabName.STR_MONSTER_ROOM, 15);
        GimmickRoomFactory.CreateFactory(FolderPath.PREFABS_ROOM + PrefabName.STR_PUZZLE_ROOM, 5);
        GimmickRoomFactory.CreateObject(FolderPath.PREFABS_ROOM + PrefabName.STR_TRAP_ROOM, 5);
        GimmickRoomFactory.CreateObject(FolderPath.PREFABS_ROOM + PrefabName.STR_STORE_ROOM, 1);
    }
    public void SlotInit()
    {
        CharSlotFactory.DeCreatePool();
        OrganizingSlotFactory.DeCreatePool();
        SelectingSkillSlotFactory.DeCreatePool();
        CharSlotFactory.CreateFactory(FolderPath.PREFABS_CHAR_SLOT + PrefabName.STR_SLOT_PREFAB
                            , characterFactory.listPool.Count);
        OrganizingSlotFactory.CreateFactory(FolderPath.PREFABS_CHAR_SLOT + PrefabName.STR_SLOT_PREFAB
                                            , characterFactory.listPool.Count);
        SelectingSkillSlotFactory.CreateFactory(FolderPath.PREFABS_SKILL_SLOT + PrefabName.STR_SKILL_SLOT
                            , SelectingSkillObjectFactory.listPool.Count);
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
