using UnityEngine;
using System.Collections;

public class PlayerEndless : MonoBehaviour
{

    public float fallSpeed;
    public float leftRightSpeed;

    public float turnAmmount;

    Quaternion startingRotation;

    [Header("Touch")]
    public float screenPosX;
    public float upScreenPos;
    public float midScreenPos;

    public bool moveRight;
    public bool moveLeft;
    public bool moveForward;
    public bool moveBack;

    Vector2 touchPos;

    [Space(10)]
    public bool isPC;
    public bool isTouch;

    Rigidbody rig;

    // Use this for initialization
    void Awake()
    {
        rig = GetComponent<Rigidbody>();

        startingRotation = transform.rotation;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPC)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                Vector3 moveQauntity = new Vector3(leftRightSpeed, 0, 0);
                rig.velocity = new Vector3(moveQauntity.x, rig.velocity.y, rig.velocity.z);

                transform.rotation = Quaternion.Euler(turnAmmount, 90, 0);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                Vector3 moveQauntity = new Vector3(-leftRightSpeed, 0, 0);
                rig.velocity = new Vector3(moveQauntity.x, rig.velocity.y, rig.velocity.z);

                transform.rotation = Quaternion.Euler(-turnAmmount, 90, 0);
            }
            else
            {
                transform.rotation = startingRotation;
            }

        }
        else if (isTouch)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
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
                moveRight = true;
                moveLeft = false;
            }
            else if (touchPos.x < screenPosX && touchPos.x > 0)
            {
                moveLeft = true;
                moveRight = false;
            }


            // Touch Controls
            if (moveRight)
            {
                Vector2 moveQauntity = new Vector2(leftRightSpeed, 0);
                rig.velocity = new Vector2(moveQauntity.x, rig.velocity.y);
                // moveRight = false;
            }
            else if (moveLeft)
            {
                Vector2 moveQauntity = new Vector2(-leftRightSpeed, 0);
                rig.velocity = new Vector2(moveQauntity.x, rig.velocity.y);
                //moveLeft = false;
            }


        }

        Vector2 fallQauntity = new Vector2(0, -fallSpeed);
        rig.velocity = new Vector2(rig.velocity.x, fallQauntity.y);

    }
}
