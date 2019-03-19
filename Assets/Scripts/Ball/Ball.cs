using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// class to initialize the moving of the ball
/// </summary>
public class Ball : MonoBehaviour {

    #region fields
    Rigidbody2D rb2d;

    // hold timer object for creating the death timer
    Timer deathTimer;

    // hold timer object to let the ball delay for one second after spawning
    Timer timer;

    const int delay = 1;

    bool init = true;

    // hud variable to change balls left number
    HUD hud;

    // fields for speed up balls event
    bool isSpeedUp = false;
    Timer timerSpeedUp;
    float speedUpFactor;
    bool addSpeed = false;

    #endregion

    #region methods

    // Use this for initialization
    void Start () {
        rb2d = this.GetComponent<Rigidbody2D>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();

        deathTimer = gameObject.AddComponent<Timer>();

        timer = gameObject.AddComponent<Timer>();
        timer.Duration = delay;
        timer.Run();

        timerSpeedUp = gameObject.AddComponent<Timer>();

        // adding listener function for speed up effect
        EventManager.AddListenerSpeedupEffect(SpeedUpBall);

       
        

    }
	
	// Update is called once per frame
	void Update () {

        

        if (deathTimer.Finished)
        {
            Destroy(this.gameObject);
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
        }

        if(timer.Finished && init)
        {
            this.moveBall();
            timer.Stop();
            init = false;
        }

        if(isSpeedUp || EffectUtils.EffectIsActive)
        {
            
            if(timerSpeedUp.Finished || EffectUtils.TimeLeft == 0)
            {
                isSpeedUp = false;
                rb2d.velocity /=  speedUpFactor;
            }
            else if(addSpeed)
            {
                rb2d.velocity *= speedUpFactor;
                addSpeed = false;
            }
        }

    }

    // mehtod to move the ball into a new direction
    public void SetDirection(Vector2 direction)
    {
        rb2d.velocity = rb2d.velocity.magnitude * direction;
    }

    /// <summary>
    /// method to move the ball
    /// </summary>
    public void moveBall()
    {
        if (EffectUtils.EffectIsActive)
        {
            rb2d.AddForce((ConfigurationUtils.BallImpulseForce * EffectUtils.SpeedFactor * Time.deltaTime * new Vector2(
                    Mathf.Cos(Mathf.Deg2Rad * 270), Mathf.Sin(Mathf.Deg2Rad * 270))), ForceMode2D.Impulse);

            deathTimer.Duration = ConfigurationUtils.DeathTimeBall;
            deathTimer.Run();
        }
        else
        {
            rb2d.AddForce(ConfigurationUtils.BallImpulseForce * Time.deltaTime * new Vector2(
                Mathf.Cos(Mathf.Deg2Rad * 270), Mathf.Sin(Mathf.Deg2Rad * 270)), ForceMode2D.Impulse);

            deathTimer.Duration = ConfigurationUtils.DeathTimeBall;
            deathTimer.Run();
        }

    }

    /// <summary>
    /// method to spawn a new ball when a ball leaves the bottom of the screen
    /// </summary>
    private void OnBecameInvisible()
    {
        if(transform.position.y <= ScreenUtils.ScreenBottom   && !deathTimer.Finished)
        {
            Destroy(this.gameObject);
            hud.BallsLeft -= 1;
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
        }

    }

    /// <summary>
    /// method to tell the ball object to speed up and to start a timer
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="speedFac"></param>
    private void SpeedUpBall(float duration, float speedFac)
    {
        isSpeedUp = true;
        if (!timer.Finished)
        {
            addSpeed = false;
        }
        else
        {
            addSpeed = true;
        }
        speedUpFactor = speedFac;
        timerSpeedUp.Duration = duration;
        timerSpeedUp.Run();
    }

   
    #endregion
}
