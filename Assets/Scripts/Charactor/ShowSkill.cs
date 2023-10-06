using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ShowSkill : MonoBehaviour ,IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    public enum SKILLTYPE
	{
        ACTIVE,
        ULTI
	}
    public SKILLTYPE skillType = SKILLTYPE.ACTIVE;
    public Vector3 lastJoystickDirection;

    FixedJoystick joystick;
    public GameObject gRangeIndicator; // 범위 표시기 오브젝트를 할당합니다.
    public GameObject gMaxRangeIndicator; // 최대 사거리 표시기 오브젝트를 할당합니다.
    public GameObject gSkillCancel;

    public GameObject obj;

    public GameObject ACTIVESKILL;
    public GameObject ULTIMATESKILL;


    Vector3 joystickDirection;
    Action action;
    Stat stat;


	private void Start()
	{
        action = GetComponentInParent<Action>();
        joystick = GetComponent<FixedJoystick>();
       

        obj = GameObject.FindWithTag("Player");
        OwnSkills();
       
    }
    

	// Update is called once per frame
	void Update()
    {
      /*  gRangeIndicator.transform.localScale = new Vector3((skillType == SKILLTYPE.ACTIVE ? ACTIVESKILL.GetComponent<Skill>().fRange : ULTIMATESKILL.GetComponent<Skill>().fRange), 0, (skillType == SKILLTYPE.ACTIVE ? ACTIVESKILL.GetComponent<Skill>().fRange : ULTIMATESKILL.GetComponent<Skill>().fRange));
        gRangeIndicator.transform.position = obj.transform.position + new Vector3(0, 0.02f, 0) + joystickDirection * (skillType == SKILLTYPE.ACTIVE ? ACTIVESKILL.GetComponent<Skill>().fRange : ULTIMATESKILL.GetComponent<Skill>().fRange)/2;//5는 최대스킬범위 

        //SkillFunction();
        gMaxRangeIndicator.transform.localScale = new Vector3((skillType == SKILLTYPE.ACTIVE ? ACTIVESKILL.GetComponent<Skill>().fRange : ULTIMATESKILL.GetComponent<Skill>().fRange),0,(skillType == SKILLTYPE.ACTIVE ? ACTIVESKILL.GetComponent<Skill>().fRange : ULTIMATESKILL.GetComponent<Skill>().fRange));
        gMaxRangeIndicator.transform.position = obj.transform.position + new Vector3(0, 0.01f, 0);
        Debug.Log(ACTIVESKILL);*/
        //GameManager.instance.objectFactory.AllSkill.listPool;
     
    }

    void OwnSkills()
    {
        
        for (int i = 0; i < GameManager.instance.objectFactory.AllSkill.listPool.Count; i++)
        {
            if (obj.GetComponent<Stat>().fActiveSkill == GameManager.instance.objectFactory.AllSkill.listPool[i].GetComponent<Skill>().fId)
            {
                ACTIVESKILL = GameManager.instance.objectFactory.AllSkill.listPool[i];
            }
            else if (obj.GetComponent<Stat>().fUltimateSkill == GameManager.instance.objectFactory.AllSkill.listPool[i].GetComponent<Skill>().fId)
            {
                ULTIMATESKILL = GameManager.instance.objectFactory.AllSkill.listPool[i];
            }
           
            
           
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       /*포인트 다운 실행*/
        OnDrag(eventData);

    }

	public void OnPointerUp(PointerEventData eventData)
	{

        gRangeIndicator.SetActive(false);
        gMaxRangeIndicator.SetActive(false);
        gSkillCancel.SetActive(false);

        if (action.motion == Action.Motion.Cancel)
        {
          
            action.motion = Action.Motion.Idle;
            action.bIsCancel = false;
            /*이 위치에 스킬 실행 취소*/
            Debug.Log("취소");
        }
        else if (action.motion == Action.Motion.Action)
        {
            Vector3 targetPosition = obj.transform.position + joystickDirection;

            float aa  = Vector3.Distance(obj.transform.position,gRangeIndicator.transform.position);
           
            obj.transform.LookAt(targetPosition);

            ACTIVESKILL.GetComponent<Skill>().SkillTriger();// gRangeIndicator.transform.position) ;

            action.motion = Action.Motion.Idle;

        }
    }

    
	public void OnDrag(PointerEventData eventData)
	{

        joystickDirection = new Vector3(joystick.Horizontal, 0,joystick.Vertical);

        Transform Pos = ACTIVESKILL.transform;
        Debug.Log(Pos.position);

        if (joystick.Direction.magnitude > 0.1)
        {
            lastJoystickDirection = joystickDirection;

            gRangeIndicator.SetActive(true); //스킬범위

            gMaxRangeIndicator.SetActive(true); //스킬 사거리
            gSkillCancel.SetActive(true);

            if (skillType == SKILLTYPE.ACTIVE)
            {
                Debug.Log(ACTIVESKILL.transform.name);
                //ACTIVESKILL.GetComponent<Skill>().SkillTriger();
                Debug.Log("액티브 스킬 ");
            }
            else {
                Debug.Log(ULTIMATESKILL.transform.name);
                Debug.Log("궁극기 스킬");
              
                
            }
            float maxRange = (skillType == SKILLTYPE.ACTIVE ? 
                                ACTIVESKILL.GetComponent<Skill>().fMaxRange : 
                                ULTIMATESKILL.GetComponent<Skill>().fMaxRange);

            gMaxRangeIndicator.transform.localScale = new Vector3(maxRange, 0.01f, maxRange);
        

            gMaxRangeIndicator.transform.position = obj.transform.position+new Vector3(0, 0.3f, 0);

            float range = (skillType == SKILLTYPE.ACTIVE ?
                            ACTIVESKILL.GetComponent<Skill>().fRange :
                            ULTIMATESKILL.GetComponent<Skill>().fRange);


            gRangeIndicator.transform.localScale = new Vector3(range, 0.01f, range);
            gRangeIndicator.transform.position = obj.transform.position + new Vector3(0,0.31f,0) +  lastJoystickDirection  * maxRange/2;
            Debug.Log("드래그 다운에서의 포지션"+ gRangeIndicator.transform.position);

            if (action.bIsCancel)
            {
                action.motion = Action.Motion.Cancel;
            }
            else
            {
                action.motion = Action.Motion.Action;
            }
        }
    }
}
