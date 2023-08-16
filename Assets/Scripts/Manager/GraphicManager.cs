using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicManager : MonoBehaviour
{
    private static string _strGraphicPath;
    
    Dictionary<string, string> dictGraphicValue;

    void Start()
    {
        if (GameManager.instance.FileExists(_strGraphicPath))
        {
            dictGraphicValue = GameManager.instance.DataRead(_strGraphicPath);
        }
        else
        {
            Init();
            GameManager.instance.DataWrite(_strGraphicPath, dictGraphicValue);
        }
    }
    void Init()
    {
        dictGraphicValue["Key"] = "1";
    }
    void Update()
    {
        
    }
}
