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
    public FactoryManager OrganizingSlotFactory = new FactoryManager();
    public FactoryManager ItemSlotFactory = new FactoryManager();
    public FactoryManager SelectingSkillSlotFactory = new FactoryManager();

    //몬스터 종류별로 만들기

    //근거리 몬스터
    public FactoryManager MeleeMonsterFactory = new FactoryManager();
    //원거리
    public FactoryManager RangedMonsterFactory = new FactoryManager();


    // 스킬
    public FactoryManager AllSkill = new FactoryManager();
    public FactoryManager SelectingSkillObjectFactory = new FactoryManager();

    public FactoryManager CharBasicEffectFactory = new FactoryManager();

    public FactoryManager CharARActive01EffectFactory = new FactoryManager();
    public FactoryManager CharARActive02EffectFactory = new FactoryManager();
    public FactoryManager CharARActive03EffectFactory = new FactoryManager();

    public FactoryManager CharSRActive01EffectFactory = new FactoryManager();
    public FactoryManager CharSRActive02EffectFactory = new FactoryManager();
    public FactoryManager CharSRActive03EffectFactory = new FactoryManager();

    public FactoryManager CharHGActive01EffectFactory = new FactoryManager();
    public FactoryManager CharHGActive02EffectFactory = new FactoryManager();
    public FactoryManager CharHGActive03EffectFactory = new FactoryManager();

    public FactoryManager CharSGActive01EffectFactory = new FactoryManager();
    public FactoryManager CharSGActive02EffectFactory = new FactoryManager();
    public FactoryManager CharSGActive03EffectFactory = new FactoryManager();

    public FactoryManager Common01EffectFactory = new FactoryManager();
    public FactoryManager Common02EffectFactory = new FactoryManager();
    public FactoryManager Common03EffectFactory = new FactoryManager();
    public FactoryManager Common04EffectFactory = new FactoryManager();

    //총알
    public FactoryManager BulletFactory = new FactoryManager();

    public FactoryManager Char_Basic_Bullet_Factory = new FactoryManager();

    public FactoryManager CharAr_Active_01_Bullet_Factory = new FactoryManager();
    public FactoryManager CharAr_Active_02_Bullet_Factory = new FactoryManager();
    public FactoryManager CharAr_Active_03_Bullet_Factory = new FactoryManager();

    public FactoryManager CharHg_Active_01_Bullet_Factory = new FactoryManager();
    public FactoryManager CharHg_Active_02_Bullet_Factory = new FactoryManager();
    public FactoryManager CharHg_Active_03_Bullet_Factory = new FactoryManager();

    public FactoryManager CharSg_Active_01_Bullet_Factory = new FactoryManager();
    public FactoryManager CharSg_Active_02_Bullet_Factory = new FactoryManager();
    public FactoryManager CharSg_Active_03_Bullet_Factory = new FactoryManager();

    public FactoryManager CharSr_Active_01_Bullet_Factory = new FactoryManager();
    public FactoryManager CharSr_Active_02_Bullet_Factory = new FactoryManager();
    public FactoryManager CharSr_Active_03_Bullet_Factory = new FactoryManager();

    public FactoryManager Common_01_BulletFactory = new FactoryManager();
    public FactoryManager Common_02_BulletFactory = new FactoryManager();
    public FactoryManager Common_03_BulletFactory = new FactoryManager();
    public FactoryManager Common_04_BulletFactory = new FactoryManager();

    public FactoryManager CharAr_Ultimate_Bullet_Factory = new FactoryManager();
    public FactoryManager CharHg_Ultimate_Bullet_Factory = new FactoryManager();
    public FactoryManager CharSg_Ultimate_Bullet_Factory = new FactoryManager();
    public FactoryManager CharSr_Ultimate_Bullet_Factory = new FactoryManager();



    // 아이템
    public FactoryManager ItemObjectFactory = new FactoryManager();
    public FactoryManager SetItemFactory = new FactoryManager();

    // 기믹룸
    public FactoryManager MonsterRoomFactory = new FactoryManager();
    public FactoryManager GimmickRoomFactory = new FactoryManager();

    public void InitFactory()
	{
        // 캐릭터
		characterFactory.CreateFactory(FolderPath.PREFABS_CHARACTER);
        MeleeMonsterFactory.CreateFactory(FolderPath.PREFABS_ENEMY + PrefabName.STR_MELEE_MONSTER, 15);
        RangedMonsterFactory.CreateFactory(FolderPath.PREFABS_ENEMY + PrefabName.STR_RANGED_MONSTER, 15);
        SelectCharacterInit();
        SelectingSkillInit();
        // 슬롯
        CharSlotFactory.CreateFactory(FolderPath.PREFABS_CHAR_SLOT + PrefabName.STR_SLOT_PREFAB
                            , characterFactory.listPool.Count);
        OrganizingSlotFactory.CreateFactory(FolderPath.PREFABS_CHAR_SLOT + PrefabName.STR_SLOT_PREFAB
                            , characterFactory.listPool.Count);
        SelectingSkillSlotFactory.CreateFactory(FolderPath.PREFABS_SKILL_SLOT + PrefabName.STR_SKILL_SLOT
                            , SelectingSkillObjectFactory.listPool.Count);
        GimmickRoomInit();
        SkillEffectInit();
        SkillBulletInit();        
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
    public void GimmickRoomInit()
    {
        // 기믹룸
        MonsterRoomFactory.CreateFactory(FolderPath.PREFABS_ROOM + PrefabName.STR_MONSTER_ROOM, 15);
        GimmickRoomFactory.CreateObject(FolderPath.PREFABS_ROOM + PrefabName.STR_TRAP_ROOM, 5);
        GimmickRoomFactory.CreateObject(FolderPath.PREFABS_ROOM + PrefabName.STR_STORE_ROOM, 1);
    }
    public void SelectingSkillInit()
    {
        SelectingSkillObjectFactory.CreateFactory(FolderPath.PREFABS_ACTIVE_SKILL);
        SelectingSkillObjectFactory.CreateObject(FolderPath.PREFABS_BUFF_SKILL);
        SelectingSkillObjectFactory.CreateObject(FolderPath.PREFABS_COMMON_SKILL);
        AllSkill.CreateFactory(FolderPath.PREFABS_SKILL);

    }
    public void SkillEffectInit()
    {
        CharBasicEffectFactory.CreateObject(FolderPath.PREFABS_BASIC_EFFECT + PrefabName.STR_CHAR_BASIC_EFFECT, 5);

        CharARActive01EffectFactory.CreateObject(FolderPath.PREFABS_ACTIVE_EFFECT + PrefabName.STR_CHAR_AR_ACTIVE_01EFFECT, 5);
        CharARActive02EffectFactory.CreateObject(FolderPath.PREFABS_ACTIVE_EFFECT + PrefabName.STR_CHAR_AR_ACTIVE_02EFFECT, 5);
        CharARActive03EffectFactory.CreateObject(FolderPath.PREFABS_ACTIVE_EFFECT + PrefabName.STR_CHAR_AR_ACTIVE_03EFFECT, 5);

        CharSRActive01EffectFactory.CreateObject(FolderPath.PREFABS_ACTIVE_EFFECT + PrefabName.STR_CHAR_SR_ACTIVE_01EFFECT, 5);
        CharSRActive02EffectFactory.CreateObject(FolderPath.PREFABS_ACTIVE_EFFECT + PrefabName.STR_CHAR_SR_ACTIVE_02EFFECT, 5);
        CharSRActive03EffectFactory.CreateObject(FolderPath.PREFABS_ACTIVE_EFFECT + PrefabName.STR_CHAR_SR_ACTIVE_03EFFECT, 5);

        CharHGActive01EffectFactory.CreateObject(FolderPath.PREFABS_ACTIVE_EFFECT + PrefabName.STR_CHAR_HG_ACTIVE_01EFFECT, 5);
        CharHGActive02EffectFactory.CreateObject(FolderPath.PREFABS_ACTIVE_EFFECT + PrefabName.STR_CHAR_HG_ACTIVE_02EFFECT, 5);
        CharHGActive03EffectFactory.CreateObject(FolderPath.PREFABS_ACTIVE_EFFECT + PrefabName.STR_CHAR_HG_ACTIVE_03EFFECT, 5);

        CharSGActive01EffectFactory.CreateObject(FolderPath.PREFABS_ACTIVE_EFFECT + PrefabName.STR_CHAR_SG_ACTIVE_01EFFECT, 5);
        CharSGActive02EffectFactory.CreateObject(FolderPath.PREFABS_ACTIVE_EFFECT + PrefabName.STR_CHAR_SG_ACTIVE_02EFFECT, 5);
        CharSGActive03EffectFactory.CreateObject(FolderPath.PREFABS_ACTIVE_EFFECT + PrefabName.STR_CHAR_SG_ACTIVE_03EFFECT, 5);

        Common01EffectFactory.CreateObject(FolderPath.PREFABS_COMMON_EFFECT + PrefabName.STR_COMMON_01EFFECT, 5);
        Common02EffectFactory.CreateObject(FolderPath.PREFABS_COMMON_EFFECT + PrefabName.STR_COMMON_02EFFECT, 5);
        Common03EffectFactory.CreateObject(FolderPath.PREFABS_COMMON_EFFECT + PrefabName.STR_COMMON_03EFFECT, 5);
        Common04EffectFactory.CreateObject(FolderPath.PREFABS_COMMON_EFFECT + PrefabName.STR_COMMON_04EFFECT, 5);
    }
    public void SkillBulletInit()
    {
        CharAr_Active_01_Bullet_Factory.CreateObject(FolderPath.PREFABS_ACTIVE_BULLET + PrefabName.STR_CHA_AR_ACTIVE_01_BULLET, 5);
        CharAr_Active_02_Bullet_Factory.CreateObject(FolderPath.PREFABS_ACTIVE_BULLET + PrefabName.STR_CHA_AR_ACTIVE_02_BULLET, 5);
        CharHg_Active_01_Bullet_Factory.CreateObject(FolderPath.PREFABS_ACTIVE_BULLET + PrefabName.STR_CHA_HG_ACTIVE_01_BULLET, 5);
        CharHg_Active_02_Bullet_Factory.CreateObject(FolderPath.PREFABS_ACTIVE_BULLET + PrefabName.STR_CHA_HG_ACTIVE_02_BULLET, 5);
        CharSg_Active_01_Bullet_Factory.CreateObject(FolderPath.PREFABS_ACTIVE_BULLET + PrefabName.STR_CHA_SG_ACTIVE_01_BULLET, 5);
        CharSg_Active_02_Bullet_Factory.CreateObject(FolderPath.PREFABS_ACTIVE_BULLET + PrefabName.STR_CHA_SG_ACTIVE_02_BULLET, 5);
        CharSr_Active_01_Bullet_Factory.CreateObject(FolderPath.PREFABS_ACTIVE_BULLET + PrefabName.STR_CHA_SR_ACTIVE_01_BULLET, 5);
        CharSr_Active_02_Bullet_Factory.CreateObject(FolderPath.PREFABS_ACTIVE_BULLET + PrefabName.STR_CHA_SR_ACTIVE_02_BULLET, 5);
        Char_Basic_Bullet_Factory.CreateObject(FolderPath.PREFABS_BASIC_BULLET + PrefabName.STR_CHA_BASIC_BULLET, 5);        
        CharAr_Ultimate_Bullet_Factory.CreateObject(FolderPath.PREFABS_ULTIMATE_BULLET + PrefabName.STR_CHA_AR_ULTIMATE_BULLET, 1);
        CharAr_Ultimate_Bullet_Factory.CreateObject(FolderPath.PREFABS_ULTIMATE_BULLET + PrefabName.STR_CHA_HG_ULTIMATE_BULLET, 1);
        CharAr_Ultimate_Bullet_Factory.CreateObject(FolderPath.PREFABS_ULTIMATE_BULLET + PrefabName.STR_CHA_SG_ULTIMATE_BULLET, 1);
        CharAr_Ultimate_Bullet_Factory.CreateObject(FolderPath.PREFABS_ULTIMATE_BULLET + PrefabName.STR_CHA_SR_ULTIMATE_BULLET, 1);
        Common_01_BulletFactory.CreateObject(FolderPath.PREFABS_COMMON_BULLET + PrefabName.STR_COMMON_01_BULLET, 5);
        Common_02_BulletFactory.CreateObject(FolderPath.PREFABS_COMMON_BULLET + PrefabName.STR_COMMON_02_BULLET, 5);
        Common_03_BulletFactory.CreateObject(FolderPath.PREFABS_COMMON_BULLET + PrefabName.STR_COMMON_03_BULLET, 5);
        Common_04_BulletFactory.CreateObject(FolderPath.PREFABS_COMMON_BULLET + PrefabName.STR_COMMON_04_BULLET, 5);
    }
}
