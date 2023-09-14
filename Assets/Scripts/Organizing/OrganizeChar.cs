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
                GameManager.instance.arrCurCharacters[0] = null;
                GameManager.instance.SetCharId(0, -1);
                buttons[0].GetComponent<Image>().sprite
                    = GameManager.instance.LoadAndSetSprite(FolderPath.SPRITE + "SkillImagetest.png");
                break;
            case 1:
                GameManager.instance.arrCurCharacters[1] = null;
                GameManager.instance.SetCharId(1, -1);
                buttons[1].GetComponent<Image>().sprite
                    = GameManager.instance.LoadAndSetSprite(FolderPath.SPRITE + "SkillImagetest.png");
                break;
            case 2:
                GameManager.instance.arrCurCharacters[2] = null;
                GameManager.instance.SetCharId(2, -1);
                buttons[2].GetComponent<Image>().sprite
                    = GameManager.instance.LoadAndSetSprite(FolderPath.SPRITE + "SkillImagetest.png");
                break;
            default:
                break;
        }
    }
}
