using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes the game
/// </summary>
public class GameInitializer : MonoBehaviour 
{

    /// <summary>
    /// Awake is called before Start
    /// </summary>
	void Awake()
    {
        // initialize screen utils
        ScreenUtils.Initialize();
        ConfigurationUtils.Initialize();
        EffectUtils.Initialize();

        HUD hud = gameObject.GetComponent<HUD>();
        hud.BallsLeft = 0;
        hud.Score = 0;
        Destroy(hud);

    }

    private void Start()
    {
        
    }

}
