using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// class to destroy Box if its get hit by a ball
/// </summary>
public class Box : MonoBehaviour {

    #region fields

    // field to hold a HUD variable to change the appearing score
    HUD hud;

    // event to detect if all boxes are destroyed
    DestroyedBlocks destroyedBlocks;


    // field for the box class and all childs to store the appropriate score values when box gets destroyed
    protected float boxWorth;

    #endregion

    #region methods
    /// <summary>
    /// Use this for initialization
    /// </summary>
    virtual protected void Start () {

        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();

	}

    /// <summary>
    /// method which gets called if the box get hit
    /// </summary>
    /// <param name="collision"></param>
    virtual protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            hud.Score += boxWorth;
            AudioManager.Play(AudioClipName.Explosion);
            Destroy(this.gameObject);
            

            if(ActualValues.NumberBoxesLeft == 0)
            {
                destroyedBlocks.Invoke();
            }
        }
    }

    public void AddNoArgumentListener(UnityAction input)
    {
        destroyedBlocks.AddListener(input);
    }

    #endregion
}
