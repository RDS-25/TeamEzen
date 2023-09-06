using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectManager : MonoBehaviour
{
    public void GoStage1()
    {
        LoadingSceneManager.LoadScene("StageScene");
    }
}
