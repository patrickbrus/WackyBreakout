using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectBoxAvailable : MonoBehaviour {

	// Use this for initialization
	void Start () {
        EventManager.AddListenerBoxesDestroyed(GameOver);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameOver()
    {
        MenuManager.GoToMenu(MenuName.GameOverMenu);
    }
}
