using UnityEngine;
using System.Collections;
using UnityEngine.UI; // To Delete

public class PlayerEndless : MonoBehaviour
{

    public float fallSpeed;
    public float leftRightSpeed;

    public bool slowWhenTurn;
    public float turnFallSpeed;

    [Space(5)]
    public float turnAmmount;
    Quaternion startingRotation;

    [Header("Special Pickup")]
    public float specialSpeed;
    public Vector3 specialSize;
    Vector3 startingSize;

    public float specialTime;
    public float speedTime;

    public bool obtainedSpecial;
    public bool obtainedSpeed;

    float specialTimer;
    float speedTimer;

    [Header("Touch")]
    public float screenPosX;

    public bool moveRight;
    public bool moveLeft;

    Vector2 touchPos;

    [Header("Acceleromater")]
    public float disNum;
    Vector3 startAccPos;

    [Header("Controls")]
    public bool isPC;
    public bool isMobile;

    [Space(5)]
    public bool debugTouch;
    public bool debugAccel;

    static public bool isTouch;
    static public bool isAccelerate;

    Rigidbody rig;

    [Space(5)]
    public Color startingCol;
    public Color specialCol;

    void Awake()
    {
        startAccPos = Input.acceleration.normalized;

        screenPosX = Screen.width / 2;

        rig = GetComponent<Rigidbody>();

        startingRotation = transform.rotation;

        startingSize = transform.localScale;

        // print(startAccPos.ToString());

        startingCol = gameObject.GetComponentInChildren<Renderer>().material.color;

    }

    void FixedUpdate()
    {
        // Controls
        if (isPC)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))  // Right
            {
                Vector3 moveQauntity = new Vector3(leftRightSpeed, 0, 0);
                rig.velocity = new Vector3(moveQauntity.x, rig.velocity.y, rig.velocity.z);

                moveRight = true;
                moveLeft = false;

                transform.rotation = Quaternion.Euler(-turnAmmount, 90, 0);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))      // Left
            {
                Vector3 moveQauntity = new Vector3(-leftRightSpeed, 0, 0);
                rig.velocity = new Vector3(moveQauntity.x, rig.velocity.y, rig.velocity.z);

                moveRight = false;
                moveLeft = true;

                transform.rotation = Quaternion.Euler(turnAmmount, 90, 0);
            }
            else
            {
                moveRight = false;
                moveLeft = false;

                transform.rotation = startingRotation;
            }

        }
        else if (isMobile)    // Mobile controls
        {
            if (isTouch == true && isAccelerate == false || debugTouch)  // Touch
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
            }
            else if (isAccelerate == true && isTouch == false || debugAccel)  // Acellerometor
            {

                if (Input.acceleration.normalized.x > startAccPos.x + disNum)  // Right
                {
                    //print("Right");

                    moveRight = true;
                    moveLeft = false;

                }
                else if (Input.acceleration.normalized.x < startAccPos.x - disNum) // Left   0.25
                {
                    // print("Left");

                    moveLeft = true;
                    moveRight = false;

                }
                else
                {
                    // print("Stopped");

                    moveLeft = false;
                    moveRight = false;
                }
            }

            // Movement
            if (moveRight)
            {
                Vector3 moveQauntity = new Vector3(leftRightSpeed, 0, 0);
                rig.velocity = new Vector3(moveQauntity.x, rig.velocity.y, rig.velocity.z);

                transform.rotation = Quaternion.Euler(-turnAmmount, 90, 0);
                // moveRight = false;
            }
            else if (moveLeft)
            {
                Vector3 moveQauntity = new Vector3(-leftRightSpeed, 0, 0);
                rig.velocity = new Vector3(moveQauntity.x, rig.velocity.y, rig.velocity.z);
                //moveLeft = false;

                transform.rotation = Quaternion.Euler(turnAmmount, 90, 0);
            }
            else
            {
                transform.rotation = startingRotation;
            }

        }

        if (obtainedSpeed || obtainedSpecial) // Powerups
        {

            // Special PowerUp
            if (obtainedSpecial)
            {
                gameObject.GetComponentInChildren<Renderer>().material.color = specialCol;

                Vector2 fallQauntity = new Vector2(0, -specialSpeed);
                rig.velocity = new Vector2(rig.velocity.x, fallQauntity.y);

                specialTimer += Time.deltaTime;

                if (specialTimer >= specialTime)
                {
                    transform.localScale = startingSize;
                    obtainedSpecial = false;
                }
            }
            else
            {
                specialTimer = 0;

                gameObject.GetComponentInChildren<Renderer>().material.color = startingCol;
            }

            // Speed Power
            if (obtainedSpeed)
            {
                gameObject.GetComponentInChildren<Renderer>().material.color = specialCol;

                transform.localScale = specialSize;

                Vector2 fallQauntity = new Vector2(0, -specialSpeed);
                rig.velocity = new Vector2(rig.velocity.x, fallQauntity.y);

                speedTimer += Time.deltaTime;

                if (speedTimer >= speedTime)
                {
                    transform.localScale = startingSize;
                    obtainedSpeed = false;
                }

            }
            else
            {
                speedTimer = 0;

                gameObject.GetComponentInChildren<Renderer>().material.color = startingCol;
            }
        }
        else if (obtainedSpeed == false && moveLeft == false && moveRight == false)       // Falling
        {
            Vector2 fallQauntity = new Vector2(0, -fallSpeed);
            rig.velocity = new Vector2(rig.velocity.x, fallQauntity.y);
        }
        else if (slowWhenTurn == true && moveLeft == true || moveRight == true)  // Fall speed decerases when turn left or right
        {
            Vector2 fallQauntity = new Vector2(0, -turnFallSpeed);
            rig.velocity = new Vector2(rig.velocity.x, fallQauntity.y);

        }
    }

    void OnCollisionEnter(Collision col)
    {
        // Player destroys objects BUT the borders
        if (col.gameObject.tag != "Border" && col.gameObject.tag != "Track" && obtainedSpecial == true)
        {
            Destroy(col.gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Special")
        {
            obtainedSpecial = true;

            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Speed")
        {
            obtainedSpeed = true;

            Destroy(col.gameObject);

        }
    }
}
