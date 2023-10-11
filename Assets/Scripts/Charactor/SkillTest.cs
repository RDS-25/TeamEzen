using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillTest : MonoBehaviour
{
    public Canvas Arrow;
    public Image ArrowImage;
    public Image targetCircle; //타겟팅 범위  이미지
    public Image indicatorRangeCircle; // 최대 사거리 이미지 
    public Canvas ActiveSkillCanvas; //타겟팅캔버스
    public Vector3 Pos; //마우스 포인터 위치 
    public float maxActiveSkillDistance; //최대사거리  
    public float targetCircleSize;  // 범위 사거리
    public GameObject TestOBJ;
   
    public Camera cam;

    public enum SKillType {Arrow,Ranged }
    public SKillType sKillType;

    public enum SkillState {Init,Clicked,Active,}

    public SkillState Skillstate;

    GameObject Player;
    //스킬 사용중?
    public bool isSkilling;
    //스킬 캔슬
    public bool isCancel;

    RaycastHit hit;
    Ray ray;

    //무슨 스킬인지 확인 
    [SerializeField]
    Skill temp;



    void Start()
    {
        
        Player = GameObject.FindWithTag("Player");
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        AllImageFalse();
        //정보 꺼내와서 초기화 
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

        Vector3 targetDirection = Pos - Player.transform.position;
        targetDirection.y = 0; // Set the y-value of the target direction to 0
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        float interpolationFactor = 0.5f;
        Arrow.transform.rotation = Quaternion.Lerp(Arrow.transform.rotation, targetRotation, interpolationFactor);


        var hitPosDir = (hit.point - Player.transform.position).normalized; //  나아가는 방향만
       
        float distance = Vector3.Distance(hit.point, Player.transform.position); //거리 

        distance = Mathf.Min(distance, maxActiveSkillDistance);  // 3을 스킬 스텟  MaxRange;
       
        var newHitPos = Player.transform.position  + hitPosDir * distance;

        ActiveSkillCanvas.transform.position = newHitPos;

        //Arrow와 Range의 나가는 스킬이 다르다 
        //Arrow는  발사체  Range는 소환

        //버튼 누를때 실행 안되게 and 처음에 실행 안되게 
       
        if (Input.GetMouseButtonDown(0) && isSkilling)
        {
            if ((!EventSystem.current.IsPointerOverGameObject()))
            {
                Debug.Log("겟마우스 다운 실행");
               /* if (isCancel)
                {
                    isCancel = !isCancel;
                    return;
                }*/
         
                AllImageFalse();
                Player.transform.LookAt(newHitPos);
                temp.SkillTriger(Player.GetComponent<Action>().tBulletpos.position, Player.GetComponent<Action>().tBulletpos.rotation);
                //여기  스킬 발사 skilltrigger
                isSkilling = false;
            }
        
        }

    }

    public void ReadStat(Params.SkillParams.SkillType skillType) {
        for (int i = 0; i < Player.GetComponent<Action>().Skills.Count; i++)
        {
            if(skillType == Player.GetComponent<Action>().Skills[i].GetComponent<Skill>().enumSkillType)
                temp = Player.GetComponent<Action>().Skills[i].GetComponent<Skill>();
        }

        if (temp.enumSkillType == Params.SkillParams.SkillType.ACTIVE) {
            targetCircleSize = temp.fRange;
            maxActiveSkillDistance = temp.fMaxRange;
            Debug.Log(temp.name);
            Debug.Log("액티브 스킬 가동 범위 :" + temp.fRange);
            Debug.Log("액티브 스킬 최대 범위 :" + temp.fMaxRange);

        }
        else if (temp.enumSkillType == Params.SkillParams.SkillType.ULTIMATE)
        {
            targetCircleSize = temp.fRange;
            maxActiveSkillDistance = temp.fMaxRange;
            Debug.Log(temp.name);
            Debug.Log("궁극기 스킬 가동 범위 :" + temp.fRange);
            Debug.Log("궁극기 스킬 최대 범위 :" + temp.fMaxRange);
        }
    }

	public void AllImageFalse() {

        targetCircle.GetComponent<Image>().enabled = false;
        indicatorRangeCircle.GetComponent<Image>().enabled = false;
        ArrowImage.GetComponent<Image>().enabled = false;
    }

}
