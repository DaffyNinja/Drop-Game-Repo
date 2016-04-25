using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchTest : MonoBehaviour
{

    public Text debugText;

    public float screenPosX;

    Vector2 touchPos;

    public PlayerDropletAndroid playerAnd;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {

            touchPos = Input.GetTouch(0).position;
        }
        else
        {
            touchPos = new Vector2(0, 0);

            //  playerAnd.moveRight = false;
            // playerAnd.moveLeft = false;
        }

        if (touchPos.x > screenPosX)
        {
            print("Right");

            // playerAnd.moveRight = true;
            // playerAnd.moveLeft = false;

        }
        else if (touchPos.x < screenPosX && touchPos.x > 0)
        {
            print("Left");

            // playerAnd.moveLeft = true;
            // playerAnd.moveRight = false;
        }



        // print(touchPos.ToString());

    }


}
