using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour
{
    GameObject obj;

    Camera m_cam = null;

    public float HpBarPos;
 

    void Start()
    {
        obj = transform.root.gameObject;
        m_cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = m_cam.WorldToScreenPoint(obj.transform.position + new Vector3(0, HpBarPos, 0));

        //�Ǳ��̴°� �ð�ȭ
        transform.GetComponent<Slider>().value = transform.root.GetComponent<Stat>().fHealth / 100;
    }
}
