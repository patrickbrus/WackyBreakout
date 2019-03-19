using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// class to create the pick up box
/// </summary>
public class PickupBox : Box {

    #region fields

    PickupEffect typeBox;

    [SerializeField]
    Sprite freezerSprite;

    [SerializeField]
    Sprite speedupSprite;

    //field to hold the freezer duration
    float freezerEffectDuration;

    //field for event to slow down the paddle after hitting a freezer block
    FreezerEffectActivated freezerEffectActivated = new FreezerEffectActivated();

    //field for event to speed up the balls after hitting a freezer block
    SpeedupEffectActivated speedupEffectActivated = new SpeedupEffectActivated();

    //fields for speed up effect duration and speed factor to be added
    float speedupEffectDuration;
    float speedupEffectSpeed;

    #endregion

    #region properties

    public PickupEffect TypeBox
    {
        set { typeBox = value;
            this.SetSprite(); }
    }

    public float FreezerEffectDuration
    {
        set { freezerEffectDuration = value; }
    }

    #endregion

    #region methods
    /// <summary>
    /// Use this for initialization
    /// </summary>
    override protected void Start () {

        // code to set the points of the block to the bonus points out of the configuration file
        boxWorth = ConfigurationUtils.PickupBoxWorth;

        // add pickup box object as invoker to freezer effect
        EventManager.AddInvokerFreezerEffect(this);

        // add pickup box object as invoker to speed up effect
        EventManager.AddInvokerSpeedupEffect(this);

        freezerEffectDuration = ConfigurationUtils.FreezerEffectDuration;
        speedupEffectDuration = ConfigurationUtils.SpeedupEffectDuration;
        speedupEffectSpeed = ConfigurationUtils.SpeedupEffectSpeed;

        base.Start();
    }

    void SetSprite()
    {
        //code to safe the current blocks sprite
        SpriteRenderer actualSprite = this.GetComponent<SpriteRenderer>();

        if(typeBox == PickupEffect.Freezer)
        {
            actualSprite.sprite = freezerSprite;
        }
        else
        {
            actualSprite.sprite = speedupSprite;
        }
    }

    public void AddFreezerEffectListener(UnityAction<float> listener)
    {
        freezerEffectActivated.AddListener(listener);
    }

    public void AddSpeedupEffectListener(UnityAction<float,float> listener)
    {
        speedupEffectActivated.AddListener(listener);
    }

    override protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(typeBox == PickupEffect.Freezer)
        {
            freezerEffectActivated.Invoke(freezerEffectDuration);
        }
        else if(typeBox == PickupEffect.Speedup)
        {
            speedupEffectActivated.Invoke(speedupEffectDuration, speedupEffectSpeed);
        }

        base.OnCollisionEnter2D(collision);

    }

    #endregion


}
