using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SelectCharactorUIManager : MonoBehaviour
{
	AudioSource audio;


	public GameObject curChr = null;


	[SerializeField]
	GameObject CharDetail;
	[SerializeField]
	GameObject CharSelect;
    [SerializeField]
    GameObject gStatDetail;
	[SerializeField]
	GameObject gSkillPanel;
	[SerializeField]
	GameObject gExit;

	 public int curCharID;




	//slot ���ӿ�����Ʈ ����Ʈ 
	List<GameObject> listSlots = new List<GameObject>();

	Transform transformCharSelect;

	Transform transformSlots;

	//���Ŵ���

	private void Start()
	{
		

		audio = GetComponent<AudioSource>();

		//���� ������ �ִ� ĳ���� ����Ʈ�� ����ð� 
	
		/*���� �ڵ�
		GameManager.instance.objectFactory.ownCharFactory.listPool = OwnChar;*/

	



		transformCharSelect = CharSelect.transform; //charSelectPanel

	    transformSlots = transformCharSelect.GetChild(2).GetChild(0);//charSelectPanel/Charactor/CharactorSelect
		/*
		string a = Application.persistentDataPath + "/";
		var data = GameManager.instance.DataRead(a + FileName.STR_JSON_CHARACTER_PARAMS_2);
		Debug.Log(float.Parse(data["fId"]));*/
	}	

	//ĳ���� �� 
	public void ShowDetail()
	{
		CharDetail.SetActive(true);
		gStatDetail.SetActive(false);
	}
	public void ExitDetail() {

		CharDetail.SetActive(false);
	}
	public void SkillPanel()
    {
		gSkillPanel.SetActive(true);
    }


	//������ ĳ���� �����ֱ� 
	public void SelectOne() {
		if (curChr != null) {
			curChr.SetActive(false);
		}
		//��ư ������ ���� ���õ� ���ӿ�����Ʈ���� ��������

		//Slot ���ӿ�����Ʈ ����Ʈ�� ��������, �̸� �ٲٱ�
		for (int i = 0; i < transformSlots.childCount; i++)
		{
			listSlots.Add(transformSlots.GetChild(i).gameObject);
			listSlots[i].name = i.ToString();
		}

		//���� �̸� 
		string name = EventSystem.current.currentSelectedGameObject.name;

		// ���� ���õ� ���� �ε��� �� ��������
		for (int i = 0; i < GameManager.instance.objectFactory.ownCharFactory.listPool.Count; i++)
		{
			if (name == i.ToString())
			{
				curCharID = i;
				break;
			}
		}
		//���� �����͸� true ���ְ� ������ false
		for(int i = 0; i < GameManager.instance.objectFactory.ownCharFactory.listPool.Count; i ++)
		{
			GameManager.instance.objectFactory.ownCharFactory.listPool[i].SetActive(false);
		}
		GameManager.instance.objectFactory.ownCharFactory.listPool[curCharID].SetActive(true);

		//	//������Ʈ Ǯ�� �����ֱ�
		//GameObject n = GameManager.instance.objectFactory.characterFactory.listPool[(int)curCharID - 1];
		//if (curCharID == n.GetComponent<Stat>().fId) {
		//	n.SetActive(true);
		//	curChr = n;
		//}

		
	}

	//ĳ���� ���ݻ󼼺���
	public void StatDetail() {
		gStatDetail.SetActive(true);
	}

	public void StatDetailExit() {
		gStatDetail.SetActive(false);
	}

	//ĳ���� ����Ʈ ����
	void BackgroundMusic() {
		AudioManager.instance.PlayBackgroundSound(audio, AudioName.STR_CHARACTER_SELECT_1);
	}


	public void BtnNextChar() {
		GameManager.instance.objectFactory.ownCharFactory.listPool[curCharID].SetActive(false);
		if (curCharID >= GameManager.instance.objectFactory.ownCharFactory.listPool.Count - 1)
			curCharID = 0;
		else
			curCharID++;
		GameManager.instance.objectFactory.ownCharFactory.listPool[curCharID].SetActive(true);
		
	}

	public void BtnPrevChar() {
		GameManager.instance.objectFactory.ownCharFactory.listPool[curCharID].SetActive(false);
		if (curCharID <= 0)
			curCharID = GameManager.instance.objectFactory.ownCharFactory.listPool.Count - 1;
		else
			curCharID--;
		GameManager.instance.objectFactory.ownCharFactory.listPool[curCharID].SetActive(true);
	}

	public void BtnSelectCharExit() {
		CharSelect.SetActive(false);
	}



	public void TestMove() {

		SceneManager.LoadScene("characterMove");
		for (int i = 0; i < GameManager.instance.objectFactory.ownCharFactory.listPool.Count; i++) {
			GameManager.instance.objectFactory.ownCharFactory.listPool[i].GetComponent<Action>().isEntries = true;
		}
	
	}

	



	




}
