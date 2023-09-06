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
        GameManager.instance.objectFactory.CharSlotFactory.
            CreateFactory(FolderPath.PREFABS_CHAR_SLOT + PrefabName.STR_SLOT_PREFAB, 
            GameManager.instance.objectFactory.ownCharFactory.listPool.Count);
        for(int i = 0; i < GameManager.instance.objectFactory.CharSlotFactory.listPool.Count; i++)
        {
            GameManager.instance.objectFactory.CharSlotFactory.listPool[i].transform.parent
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
