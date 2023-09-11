using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageUiManager : MonoBehaviour
{
    public void OnOptionBtnClicked()
    {
        Time.timeScale = 0.0f;
    }

    public void OnContinueBtnClicked()
    {
        Time.timeScale = 1.0f;
    }

    public void OnRetireBtnClicked()
    {
        LoadingSceneManager.LoadScene("LobbyScene");
    }

}
