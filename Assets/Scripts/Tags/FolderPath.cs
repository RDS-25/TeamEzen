using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderPath
{
    // Json
    public const string MAIN_ROOT               = "C:/Users/EZEN/AppData/LocalLow/DefaultCompany/TeamProject";

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

    public const string PARAMS_ITEM             = PARAMS + "Item/";
    public const string PARAMS_ITEM_COUNT       = PARAMS_ITEM + "ItemCount/"; 


    // Resources 
    public const string PREFABS                 = "Prefabs/";
    public const string PREFABS_CHARACTER       = PREFABS + "Characters/";
    public const string PREFABS_CHAR_SLOT       = PREFABS + "Slot/";

    public const string PREFABS_MONSTER         = PREFABS + "Monsters/";
    public const string PREFABS_SKILL_EFFECT    = PREFABS + "SkillEffects/";

    public const string PREFABS_STAGE_ROOM      = PREFABS + "StagePrefabs/";

    public const string PREFABS_STAGE_OBJECT    = PREFABS + "StageObjects/";

    public const string PREFABS_EQUIP           = PREFABS + "Equip/";
    public const string PREFABS_INGREDIENT      = PREFABS + "Ingredient/";
    public const string PREFABS_GEMSTONE        = PREFABS + "GemStone/";
    public const string PREFABS_PROFESSIONAL    = PREFABS + "Professional/";


    public const string SCRIPTABLE              = "ScriptableObjects/";
    public const string SCRIPTABLE_ROOM_POSITION= SCRIPTABLE + "RoomPosition/Episode";
    public const string SCRIPTABLE_STAGE_DATA   = SCRIPTABLE + "StageDefaultData/";


    public const string SPRITE                  = "Sprite/";
    public const string SPRITE_CHAR_ICON        = SPRITE + "CharacterIcon/";
    public const string SPRITE_ITEM_ICON        = SPRITE + "ItemIcon/";


}