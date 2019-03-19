using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// class to add appopriate messages and scores on the gaming screen
/// </summary>
public class HUD : MonoBehaviour {

    #region fields
    // hold text variables for score and balls left text
    [SerializeField]
    Text scoreText;

    [SerializeField]
    Text ballsLeftText;

    // hold prefixes for the appearing text
    string prefixScore = "Score: ";
    string prefixBallsLeft = "Balls left: ";

    // the actual score
    static float score = 0;

    // the amount of balls left
    static int ballsLeft = 0;
    #endregion

    #region properties

    public float Score
    {
        set { score = value; }
        get { return score; }
    }

    public int BallsLeft
    {
        set { ballsLeft = value; }
        get { return ballsLeft; }
    }

    #endregion

    #region methods
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start () {

        ballsLeft = ConfigurationUtils.NumberBalls;

        scoreText.text = prefixScore + score.ToString();
        ballsLeftText.text = prefixBallsLeft + ballsLeft.ToString();
	}
	
	// Update is called once per frame
	void Update () {

        this.SetScoreText();
        this.SetBallsLeftText();
	}

    public void SetScoreText()
    {
        scoreText.text = prefixScore + score.ToString();
        ActualValues.Score = score;
    }

    public void SetBallsLeftText()
    {
        ballsLeftText.text = prefixBallsLeft + ballsLeft.ToString();
    }

    #endregion
}
