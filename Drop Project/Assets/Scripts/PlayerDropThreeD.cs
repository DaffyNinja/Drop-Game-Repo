using UnityEngine;
using System.Collections;

public class PlayerDropThreeD : MonoBehaviour
{



    public float fallSpeed;
    public float leftRightspeed;

    public bool moveLeft;
    public bool moveRight;

    [Header("Touch")]
    public float screenPosX;

    Vector2 touchPos;



    Rigidbody rig;


    // Use this for initialization
    void Start()
    {
        rig = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        // Touch
        if (moveRight)
        {
            Vector2 moveQauntity = new Vector2(leftRightspeed, 0);
            rig.velocity = new Vector2(moveQauntity.x, rig.velocity.y);
            // moveRight = false;
        }
        else if (moveLeft)
        {

            Vector2 moveQauntity = new Vector2(-leftRightspeed, 0);
            rig.velocity = new Vector2(moveQauntity.x, rig.velocity.y);
            //moveLeft = false;

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            touchPos = Input.GetTouch(0).position;
        }
        else
        {
            touchPos = new Vector2(0, 0);

            moveRight = false;
            moveLeft = false;
        }

        if (touchPos.x > screenPosX)
        {
           // print("Right");

            moveRight = true;
            moveLeft = false;

        }
        else if (touchPos.x < screenPosX && touchPos.x > 0)
        {
           // print("Left");

            moveLeft = true;
            moveRight = false;
        }

        // End


        Vector2 fallQauntity = new Vector2(0, -fallSpeed);
        rig.velocity = new Vector2(rig.velocity.x, fallQauntity.y);




    }
}
