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
//    ȭ  ��   ��

//       0        1       2 
//���� ����
// ȭ<��   0-1    -1       ��> ȭ   1-0   1
// ��<��   1-2    -1       ��> ��   2-1   1
// ��<ȭ   2-0    2        ȭ> ��   0-2  -2     

//���� �� = -1, 2
//�̱�� �� = 1,-2



    // Update is called once per frame
    void Update()
    {
        
    }
}
