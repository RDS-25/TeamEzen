using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CheckProperty : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }
    public float CheckPro(int Attacker, int Defender)
    {
        if (Attacker - Defender == -1 || Attacker - Defender == 2)
        {//AttackerWin;
            return 1.3f;
        }
        if (Attacker - Defender == 1 || Attacker - Defender == -2)
        {//AttackerLose;
            return 0.7f;
        }
        else
            return 1f;
    }
//    화  수   목

//       0        1       2 
//기준 기준
// 화<수   0-1    -1       수> 화   1-0   1
// 수<목   1-2    -1       목> 수   2-1   1
// 목<화   2-0    2        화> 목   0-2  -2     

//지는 상성 = -1, 2
//이기는 상성 = 1,-2



    // Update is called once per frame
    void Update()
    {
        
    }
}
