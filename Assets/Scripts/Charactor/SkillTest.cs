using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    public GameObject TestOBJ;
   
    public Camera cam;

    public enum SKillType {Arrow,Ranged }
    public SKillType sKillType;

    public enum SkillState {Init,Clicked,Active,}
    public SkillState Skillstate;

    GameObject Player;
    //��ų �����?
    public bool isSkilling;
    //��ų ĵ��
    public bool isCancel;

    RaycastHit hit;
    Ray ray;



    void Start()
    {
        
        Player = GameObject.FindWithTag("Player");
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        AllImageFalse();
        //���� �����ͼ� �ʱ�ȭ 
    }

    // Update is called once per frame
    void Update()
    {
        
         ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        

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
       
        float distance = Vector3.Distance(hit.point, Player.transform.position); //�Ÿ� 

        distance = Mathf.Min(distance, maxActiveSkillDistance);  // 3�� ��ų ����  MaxRange;
       
        var newHitPos = Player.transform.position  + hitPosDir * distance;

        ActiveSkillCanvas.transform.position = newHitPos;

        //Arrow�� Range�� ������ ��ų�� �ٸ��� 
        //Arrow��  �߻�ü  Range�� ��ȯ

        //��ư ������ ���� �ȵǰ� and ó���� ���� �ȵǰ� 
       
        if (Input.GetMouseButtonDown(0) && isSkilling)
        {
            if ((!EventSystem.current.IsPointerOverGameObject()))
            {
                Debug.Log("�ٸ��콺 �ٿ� ����");
               /* if (isCancel)
                {
                    isCancel = !isCancel;
                    return;
                }*/
         
                AllImageFalse();

                //����  ��ų �߻� skilltrigger
                isSkilling = false;
            }
        
        }

    }
  

	public void AllImageFalse() {

        targetCircle.GetComponent<Image>().enabled = false;
        indicatorRangeCircle.GetComponent<Image>().enabled = false;
        ABCImage.GetComponent<Image>().enabled = false;
    }

}
