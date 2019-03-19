using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// class to tell other activities if the speed up effect is actually active
/// </summary>
public class ActiveEffectsMonitor : MonoBehaviour {

    #region fields
    float durationSpeedupEffect;
    static float speedSpeedupEffect;
    float timeLeft;
    static bool effectIsActive = false;

    // Timer to monitor if speed up effect is active
    static Timer timer;

    #endregion

    #region properties

    /// <summary>
    /// property to return if the speed up effect is currently active
    /// </summary>
    public bool EffectIsActive
    {
        get { return effectIsActive; }
    }

    /// <summary>
    /// property to return the left time of speed up effect
    /// </summary>
    public float TimeLeft
    {
        get { return timer.TimeLeft; }
    }

    /// <summary>
    /// property to return the current speed factor 
    /// </summary>
    public float SpeedFactor
    {
        get { return speedSpeedupEffect; }
    }

    #endregion

    #region methods
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start () {

        // add function to set fields of speed up effect as a listener
        EventManager.AddListenerSpeedupEffect(SetDurationAndSpeed);

        timer = gameObject.AddComponent<Timer>();
	}

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update () {
		
        if(effectIsActive)
        {
            if (timer.Finished)
            {
                effectIsActive = false;
            }
        }
	}

    /// <summary>
    /// mehtod to be added as listener for speed up event and to store duration 
    /// and speed up value in appropriate fields
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="speed"></param>
    public void SetDurationAndSpeed(float duration, float speed)
    {
        durationSpeedupEffect = duration;
        speedSpeedupEffect = speed;
        timer.Duration = duration;
        timer.Run();
        effectIsActive = true;
    }

    #endregion

}
