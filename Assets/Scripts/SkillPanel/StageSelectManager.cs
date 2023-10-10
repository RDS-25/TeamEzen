using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectManager : MonoBehaviour
{
    public void GoStage1()
    {
        if (GameManager.instance.arrCurCharacters[0] == null)
            return;

        LoadingSceneManager.LoadScene("StageScene");
    }
}
