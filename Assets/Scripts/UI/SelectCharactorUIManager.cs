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


	//���Ŵ���

	private void Start()
	{
		audio = GetComponent<AudioSource>();
		/*
		string a = Application.persistentDataPath + "/";
		var data = GameManager.instance.DataRead(a + FileName.STR_JSON_CHARACTER_PARAMS_2);
		Debug.Log(float.Parse(data["fId"]));*/
	}	

	//��ư 
	public void Back() {
		SceneManager.LoadScene("LobbyScene");
	}
	//ĳ���� �� 
	public void ShowDetail()
	{
		CharDetail.SetActive(true);
		Lobby.SetActive(false);
		CharSelect.SetActive(false);
	}

	//������ ĳ���� �����ֱ� 
	public void SelectOne() {
		if (preChr != null) {
			preChr.SetActive(false);
		}
		//��ư ������ ���� ���õ� ���ӿ�����Ʈ���� ��������
		GameObject gameObject = EventSystem.current.currentSelectedGameObject;
		//�� ������Ʈ�� �����ͼ� id������ ��������
		 var a = gameObject.transform.GetComponentInChildren<Slot>().Stat.fId;
		//������Ʈ Ǯ�� �����ֱ�
		GameObject n = GameManager.instance.stageFactory.characterFactory.listPool[(int)a-1];
		if (a == n.GetComponent<Stat>().fId) {
			n.SetActive(true);
			preChr = n;
		}
		
	}

	//ĳ���� ���ݻ󼼺���
	public void StatDetail() { 
		
	}
	//ĳ���� ����Ʈ ����
	void BackgroundMusic() {
		AudioManager.instance.PlayBackgroundSound(audio, AudioName.STR_CHARACTER_SELECT_1);
	}

	



	




}
