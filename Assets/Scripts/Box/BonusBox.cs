using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// class for the bonus box
/// </summary>
public class BonusBox : Box {
    

    /// <summary>
    /// Use this for initialization
    /// </summary>
    override protected void Start () {

        // code to set the points of the block to the bonus points out of the configuration file
        boxWorth = ConfigurationUtils.BonusBoxWorth;

        base.Start();
	}

  
}
