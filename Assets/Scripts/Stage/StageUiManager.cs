using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageUiManager : MonoBehaviour
{
    public void OnOptionBtnClicked()
    {
        //플레이어 움직임 펄스 화
        Time.timeScale = 0.0f;
    }

    public void OnContinueBtnClicked()
    {
        Time.timeScale = 1.0f;
    }

    public void OnRetireBtnClicked()
    {
        GameManager.instance.objectFactory.SlotInit();
        LoadingSceneManager.LoadScene("LobbyScene");
    }

}
