using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// static class as interface between other classes and the ActiveEffectsMonitor class
/// </summary>
public static class EffectUtils {

    static ActiveEffectsMonitor activeEffectsMonitor;

    public static bool EffectIsActive
    {
        get { return activeEffectsMonitor.EffectIsActive; }
    }

    public static float TimeLeft
    {
        get { return activeEffectsMonitor.TimeLeft; }
    }

    public static float SpeedFactor
    {
        get { return activeEffectsMonitor.SpeedFactor; }
    }

    public static void Initialize()
    {
        activeEffectsMonitor = new ActiveEffectsMonitor();
    }
	
}
