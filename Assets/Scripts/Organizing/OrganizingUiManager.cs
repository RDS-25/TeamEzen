using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrganizingUiManager : MonoBehaviour
{
    public GameObject gOranaizngPanel;

    public SlotManager slotManager;
    public Transform gSlots;
    public Button[] buttons = new Button[3];
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
        slotManager.SetButtonClickedEvent();
    }
    void Start()
    {
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
    public void SelectChar(int index)
    {
        Organizing(index);
    }

    public void Organizing(int index)
    {
        for (int i = 0; i < GameManager.instance.arrCurCharacters.Length; i++)
        {
            if (GameManager.instance.arrCurCharacters[i]
                == GameManager.instance.objectFactory.ownCharFactory.listPool[index])
            {
                GameManager.instance.arrCurCharacters[i] = null;
                GameManager.instance.fCharid[i] = -1;
                buttons[i].GetComponent<Image>().sprite
                    = GameManager.instance.LoadAndSetSprite("C:/Users/EZEN/Documents/GitHub/TeamEzen/Assets/Resources/Sprites/ SkillImagetest.png");
                return;
            }
        }
        for (int i = 0; i < GameManager.instance.arrCurCharacters.Length; i++)
        {
            if(GameManager.instance.arrCurCharacters[i] == null)
            {
                GameManager.instance.arrCurCharacters[i]
                    = GameManager.instance.objectFactory.ownCharFactory.listPool[index];
                GameManager.instance.SetCharId(i, 
                    GameManager.instance.arrCurCharacters[i].GetComponent<Stat>().fId);
                buttons[i].GetComponent<Image>().sprite 
                    = GameManager.instance.LoadAndSetSprite(GameManager.instance.arrCurCharacters[i].GetComponent<Stat>().sImagepath);
                return;
            }
        }
    }
}
