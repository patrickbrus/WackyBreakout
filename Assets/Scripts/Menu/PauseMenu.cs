using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        // pause the game when added to the scene
        Time.timeScale = 0;

	}
	
	public void HandleResumeButton()
    {
        AudioManager.Play(AudioClipName.Click);
        Time.timeScale = 1;
        Destroy(gameObject);
       
    }

    public void HandleQuitButton()
    {
        AudioManager.Play(AudioClipName.Click);
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.MainMenu);
    }
}
