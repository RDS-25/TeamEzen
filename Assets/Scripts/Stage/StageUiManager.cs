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
        foreach (GameObject charactor in StageManager.Instance.Charactors)
        {
            if (charactor == null)
                continue;
            charactor.GetComponent<Action>().UIGroup.SetActive(false);
        }
    }
    
    public void OnContinueBtnClicked()
    {
        Time.timeScale = 1.0f;
        foreach (GameObject charactor in StageManager.Instance.Charactors)
        {
            if (charactor == null)
                continue;
            charactor.GetComponent<Action>().UIGroup.SetActive(true);
        }
    }

    public void OnRetireBtnClicked()
    {
        foreach (GameObject charactor in StageManager.Instance.Charactors)
        {
            if (charactor == null)
                continue;
            charactor.GetComponent<Stat>().ReadParams();
            charactor.GetComponent<Action>().isEntries = false;
            charactor.GetComponent<Action>().UIGroup.SetActive(false);
        }
        GameManager.instance.objectFactory.SlotInit();
        Time.timeScale = 1.0f;
        LoadingSceneManager.LoadScene("LobbyScene");
    }
    
    public void OnChangeCharactorBtnClicked()
    {
        StageManager.Instance.ChangeCurrentCharactor();
    }

    //public void OnStageClearBtnClicked()
    //{
    //    StageManager.Instance.player.GetComponent<Action>().isEntries = false;
    //    StageManager.Instance.player.GetComponent<Action>().UIGroup.SetActive(false);
    //    GameManager.instance.objectFactory.SlotInit();
    //    LoadingSceneManager.LoadScene("LobbyScene");
    //}

}
