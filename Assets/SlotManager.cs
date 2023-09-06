using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public Transform SlotViewportCharacters;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    void Init()
    {
        GameManager.instance.objectFactory.CharSlotFactory.
                CreateFactory(FolderPath.PREFABS_CHAR_SLOT + PrefabName.STR_SLOT_PREFAB,
                                GameManager.instance.objectFactory.ownCharFactory.listPool.Count);
        for (int i = 0; i < GameManager.instance.objectFactory.CharSlotFactory.listPool.Count; i++)
        {
            GameManager.instance.objectFactory.CharSlotFactory.listPool[i].transform.parent
                = SlotViewportCharacters;
        }
    }
}
