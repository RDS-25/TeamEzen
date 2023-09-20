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
        foreach (GameObject charactor in StageManager.Instance.Charactors)
        {
            if (charactor == null)
                continue;
            charactor.GetComponent<Action>().isEntries = false;
            charactor.GetComponent<Action>().UIGroup.SetActive(false);
        }
        GameManager.instance.objectFactory.SlotInit();
        LoadingSceneManager.LoadScene("LobbyScene");
    }

    //public void OnStageClearBtnClicked()
    //{
    //    StageManager.Instance.player.GetComponent<Action>().isEntries = false;
    //    StageManager.Instance.player.GetComponent<Action>().UIGroup.SetActive(false);
    //    GameManager.instance.objectFactory.SlotInit();
    //    LoadingSceneManager.LoadScene("LobbyScene");
    //}

}
