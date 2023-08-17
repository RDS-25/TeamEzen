using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SelectCharactorUIManager : MonoBehaviour
{
	AudioSource audio;
	[SerializeField]
	Slot SelectSlot;

	//���Ŵ���
	public static SelectCharactorUIManager Instance;
	public string information;
	//���Ŵ���


	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
	private void Start()
	{
		audio = GetComponent<AudioSource>();

		
	}
	void Update()
	{
		
	}
	//��ư 
	public void Back() {
		SceneManager.LoadScene("LobbyScene");
	}
	public void ShowDetail(Slot slot)
	{
		
		SceneManager.LoadScene("CharactorAction");

	}
	//ĳ���� ����Ʈ ����
	void BackgroundMusic() {
		AudioManager.instance.PlayBackgroundSound(audio, AudioName.STR_CHARACTER_SELECT_1);
	}

	//ĳ���� ������ ��������
	public void SelectOne() {
		GameObject clickedObject = EventSystem.current.currentSelectedGameObject;
		Slot slot = clickedObject.GetComponentInChildren<Slot>();
		SelectSlot = slot;
		Debug.Log(slot);
	
	}

	




}
