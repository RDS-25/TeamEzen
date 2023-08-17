using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharactorUIManager : MonoBehaviour
{
	AudioSource audio;
	
	private void Start()
	{
		audio = GetComponent<AudioSource>();
	}
	void Update()
	{
		
	}
	public void Back() {
		SceneManager.LoadScene("LobbyScene");
	}

	void BackgroundMusic() {

		AudioManager.instance.PlayBackgroundSound(audio, AudioName.STR_CHARACTER_SELECT_1);
	}


}
