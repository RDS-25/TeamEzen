using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SelectCharactorUIManager : MonoBehaviour
{
	AudioSource audio;


	public GameObject preChr = null;


	[SerializeField]
	GameObject CharDetail;
	[SerializeField]
	GameObject Lobby;
	[SerializeField]
	GameObject CharSelect;


	//씬매니저

	private void Start()
	{
		audio = GetComponent<AudioSource>();
		/*
		string a = Application.persistentDataPath + "/";
		var data = GameManager.instance.DataRead(a + FileName.STR_JSON_CHARACTER_PARAMS_2);
		Debug.Log(float.Parse(data["fId"]));*/
	}	

	//버튼 
	public void Back() {
		SceneManager.LoadScene("LobbyScene");
	}
	//캐릭서 상세 
	public void ShowDetail()
	{
		CharDetail.SetActive(true);
		Lobby.SetActive(false);
		CharSelect.SetActive(false);
	}

	//누르면 캐릭터 보여주기 
	public void SelectOne() {
		if (preChr != null) {
			preChr.SetActive(false);
		}
		//버튼 누르면 현재 선택된 게임오브젝트정보 가져오기
		GameObject gameObject = EventSystem.current.currentSelectedGameObject;
		//그 오브젝트를 가져와서 id정보를 가져오기
		 var a = gameObject.transform.GetComponentInChildren<Slot>().Stat.fId;
		//오브젝트 풀을 보여주기
		GameObject n = GameManager.instance.stageFactory.characterFactory.listPool[(int)a-1];
		if (a == n.GetComponent<Stat>().fId) {
			n.SetActive(true);
			preChr = n;
		}
		
	}

	//캐릭터 스텟상세보기
	public void StatDetail() { 
		
	}
	//캐릭터 셀렉트 음악
	void BackgroundMusic() {
		AudioManager.instance.PlayBackgroundSound(audio, AudioName.STR_CHARACTER_SELECT_1);
	}

	



	




}
