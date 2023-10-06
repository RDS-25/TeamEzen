using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderPath
{
    // Json
    public const string MAIN_ROOT               = "D:/MyProject";

    public const string PARAMS                  = MAIN_ROOT + "/Params/";
    public const string PARAMS_CHARACTER        = PARAMS + "CharacterParams/";
    public const string PARAMS_MONSTER          = PARAMS + "MonsterParams/";

    public const string PARAMS_GAMEMANAGER      = PARAMS + "GameManagerParams/";
    public const string PARAMS_SOUND            = PARAMS + "SoundParams/";
    public const string PARAMS_GRAPHIC          = PARAMS + "GraphicParams/";

    public const string PARAMS_SKILL            = PARAMS + "SkillParams/";
    public const string PARAMS_PASSIVE_SKILL    = PARAMS_SKILL + "PassiveSkill/";
    public const string PARAMS_ACTIVE_SKILL     = PARAMS_SKILL + "ActiveSkill/";
    public const string PARAMS_ULTIMATE_SKILL   = PARAMS_SKILL + "UltimateSkill/";
    public const string PARAMS_BASIC_SKILL      = PARAMS_SKILL + "BasicSkill/";
    public const string PARAMS_COMMON_SKILL    = PARAMS_SKILL + "CommonSkill/";

    public const string PARAMS_ITEM             = PARAMS + "Item/";
    public const string PARAMS_ITEM_COUNT       = PARAMS_ITEM + "ItemCount/"; 


    // Resources 
    public const string PREFABS                 = "Prefabs/";
    public const string PREFABS_CHARACTER       = PREFABS + "Characters/";
    public const string PREFABS_CHAR_SLOT       = PREFABS + "Slot/";

    public const string PREFABS_ENEMY           = PREFABS + "Enemy/";

    public const string PREFABS_SKILL_SLOT      = PREFABS + "Slot/";
    public const string PREFABS_SKILL           = PREFABS + "Skill/";
    public const string PREFABS_ACTIVE_SKILL    = PREFABS_SKILL + "ActiveSkill/";
    public const string PREFABS_BASIC_SKILL     = PREFABS_SKILL + "BasicSkil/";
    public const string PREFABS_BUFF_SKILL      = PREFABS_SKILL + "BuffSkill/";
    public const string PREFABS_COMMON_SKILL    = PREFABS_SKILL + "CommonSkill/";
    public const string PREFABS_PASSIVE_SKILL   = PREFABS_SKILL + "PassiveSkill/";
    public const string PREFABS_ULTIMATE_SKILL  = PREFABS_SKILL + "UltimateSkill/";

    public const string PREFABS_SKILL_EFFECT    = PREFABS + "SkillEffects/";
    public const string PREFABS_ACTIVE_EFFECT   = PREFABS_SKILL_EFFECT + "ActiveEffects/";
    public const string PREFABS_BASIC_EFFECT    = PREFABS_SKILL_EFFECT + "BasicEffects/";
    public const string PREFABS_ULTIMATE_EFFECT = PREFABS_SKILL_EFFECT + "UltiEffects/";
    public const string PREFABS_COMMON_EFFECT   = PREFABS_SKILL_EFFECT + "CommonEffects/";

    public const string PREFABS_BULLET          = PREFABS + "Bullets/";
    public const string PREFABS_ACTIVE_BULLET   = PREFABS_BULLET + "Active/";
    public const string PREFABS_BASIC_BULLET    = PREFABS_BULLET + "Basic/";
    public const string PREFABS_COMMON_BULLET   = PREFABS_BULLET + "Common/";

    public const string PREFABS_STAGE_ROOM      = PREFABS + "StagePrefabs/";
    public const string PREFABS_ROOM            = PREFABS + "Room/";

    public const string PREFABS_STAGE_OBJECT    = PREFABS + "StageObjects/";

    public const string PREFABS_EQUIP           = PREFABS + "Equip/";
    public const string PREFABS_INGREDIENT      = PREFABS + "Ingredient/";
    public const string PREFABS_GEMSTONE        = PREFABS + "GemStone/";
    public const string PREFABS_PROFESSIONAL    = PREFABS + "Professional/";


    public const string SCRIPTABLE              = "ScriptableObjects/";
    public const string SCRIPTABLE_ROOM_POSITION= SCRIPTABLE + "RoomPosition/Episode";
    public const string SCRIPTABLE_STAGE_DATA   = SCRIPTABLE + "StageDefaultData/";
    public const string SCRIPTABLE_CHAR_DATA    = SCRIPTABLE + "CharacterData/";


    public const string SPRITE                  = "/Resources/Sprites/";
    public const string SPRITE_CHAR_ICON        = SPRITE + "CharacterIcon/";
    public const string SPRITE_ITEM_ICON        = SPRITE + "ItemIcon/";
    public const string SPRITE_SKILL_ICON       = SPRITE + "SkillIcon/";
}
