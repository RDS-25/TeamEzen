using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image;
    private Stat _Stat;
    public Stat Stat
    {
        get { return _Stat; }
        set
        {
            _Stat = value;
            if (_Stat != null)
            {
                image.sprite = _Stat.sImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }


}
