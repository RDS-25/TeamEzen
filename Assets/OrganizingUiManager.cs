using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrganizingUiManager : MonoBehaviour
{
    public GameObject gOranaizngPanel;

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
    public void SetFirstChar()
    {
        
    }
}
