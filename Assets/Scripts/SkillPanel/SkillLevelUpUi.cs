using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillLevelUpUi : MonoBehaviour
{
    int sSkillType;

    public List<Button> listButtons = new();
    public SkillPanelUi skillPanelUi;
    Dictionary<string, string> dictSkillParams = new();
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
        sSkillType = index;

        Debug.Log(sSkillType);
    }
    void SetDictSkillParams(Dictionary<string,string> dictTemp)
    {
        dictSkillParams = dictTemp;
    }
}
