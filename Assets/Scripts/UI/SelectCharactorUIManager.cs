using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SelectCharactorUIManager : MonoBehaviour
{
	AudioSource audio;

	
	//���Ŵ���

	private void Start()
	{
		string a = Application.persistentDataPath + "/";
		audio = GetComponent<AudioSource>();
		var data = GameManager.instance.DataRead(a + FilePath.STR_JSON_CHARACTER_PARAMS_TEST);
		Debug.Log(float.Parse(data["fId"]));
	}	
	void Update()
	{
		//���ÿ� json������ �ִ��� ������ Ȯ�� 

		
		
	}
	//��ư 
	public void Back() {
		SceneManager.LoadScene("LobbyScene");
	}
	//ĳ���� �� 
	public void ShowDetail()
	{
		SceneManager.LoadScene("CharactorAction"); 
	}
	//ĳ���� ����Ʈ ����
	void BackgroundMusic() {
		AudioManager.instance.PlayBackgroundSound(audio, AudioName.STR_CHARACTER_SELECT_1);
	}

	



	




}
