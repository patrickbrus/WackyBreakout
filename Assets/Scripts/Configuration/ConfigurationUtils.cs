using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Fields

    static ConfigurationData configurationData;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }

    public static float DeathTimeBall
    {
        get { return configurationData.DeathTimeBall; }
    }

    public static float MinSpwanSeconds
    {
        get { return configurationData.MinSpwanSeconds; }
    }

    public static float MaxSpwanSeconds
    {
        get { return configurationData.MaxSpawnSeconds; }
    }

    public static float StandardBoxWorth
    {
        get { return configurationData.StandardBoxWorth; }
    }

    public static float BonusBoxWorth
    {
        get { return configurationData.BonusBoxWorth; }
    }

    public static float PickupBoxWorth
    {
        get { return configurationData.PickupBoxWorth; }
    }

    public static float ProbabilityStandardBox
    {
        get { return configurationData.ProbabilityStandardBox; }
    }

    public static float ProbabilityBonusBox
    {
        get { return configurationData.ProbabilityBonusBox; }
    }

    public static float ProbabilityFreezerBox
    {
        get { return configurationData.ProbabilityFreezerBox; }
    }

    public static float ProbabilitySpeedupBox
    {
        get { return configurationData.ProbabilitySpeedupBox; }
    }

    public static int NumberBalls
    {
        get { return configurationData.NumberBalls; }
    }

    public static float FreezerEffectDuration
    {
        get { return configurationData.FreezerEffectDuration; }
    }

    public static float SpeedupEffectDuration
    {
        get { return configurationData.SpeedupEffectDuration; }
    }

    public static float SpeedupEffectSpeed
    {
        get { return configurationData.SpeedupEffectSpeed; }
    }

    #endregion

    #region methods
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();

    }
    #endregion
}
