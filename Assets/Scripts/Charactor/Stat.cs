using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Params;

public class Stat : StatParams
{
    // 기능들구현  공격 
    void Start()
    {
        /*Init();*/
    }
    /*
    void Init()
	{
        if(GameManager.instance.CheckExist(FolderPath.DSAFD, FilePath.STR_JSON_CHARACTER_PARAMS_1))
        {
            ReadParams();
		}
		else
		{
            WriteParams();
		}
	}
    void ReadParams()
	{
        Dictionary<string, string> dictTemp = GameManager.instance.DataRead(sPath);
        fDef = float.Parse(dictTemp["defence"]);
	}*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
