using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrganizingManager : MonoBehaviour
{
    public GameObject gOranaizngPanel;
    public GameObject gSlotPrefab;
    public Transform SlotViewportCharacters;
    void Start()
    {
        GameManager.instance.stageFactory.CharSlotFactory.
            CreateFactory(FolderPath.PREFABS_CHAR_SLOT + PrefabName.STR_SLOT_PREFAB, 
            GameManager.instance.stageFactory.ownCharFactory.listPool.Count);
        for(int i = 0; i < GameManager.instance.stageFactory.CharSlotFactory.listPool.Count; i++)
        {
            GameManager.instance.stageFactory.CharSlotFactory.listPool[i].transform.parent
                = SlotViewportCharacters;
        }

        gOranaizngPanel.SetActive(false);
    }
    public void ButtonLoadStage()
    {
        LoadingSceneManager.LoadScene("StageScene");
    }
    public void ButtonBack()
    {
        gOranaizngPanel.SetActive(false);
    }
    public void SetFirstChar()
    {
        
    }
}
