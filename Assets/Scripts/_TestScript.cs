using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class _TestScript : FactoryManager
{
    FactoryManager monsterFactory;
    FactoryManager trapFactory;

    void Start()
    {
        //CreateFactory("", 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("LobbyScene");
        }
    }

}