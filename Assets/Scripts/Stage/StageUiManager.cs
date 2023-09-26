using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageUiManager : MonoBehaviour
{
    public void OnOptionBtnClicked()
    {
        //�÷��̾� ������ �޽� ȭ
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
