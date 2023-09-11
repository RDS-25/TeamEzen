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

    }   

    void SkillFunction()
    {

        //���̽�ƽ ����
       Vector3 joystickDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical);

        if (joystick.Direction.magnitude > 0.1)
        {
            lastJoystickDirection = joystickDirection;

            gRangeIndicator.SetActive(true); //��ų����

            gMaxRangeIndicator.SetActive(true); //��ų ��Ÿ�

            gSkillCancel.SetActive(true);

            // ��ų ���� ǥ��
            gRangeIndicator.transform.position = transform.root.position + joystickDirection * 5;//5�� ��ų ������ 
            Debug.Log(transform.name + "����");

            if (action.bIsCancel)
            {
                action.motion = Action.Motion.Cancel;
            }
            else
            {
                action.motion = Action.Motion.Action;
            }
        }



        else if (joystick.Direction.magnitude <= 0.1f)
        {
            gRangeIndicator.SetActive(false);
            gMaxRangeIndicator.SetActive(false);
            gSkillCancel.SetActive(false);
            Debug.Log(transform.name + "�����");

            if (action.motion == Action.Motion.Cancel)
            {
                Debug.Log("��ų ���� ��� ");
                action.motion = Action.Motion.Idle;
                action.bIsCancel = false;
          
            }
            else if (action.motion == Action.Motion.Action)
            {
                Vector3 targetPosition = transform.root.position + joystickDirection;
                transform.root.LookAt(targetPosition);
                Debug.Log("��ų  ����");
                action.motion = Action.Motion.Idle;
               
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.LogError("����Ʈ �ٿ� ����");
        OnDrag(eventData);

    }

	public void OnPointerUp(PointerEventData eventData)
	{

        gRangeIndicator.SetActive(false);
        gMaxRangeIndicator.SetActive(false);
        gSkillCancel.SetActive(false);

    
        Debug.Log(transform.name + "�����");

        if (action.motion == Action.Motion.Cancel)
        {
            Debug.Log("��ų ���� ��� ");
            action.motion = Action.Motion.Idle;
            action.bIsCancel = false;

        }
        else if (action.motion == Action.Motion.Action)
        {
            Vector3 targetPosition = transform.root.position + joystickDirection;
            transform.root.LookAt(targetPosition);
            Debug.Log("��ų  ����");
            action.motion = Action.Motion.Idle;

        }
    }

	public void OnDrag(PointerEventData eventData)
	{

        Debug.LogError("�巡�� ����");
        joystickDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical);

        if (joystick.Direction.magnitude > 0.1)
        {
            lastJoystickDirection = joystickDirection;

            gRangeIndicator.SetActive(true); //��ų����

            gMaxRangeIndicator.SetActive(true); //��ų ��Ÿ�
            gSkillCancel.SetActive(true);

            // ��ų ���� ǥ��
            gRangeIndicator.transform.position = transform.root.position + joystickDirection * 5;//5�� ��ų ������ 
            Debug.Log(transform.name + "����");

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
