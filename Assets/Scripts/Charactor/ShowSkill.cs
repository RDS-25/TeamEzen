using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowSkill : MonoBehaviour ,IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    public Vector3 lastJoystickDirection;

    FixedJoystick joystick;
    public GameObject gRangeIndicator; // ���� ǥ�ñ� ������Ʈ�� �Ҵ��մϴ�.
    public GameObject gMaxRangeIndicator; // �ִ� ��Ÿ� ǥ�ñ� ������Ʈ�� �Ҵ��մϴ�.
    public GameObject gSkillCancel;


    Vector3 joystickDirection;
    Action action;
	private void Start()
	{
        action = GetComponentInParent<Action>();
        joystick = GetComponent<FixedJoystick>();
     
	}

	// Update is called once per frame
	void Update()
    {
        //SkillFunction();
        gRangeIndicator.transform.position = transform.root.position + new Vector3(0, 0.02f, 0) + joystickDirection * 5;//5�� �ִ뽺ų���� 
        gMaxRangeIndicator.transform.position = transform.root.position + new Vector3(0, 0.01f, 0);
    }   


    public void OnPointerDown(PointerEventData eventData)
    {
       /*����Ʈ �ٿ� ����*/
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
            /*�� ��ġ�� ��ų ���� ���*/
        }
        else if (action.motion == Action.Motion.Action)
        {
            Vector3 targetPosition = transform.root.position + joystickDirection;
            transform.root.LookAt(targetPosition);
            /*�� ��ġ�� ��ų �߻�*/
            action.motion = Action.Motion.Idle;

        }
    }

	public void OnDrag(PointerEventData eventData)
	{

       
        joystickDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical);

        if (joystick.Direction.magnitude > 0.1)
        {
            lastJoystickDirection = joystickDirection;

            gRangeIndicator.SetActive(true); //��ų����

            gMaxRangeIndicator.SetActive(true); //��ų ��Ÿ�
            gSkillCancel.SetActive(true);


            gMaxRangeIndicator.transform.localScale = new Vector3(10,0.01f,10);  
            gMaxRangeIndicator.transform.position = transform.root.position;

           

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
