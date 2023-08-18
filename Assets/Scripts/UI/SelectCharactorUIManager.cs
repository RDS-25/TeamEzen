using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SelectCharactorUIManager : MonoBehaviour
{
	AudioSource audio;

	
	//씬매니저

	private void Start()
	{
		string a = Application.persistentDataPath + "/";
		audio = GetComponent<AudioSource>();
		var data = GameManager.instance.DataRead(a + FilePath.STR_JSON_CHARACTER_PARAMS_TEST);
		Debug.Log(float.Parse(data["fId"]));
	}	
	void Update()
	{
		//로컬에 json데이터 있는지 없는지 확인 

		
		
	}
	//버튼 
	public void Back() {
		SceneManager.LoadScene("LobbyScene");
	}
	//캐릭서 상세 
	public void ShowDetail()
	{
		SceneManager.LoadScene("CharactorAction"); 
	}
	//캐릭터 셀렉트 음악
	void BackgroundMusic() {
		AudioManager.instance.PlayBackgroundSound(audio, AudioName.STR_CHARACTER_SELECT_1);
	}

	



	




}
