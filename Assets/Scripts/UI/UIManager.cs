using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

#region 타임라인
/*

추가해야할 기능
씬별로 ui 구성해야함.
*/
#endregion
public class UIManager : MonoBehaviour
{


    // json 파일 읽은거로 ui 할당하기

    protected virtual void OnSelectStageButtonDown()
    {
        SceneManager.LoadScene("SelectStageScene");
    }
}
