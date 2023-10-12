using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour
{
    GameObject obj;

    Camera m_cam = null;

    public float HpBarPos;


    private void OnEnable()
    {
        obj = GameObject.FindWithTag("Enemy");
        Debug.Log("�θ��" + obj);
        m_cam = Camera.main;
    }


    //2023.10.12  ENEMY ������
    void Update()
    {
        transform.position = m_cam.WorldToScreenPoint(obj.transform.position);

        //�Ǳ��̴°� �ð�ȭ
        transform.GetComponent<Slider>().value = obj.GetComponent<Stat>().fHealth / 100;
    }
}
