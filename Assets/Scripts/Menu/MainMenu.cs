using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void HandlePlay()
    {
        AudioManager.Play(AudioClipName.Click);
        SceneManager.LoadScene("Gameplay");
    }

    public void HandleHelpButton()
    {
        AudioManager.Play(AudioClipName.Click);
        MenuManager.GoToMenu(MenuName.HelpMenu);
    }

	public void HandleQuitEvent()
    {
        AudioManager.Play(AudioClipName.Click);
        Application.Quit();
    }
}
