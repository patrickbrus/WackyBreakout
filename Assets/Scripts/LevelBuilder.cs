using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// class to build the level of blocks and to instantiate the paddle
/// </summary>
public class LevelBuilder : MonoBehaviour {

    #region fields
    [SerializeField]
    GameObject prefabPaddle;

    [SerializeField]
    GameObject prefabBox;

    [SerializeField]
    GameObject prefabBonusBox;

    [SerializeField]
    GameObject prefabPickupBox;

    float heightBox;
    float widthBox;

    #endregion

    #region methods
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start () {
        

        // code to get half height of paddle
        GameObject tmp = Instantiate<GameObject>(prefabPaddle);
        float halfHeightPaddle = tmp.GetComponent<BoxCollider2D>().size.y / 2;
        Destroy(tmp);

        // code to get height and width of box
        GameObject tmpBox = Instantiate<GameObject>(prefabBox);
        heightBox = tmpBox.GetComponent<BoxCollider2D>().size.y;
        widthBox = tmpBox.GetComponent<BoxCollider2D>().size.x;
        Destroy(tmpBox);

        // code to instantiate the paddle
        Instantiate<GameObject>(prefabPaddle, new Vector3(0, ScreenUtils.ScreenBottom + halfHeightPaddle,
                        -Camera.main.transform.position.z), Quaternion.identity);

        // code to initialize three rows of boxes randomly
        float z = -Camera.main.transform.position.z;
        int numBoxes = (int)(Mathf.Abs(ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft) / ((5 / 3f) * widthBox));
        
        

        for (int i=0; i < 3; i++)
        {
            float y = (ScreenUtils.ScreenTop - 1 / 10f * (ScreenUtils.ScreenTop + Mathf.Abs(ScreenUtils.ScreenBottom)))
                            - 2 * heightBox * i;
            ActualValues.NumberBoxesLeft += 1;

            for(int j=0; j<numBoxes; j++)
            {
                float x = ScreenUtils.ScreenLeft + 1.5f * widthBox + (5 / 3f) * widthBox * j;

                this.PlaceBlock(new Vector3(x, y, z));

                ActualValues.NumberBoxesLeft += 1;
            }
        }
	}

   /// <summary>
   /// mehtod to place a new block (block gets choosen by the probabilities out of the configuration data file)
   /// </summary>
   /// <param name="pos"></param>
    public void PlaceBlock(Vector3 pos)
    {
        
        float p = Random.Range(0f, 1f);

        if (p <= ConfigurationUtils.ProbabilityBonusBox)
        {
            Instantiate<GameObject>(prefabBonusBox, pos, Quaternion.identity);
        }
        else if (p <= ConfigurationUtils.ProbabilityFreezerBox)
        {
            GameObject tmp = Instantiate<GameObject>(prefabPickupBox, pos, Quaternion.identity);
            tmp.GetComponent<PickupBox>().TypeBox = PickupEffect.Freezer;
        }
        else if (p <= ConfigurationUtils.ProbabilitySpeedupBox)
        {
            GameObject tmp = Instantiate<GameObject>(prefabPickupBox, pos, Quaternion.identity);
            tmp.GetComponent<PickupBox>().TypeBox = PickupEffect.Speedup;
        }
        else
        {
            Instantiate<GameObject>(prefabBox, pos, Quaternion.identity);
        }

    }

    #endregion
}
