using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PartyPanelManager : MonoBehaviour
{
    public Image[] CharImages = new Image[3];
    void Start()
    {
        for(int i = 0; i < CharImages.Length; i++)
        {
            GameObject curChar = GameManager.instance.arrCurCharacters[i];
            if (curChar != null)
            {
                CharImages[i].sprite = 
                    GameManager.instance.LoadAndSetSprite(FolderPath.SPRITE_CHAR_ICON + curChar.GetComponent<Stat>().sImagepath);
            }
            else
            {
                CharImages[i].sprite =
                    GameManager.instance.LoadAndSetSprite(FolderPath.SPRITE_CHAR_ICON + "Char_Default.png");
            }
        }
    }

    
}
