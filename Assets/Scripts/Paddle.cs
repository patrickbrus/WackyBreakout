using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// class for properties of paddle
/// </summary>
public class Paddle : MonoBehaviour {

    #region Fields
    Rigidbody2D rb2d;

    float halfWidthOfPaddle;

    float heightPaddle;

    float xPosLastFrame;

    const float BounceAngleHalfRange = 60f * Mathf.Deg2Rad;

    // field to store if paddle is frozen or not
    bool isFrozen = false;
    Timer timerFrozen;
    
    #endregion


    // Use this for initialization
    void Start () {
        rb2d = this.GetComponent<Rigidbody2D>();

        halfWidthOfPaddle = this.GetComponent<BoxCollider2D>().size.x / 2;
        heightPaddle = this.GetComponent<BoxCollider2D>().size.y;

        // initialize timer for freezer effect
        timerFrozen = gameObject.AddComponent<Timer>();
        

        // Add "SetPaddleFrozen()" as a listener to freezer effect event
        EventManager.AddListenerFreezerEffect(SetPaddleFrozen);

    }

    // Update is called once per frame
    void Update () {
		
        if(isFrozen)
        {
            if(timerFrozen.Finished)
            {
                isFrozen = false;
            }
        }

        // check if user pressed esc key to pause the gameä
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GoToMenu(MenuName.PauseMenu);
        }
	}


    // function to move the paddle
    public void FixedUpdate()
    {
        if (isFrozen == false)
        {
            // store the velocity out of ConfigurationUtils class
            Vector2 velocity = new Vector2(ConfigurationUtils.PaddleMoveUnitsPerSecond, 0);

            // store input through arrow key's in a variable for efficiency
            float input = Input.GetAxis("Horizontal");

            // stores x pos of last frame
            xPosLastFrame = rb2d.position.x;

            if (input != 0)
            {
                float xPos = CalculateClampedX(rb2d.position.x + velocity.x * Time.deltaTime * input);
                rb2d.MovePosition(new Vector2(xPos, rb2d.position.y + velocity.y * Time.deltaTime * input));
            }
        }
        
    }

    /// <summary>
    /// function which gets called if the paddle collides with something
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (this.IsTop(collision))
            {
                // calculate new ball direction
                float ballOffsetFromPaddleCenter = transform.position.x -
                    collision.transform.position.x;
                float normalizedBallOffset = ballOffsetFromPaddleCenter /
                    halfWidthOfPaddle;
                float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
                float angle = Mathf.PI / 2 + angleOffset;
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                // tell ball to set direction to new direction
                Ball ballScript = collision.gameObject.GetComponent<Ball>();
                ballScript.SetDirection(direction);
            }
        }
    }

    /// <summary>
    /// method to find out if the ball hits the top of the paddle or not
    /// </summary>
    /// <param name="collision"></param>
    /// <returns></returns>
    bool IsTop(Collision2D collision)
    {
        bool isTopFlag = true;

        foreach(ContactPoint2D hit in collision.contacts)
        {
            
            if(Mathf.Abs(hit.point.y) - Mathf.Abs(this.transform.position.y + heightPaddle) > 0.25f)
            {
                isTopFlag = false;
            }
        }

        return isTopFlag;
    }

    /// <summary>
    /// method which take as input a possible new x position and changes that value if necessary
    /// </summary>
    /// <param name="xPos"></param>
    /// <returns></returns>
    public float CalculateClampedX(float xPos)
    {
        if(xPos - halfWidthOfPaddle < ScreenUtils.ScreenLeft)
        {
            return xPosLastFrame;
        }
        else if(xPos + halfWidthOfPaddle > ScreenUtils.ScreenRight)
        {
            return xPosLastFrame;
        }
        else
        {
            return xPos;
        }

    }

    /// <summary>
    /// mehtod to freeze the paddle if a freezer block gets hit
    /// </summary>
    public void SetPaddleFrozen(float duration)
    {
        isFrozen = true;
        timerFrozen.Duration = duration;
        timerFrozen.Run();
    }



}
