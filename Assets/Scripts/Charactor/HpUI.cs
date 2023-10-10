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
        obj = transform.parent.parent.parent.gameObject;
        Debug.Log("�θ��"+obj);
        m_cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = m_cam.WorldToScreenPoint(obj.transform.position);

        //�Ǳ��̴°� �ð�ȭ
        transform.GetComponent<Slider>().value = obj.GetComponent<Stat>().fHealth / 100;
    }
}
