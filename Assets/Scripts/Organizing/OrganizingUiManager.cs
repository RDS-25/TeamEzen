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
        for(int i = 0; i < buttons.Length; i++)
        {
            if(GameManager.instance.arrCurCharacters[i] !=null)
            {
                buttons[i].transform.GetChild(0).GetComponent<Image>().sprite
                    = GameManager.instance.LoadAndSetSprite(
                        FolderPath.SPRITE_CHAR_ICON + GameManager.instance.arrCurCharacters[i].GetComponent<Stat>().sImagepath);
            }
        }
    }
    public void ButtonLoadStage()
    {
        if (GameManager.instance.fCharid[0] == -1)
        {
            Debug.Log("캐릭터선택해야함");
            return;
        }
        for(int i = 0; i < GameManager.instance.arrCurCharacters.Length; i++)
        {
            if (GameManager.instance.arrCurCharacters[i] == null)
                break;
            GameManager.instance.arrCurCharacters[i].GetComponent<Action>().isEntries = true;
            GameManager.instance.arrCurCharacters[i].GetComponent<Action>().UIGroup.SetActive(true);
        }
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
        bool eraseObject = false;
        int eraseObjectIdx = 0;
        for (int i = 0; i < GameManager.instance.fCharid.Length; i++)
        {
            if (GameManager.instance.fCharid[i]
                == GameManager.instance.objectFactory.ownCharFactory.listPool[index].GetComponent<Stat>().fId)
            {
                GameManager.instance.arrCurCharacters[i] = null;
                GameManager.instance.fCharid[i] = -1;
                buttons[i].transform.GetChild(0).GetComponent<Image>().sprite
                    = GameManager.instance.LoadAndSetSprite(FolderPath.SPRITE_CHAR_ICON + "Char_Default.png");
                eraseObject = true;
                eraseObjectIdx = i;
                //return;
            }

            if (i > eraseObjectIdx && eraseObject)
            {
                GameManager.instance.arrCurCharacters[i - 1] = GameManager.instance.arrCurCharacters[i];
                GameManager.instance.fCharid[i - 1] = GameManager.instance.fCharid[i];
                buttons[i - 1].transform.GetChild(0).GetComponent<Image>().sprite
                    = buttons[i].transform.GetChild(0).GetComponent<Image>().sprite;

                GameManager.instance.arrCurCharacters[i] = null;
                GameManager.instance.fCharid[i] = -1;
                buttons[i].transform.GetChild(0).GetComponent<Image>().sprite
                    = GameManager.instance.LoadAndSetSprite(FolderPath.SPRITE_CHAR_ICON + "Char_Default.png");
            }
        }

        if (eraseObject)
            return;

        for (int i = 0; i < GameManager.instance.arrCurCharacters.Length; i++)
        {
            if(GameManager.instance.arrCurCharacters[i] == null)
            {
                GameManager.instance.arrCurCharacters[i]
                    = GameManager.instance.objectFactory.ownCharFactory.listPool[index];
                GameManager.instance.SetCharId(i, 
                    GameManager.instance.arrCurCharacters[i].GetComponent<Stat>().fId);
                buttons[i].transform.GetChild(0).GetComponent<Image>().sprite 
                    = GameManager.instance.LoadAndSetSprite
                    (FolderPath.SPRITE_CHAR_ICON + GameManager.instance.arrCurCharacters[i].GetComponent<Stat>().sImagepath);
                break;
            }
        }
    }
}
