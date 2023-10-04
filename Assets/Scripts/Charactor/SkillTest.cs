using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTest : MonoBehaviour
{
    public Canvas ABC;
    public Image ABCImage;
    public Image targetCircle; //Ÿ���� ����  �̹���
    public Image indicatorRangeCircle; // �ִ� ��Ÿ� �̹��� 
    public Canvas ActiveSkillCanvas; //Ÿ����ĵ����
    public Vector3 Pos; //���콺 ������ ��ġ 
    public float maxActiveSkillDistance; //�ִ��Ÿ�  
    public float targetCircleSize;

    public enum SKillType {Arrow,Ranged }
    public SKillType sKillType;
    GameObject Player;



    void Start()
    {
        targetCircle.GetComponent<Image>().enabled = false;
        indicatorRangeCircle.GetComponent<Image>().enabled = false;
        ABCImage.GetComponent<Image>().enabled = false;
        //Gameobj instance ~~~~ ��ų �ν��Ͻ� ��Ÿ� ��
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
     
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Pos = new Vector3(hit.point.x,hit.point.y,hit.point.z);
        }
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            if (hit.collider.gameObject != this.gameObject) {
                Pos = hit.point;
            }
        }

        Quaternion transRot = Quaternion.LookRotation(Pos - Player.transform.position);
        ABC.transform.rotation = Quaternion.Lerp(transRot, ABC.transform.rotation, 0f);

       
        var hitPosDir = (hit.point - Player.transform.position).normalized; //  ���ư��� ���⸸
       
        float distance = Vector3.Distance(hit.point, Player.transform.position);

        distance = Mathf.Min(distance, maxActiveSkillDistance);  // 3�� ��ų ����  MaxRange;
       
        var newHitPos = Player.transform.position  + hitPosDir * distance;

        ActiveSkillCanvas.transform.position = newHitPos;

    }



}
