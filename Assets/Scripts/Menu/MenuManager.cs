using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager {

	public static void GoToMenu(MenuName name)
    {
        switch(name)
        {
            case MenuName.MainMenu:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.HelpMenu:
                SceneManager.LoadScene("Help");
                break;
            case MenuName.PauseMenu:
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
            case MenuName.GameOverMenu:
                Object.Instantiate(Resources.Load("GameOverMessage"));
                break;

        }
    }
}
