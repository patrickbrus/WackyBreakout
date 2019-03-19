using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 200;
    static float deathTimeBall = 10;
    static float minSpwanSeconds = 5;
    static float maxSpwanSeconds = 10;
    static float standardBoxWorth = 10;
    static float bonusBoxWorth = 35;
    static float pickupBoxWorth = 15;
    static float probabilityStandardBox = 0.45f;
    static float probabilityBonusBox = 0.10f;
    static float probabilityFreezerBox = 0.20f;
    static float probabilitySpeedupBox = 0.25f;
    static int numberBalls = 7;
    static float freezerEffectDuration = 2f;
    static float speedupEffectDuration = 2f;
    static float speedupEffectSpeed = 2f;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    public float DeathTimeBall
    {
        get { return deathTimeBall; }
    }

    public float MinSpwanSeconds
    {
        get { return minSpwanSeconds; }
    }

    public float MaxSpawnSeconds
    {
        get { return maxSpwanSeconds; }
    }

    public float StandardBoxWorth
    {
        get { return standardBoxWorth; }
    }
    public float BonusBoxWorth
    {
        get { return bonusBoxWorth; }
    }

    public float PickupBoxWorth
    {
        get { return pickupBoxWorth; }
    }

    public float ProbabilityStandardBox
    {
        get { return probabilityStandardBox; }
    }

    public float ProbabilityBonusBox
    {
        get { return probabilityBonusBox; }
    }

    public float ProbabilityFreezerBox
    {
        get { return probabilityFreezerBox; }
    }

    public float ProbabilitySpeedupBox
    {
        get { return probabilitySpeedupBox; }
    }

    public int NumberBalls
    {
        get { return numberBalls; }
    }

    public float FreezerEffectDuration
    {
        get { return freezerEffectDuration; }
    }

    public float SpeedupEffectDuration
    {
        get { return speedupEffectDuration; }
    }

    public float SpeedupEffectSpeed
    {
        get { return speedupEffectSpeed; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader input = null;

        try
        {
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));

            string names = input.ReadLine();
            string values = input.ReadLine();

            this.SetValues(values);
        } catch(Exception e)
        {
            Debug.Log(e.Message);
        }
        finally
        {
            if(input != null)
            {
                input.Close();
            }
        }
        

        
    }

    /// <summary>
    /// method to store values from Configuration data file in fields
    /// </summary>
    /// <param name="values"></param>
    private void SetValues(string values)
    {
        
        string[] vals = values.Split(';');

        paddleMoveUnitsPerSecond = float.Parse(vals[0]);
        ballImpulseForce = float.Parse(vals[1]);
        deathTimeBall = float.Parse(vals[2]);
        minSpwanSeconds = float.Parse(vals[3]);
        maxSpwanSeconds = float.Parse(vals[4]);
        standardBoxWorth = float.Parse(vals[5]);
        bonusBoxWorth = float.Parse(vals[6]);
        pickupBoxWorth = float.Parse(vals[7]);
        probabilityStandardBox = float.Parse(vals[8]);
        probabilityBonusBox = float.Parse(vals[9]);
        probabilityFreezerBox = float.Parse(vals[10]);
        probabilitySpeedupBox = float.Parse(vals[11]);
        numberBalls = int.Parse(vals[12]);
        freezerEffectDuration = float.Parse(vals[13]);
        speedupEffectDuration = float.Parse(vals[14]);
        speedupEffectSpeed = float.Parse(vals[15]);

    }

    #endregion
}
