using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// class to monitore the important values of the game
/// </summary>
public static class ActualValues  {

    static float score = 0;

    static int numberBoxesLeft = 0;

    public static float Score
    {
        set { score = value; }
        get { return score; }
    }

    public static int NumberBoxesLeft
    {
        set { numberBoxesLeft = value; }
        get { return numberBoxesLeft; }
    }

}
