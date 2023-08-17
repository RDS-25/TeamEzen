using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFactory : MonoBehaviour
{
    private int nSize = 10;
    public FactoryManager roomFactory;
    public FactoryManager monsterFactory;
    public FactoryManager basicSkillFactory;
    public FactoryManager activeSkillFactory;
    


    void Start()
    {
        roomFactory.        CreateFactory("", nSize);
        monsterFactory.     CreateFactory("", nSize);
        basicSkillFactory.  CreateFactory(FilePath.STR_PREFAB_SKILL_EFFECT_1, nSize);
        activeSkillFactory. CreateFactory("", nSize);
    }
}
