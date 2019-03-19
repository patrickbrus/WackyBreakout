using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// class to spwan balls when game starts and when a ball gets destroyed
/// </summary>
public class BallSpawner : MonoBehaviour {

    #region fields
    [SerializeField]
    GameObject prefabBall;

  
    Timer timer;

    // flag for spwaning ball in collision free zone
    bool retrySpwan = true;

    // positions to check if there is a collision with another ball
    Vector2 minPosition;
    Vector2 maxPosition;

    // HUD field for accessing score and balls left values
    HUD hud;

    
    int maxNumberBalls;

    #endregion

    #region methods
    /// <summary>
    /// use this for initialization
    /// </summary>
    private void Start()
    {
        // add timer to BallSpawner and hold its reference
        timer = gameObject.AddComponent<Timer>();

        maxNumberBalls = ConfigurationUtils.NumberBalls;

        //hold hud gameobject
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();

        this.SetTimer();

        this.SpawnBall();

        GameObject tmpBall = Instantiate<GameObject>(prefabBall);
        float ballColliderHalfWidth = tmpBall.GetComponent<BoxCollider2D>().transform.position.x / 2;
        float ballColliderHalfHeight = tmpBall.GetComponent<BoxCollider2D>().transform.position.y / 2;

        minPosition = new Vector2(tmpBall.transform.position.x - ballColliderHalfWidth,
                                    tmpBall.transform.position.y - ballColliderHalfHeight);
        maxPosition = new Vector2(tmpBall.transform.position.x + ballColliderHalfWidth,
                                 tmpBall.transform.position.y + ballColliderHalfHeight);

        Destroy(tmpBall);

    }

    /// <summary>
    /// gets called every frame
    /// </summary>
    private void Update()
    {
        if(timer.Finished)
        {
            this.SpawnBall();
            timer.Stop();
            this.SetTimer();
        }

        if(retrySpwan)
        {
            this.SpawnBall();
        }
    }

    /// <summary>
    /// method to spwan a new ball
    /// </summary>
    public void SpawnBall()
    {
        if (hud.BallsLeft > 0)
        {
            if (Physics2D.OverlapArea(minPosition, maxPosition) == null)
            {
                Instantiate<GameObject>(prefabBall);
                retrySpwan = false;
            }
            else
            {
                retrySpwan = true;
            }
        }
        else
        {
            MenuManager.GoToMenu(MenuName.GameOverMenu);
        }
        
    }

    public void SetTimer()
    {
        timer.Duration = Random.Range(ConfigurationUtils.MinSpwanSeconds, ConfigurationUtils.MaxSpwanSeconds);
        timer.Run();
    }

    #endregion
}
