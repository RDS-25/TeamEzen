using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrganizingUiManager : MonoBehaviour
{
    public GameObject gOranaizngPanel;

    public SlotManager slotManager;
    public Transform gSlots;
    static int i = 0;
    private void OnEnable()
    {
        SlotManager.OnButtonClick += SelectChar;
    }
    private void OnDisable()
    {
        SlotManager.OnButtonClick -= SelectChar;
    }
    private void Awake()
    {
        slotManager.SetSlot(GameManager.instance.objectFactory.OrganizingSlotFactory.listPool,
                    GameManager.instance.objectFactory.characterFactory.listPool,
                    gSlots,
                    SlotManager.OBJECT_TYPE.CHARACTER);
    }
    void Start()
    {
        gOranaizngPanel.SetActive(false);
    }
    public void ButtonLoadStage()
    {
        SetCurCharList();
        LoadingSceneManager.LoadScene("StageScene");
    }
    public void ButtonBack()
    {
        gOranaizngPanel.SetActive(false);
    }
    public void SelectChar(int index)
    {
        Organizing(index);
        i++;
        if(i > 2)
        {
            i = 0;
        }
        Debug.Log(GameManager.instance.fFirstCharacterId);
        Debug.Log(GameManager.instance.gFirstChar);
        Debug.Log(GameManager.instance.fSecondCharacterId);
        Debug.Log(GameManager.instance.gSecondChar);
        Debug.Log(GameManager.instance.fThirdCharacterId);
        Debug.Log(GameManager.instance.gThirdChar);
    }
    private void SetCurCharList()
    {
        GameManager.instance.listCurCharacters.Clear();
        GameManager.instance.listCurCharacters.Add(GameManager.instance.gFirstChar);
        GameManager.instance.listCurCharacters.Add(GameManager.instance.gSecondChar);
        GameManager.instance.listCurCharacters.Add(GameManager.instance.gThirdChar);
    }
    public void Organizing(int index)
    {
        if (GameManager.instance.gFirstChar 
            == GameManager.instance.objectFactory.ownCharFactory.listPool[index]
            || GameManager.instance.gSecondChar 
            == GameManager.instance.objectFactory.ownCharFactory.listPool[index]
            || GameManager.instance.gThirdChar 
            == GameManager.instance.objectFactory.ownCharFactory.listPool[index])
        {
            return;
        }
        if (GameManager.instance.gFirstChar == null)
        {
            GameManager.instance.gFirstChar 
                = GameManager.instance.objectFactory.ownCharFactory.listPool[index];
            GameManager.instance.listCurCharacters.Add(GameManager.instance.gFirstChar);
            GameManager.instance.SetFirstCharId(GameManager.instance.gFirstChar.GetComponent<Stat>().fId);
            return;
        }
        else if (GameManager.instance.gSecondChar == null)
        {
            GameManager.instance.gSecondChar 
                = GameManager.instance.objectFactory.ownCharFactory.listPool[index];
            GameManager.instance.listCurCharacters.Add
                (GameManager.instance.gSecondChar);
            GameManager.instance.SetSecondCharId
                (GameManager.instance.gSecondChar.GetComponent<Stat>().fId);
            return;
        }
        else if (GameManager.instance.gThirdChar == null)
        {
            GameManager.instance.gThirdChar 
                = GameManager.instance.objectFactory.ownCharFactory.listPool[index];
            GameManager.instance.listCurCharacters.Add
                (GameManager.instance.gThirdChar);
            GameManager.instance.SetThirdCharId
                (GameManager.instance.gThirdChar.GetComponent<Stat>().fId);
            return;
        }
    }
}
