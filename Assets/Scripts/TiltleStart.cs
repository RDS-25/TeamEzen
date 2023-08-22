using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TiltleStart : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.stageFactory.SelectCharacterInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadingSceneManager.LoadScene("LobbyScene");
        }
    }

}