using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OrganizeChar : MonoBehaviour
{
    public Button[] buttons = new Button[3];

    private void Start()
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            if(GameManager.instance.arrCurCharacters[i] == null)
            {
                buttons[i].GetComponent<Image>().sprite
                    = GameManager.instance.LoadAndSetSprite(FolderPath.SPRITE + "SkillImagetest.png");
            }
        }
    }
    public void UnFirstChar()
    {
        DeOrganizing(0);
    }
    public void UnSecondChar()
    {
        DeOrganizing(1);
    }
    public void UnThirdChar()
    {
        DeOrganizing(2);
    }
    private void DeOrganizing(int index)
    {
        switch (index)
        {
            case 0:
                ButtonImageSetting(0);
                break;
            case 1:
                ButtonImageSetting(1);
                break;
            case 2:
                ButtonImageSetting(2);
                break;
            default:
                break;
        }
    }
    private void ButtonImageSetting(int index)
    {
        //if(index < 2)
        //{
        //    GameManager.instance.arrCurCharacters[index] = GameManager.instance.arrCurCharacters[index + 1];
        //    GameManager.instance.SetCharId(index, GameManager.instance.fCharid[1]);
        //    buttons[index].GetComponent<Image>().sprite = buttons[index + 1].GetComponent<Image>().sprite;
        //}
        //else
        //{
        //    GameManager.instance.arrCurCharacters[index] = GameManager.instance.arrCurCharacters[index + 1];
        //    GameManager.instance.SetCharId(index, GameManager.instance.fCharid[1]);
        //    buttons[index].GetComponent<Image>().sprite = buttons[index + 1].GetComponent<Image>().sprite;
        //}

        GameManager.instance.arrCurCharacters[index] = null;
        GameManager.instance.SetCharId(index, -1);
        buttons[index].GetComponent<Image>().sprite
             = GameManager.instance.LoadAndSetSprite(FolderPath.SPRITE + "SkillImagetest.png");
        for (int i = index + 1; i < buttons.Length; i++)
        {
            GameManager.instance.arrCurCharacters[i - 1] = GameManager.instance.arrCurCharacters[i];
            GameManager.instance.SetCharId(i - 1, GameManager.instance.fCharid[i]);
            buttons[i - 1].GetComponent<Image>().sprite = buttons[i].GetComponent<Image>().sprite;

            GameManager.instance.arrCurCharacters[i] = null;
            GameManager.instance.SetCharId(i, -1);
            buttons[i].GetComponent<Image>().sprite 
                = GameManager.instance.LoadAndSetSprite(FolderPath.SPRITE + "SkillImagetest.png");
        }
    }
}
