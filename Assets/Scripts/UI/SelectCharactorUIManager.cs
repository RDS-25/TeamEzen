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

	//씬매니저
	public static SelectCharactorUIManager Instance;
	public string information;
	//씬매니저


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
	//버튼 
	public void Back() {
		SceneManager.LoadScene("LobbyScene");
	}
	public void ShowDetail(Slot slot)
	{
		
		SceneManager.LoadScene("CharactorAction");

	}
	//캐릭터 셀렉트 음악
	void BackgroundMusic() {
		AudioManager.instance.PlayBackgroundSound(audio, AudioName.STR_CHARACTER_SELECT_1);
	}

	//캐릭터 정보들 가져오기
	public void SelectOne() {
		GameObject clickedObject = EventSystem.current.currentSelectedGameObject;
		Slot slot = clickedObject.GetComponentInChildren<Slot>();
		SelectSlot = slot;
		Debug.Log(slot);
	
	}

	




}
