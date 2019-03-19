using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// class for the standard box
/// </summary>
public class StandardBox : Box {

    #region fields
    // fields for the different sprites
    [SerializeField]
    Sprite[] sprites;

    #endregion

    #region methods
    /// <summary>
    /// Use this for initialization
    /// </summary>
    override protected void Start () {

        boxWorth = ConfigurationUtils.StandardBoxWorth;

        // randomly choose a sprite for the box
        SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
        mySprite.sprite = sprites[Random.Range(0, 3)];

        base.Start();

	}

  
    #endregion
}
