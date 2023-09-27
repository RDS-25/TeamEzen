using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTest : MonoBehaviour
{
    
    public Image targetCircle; //Ÿ���� ����  �̹���
    public Image indicatorRangeCircle; // �ִ� ��Ÿ� �̹��� 
    public Canvas ActiveSkillCanvas; //Ÿ����ĵ����
    public Vector3 Pos; //���콺 ������ ��ġ 
    public float maxActiveSkillDistance; //�ִ��Ÿ�  
    public float targetCircleSize;



    void Start()
    {
        targetCircle.GetComponent<Image>().enabled = false;
        indicatorRangeCircle.GetComponent<Image>().enabled = false;
        //Gameobj instance ~~~~ ��ų �ν��Ͻ� ��Ÿ� ��
    }

    // Update is called once per frame
    void Update()
    {
     
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            if (hit.collider.gameObject != this.gameObject) {
                Pos = hit.point;
            }
        }
       
        var hitPosDir = (hit.point - transform.position).normalized; //  ���ư��� ���⸸
       

        float distance = Vector3.Distance(hit.point, transform.position);

        distance = Mathf.Min(distance, maxActiveSkillDistance);  // 3�� ��ų ����  MaxRange;
       
        var newHitPos = transform.position +new Vector3(0,4.55f,0)+ hitPosDir * distance;

        ActiveSkillCanvas.transform.position = newHitPos;

    }



}
