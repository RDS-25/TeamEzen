using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganizeChar : MonoBehaviour
{
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
                GameManager.instance.gFirstChar = null;
                GameManager.instance.SetFirstCharId(-1);
                break;
            case 1:
                GameManager.instance.gSecondChar = null;
                GameManager.instance.SetSecondCharId(-1);
                break;
            case 2:
                GameManager.instance.gThirdChar = null;
                GameManager.instance.SetThirdCharId(-1);
                break;
            default:
                break;
        }
    }
}
