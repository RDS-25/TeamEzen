using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillLevelUpUi : MonoBehaviour
{
    public List<Button> listButtons = new();
    public SkillPanelUi skillPanelUi;
    Dictionary<string, string> dictSelectedSkillParams = new();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < listButtons.Count; i++)
        {
            int buttonIndex = i;
            listButtons[i].onClick.AddListener(() => OnClickButton(buttonIndex));
        }
    }

    void OnClickButton(int index)
    {
        switch (index)
        {
            case 0:
                
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }

    }
    void SetDictSkillParams(Dictionary<string,string> dictTemp)
    {
        dictSelectedSkillParams = dictTemp;
    }
}
