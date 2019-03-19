using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMessage : MonoBehaviour {

    Text text;
    string prefix = "Final Score: ";
    int finalScore;

    [SerializeField]
    Text finalMessage;

	// Use this for initialization
	void Start () {
        // pause the game when added to the scene
        Time.timeScale = 0;
        AudioManager.Play(AudioClipName.GameOver);
        finalMessage.text = prefix + ActualValues.Score.ToString();
    }
	
	public void HandleQuitButton()
    {
        AudioManager.Play(AudioClipName.Click);
        Time.timeScale = 1;
        Destroy(this.gameObject);
        MenuManager.GoToMenu(MenuName.MainMenu);
    }
}
