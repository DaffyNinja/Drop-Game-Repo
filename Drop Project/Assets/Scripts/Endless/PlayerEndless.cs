using UnityEngine;
using System.Collections;

public class PlayerEndless : MonoBehaviour
{

    public float fallSpeed;
    public float leftRightSpeed;

    public bool slowWhenTurn;
    public float turnFallSpeed;

    float startingTurnSpeed;

    [Space(5)]
    public float turnAmmount;
    Quaternion startingRotation;

    [Header("Special Abilities")]
    public float specialFallSpeed;
    public float specialTurnSpeed;
    [Space(5)]
    public float boostFallSpeed;
    [Space(5)]
    public Vector3 specialSize;
    public Vector3 boostSize;

    Vector3 startingSize;
    [Space(5)]
    public float specialTime;
    public float boostTime;
    [Space(5)]
    public Color specialCol;
    public Color boostCol;
    [Space(5)]
    public bool obtainedSpecial;
    public bool obtainedBoost;

    float specialTimer;

    [Header("Touch")]
    public float screenPosX;

    public bool moveRight;
    public bool moveLeft;

    Vector2 touchPos;

    [Header("Acceleromater")]
    public float disNum;
    Vector3 startAccPos;

    [Space(5)]
    Renderer dropRend;
    Renderer eyeRend;

    Color dropStartCol1;
    Color dropStartCol2;

    Color eyeStartCol;

    [Header("Controls")]
    public bool isPC;
    public bool isMobile;

    bool canMove;

    [Space(5)]
    public bool debugTouch;
    public bool debugAccel;

    static public bool isTouch;
    static public bool isAccelerate;

    Rigidbody rig;

    Transform[] t;
    Transform firstChild;
    Transform secondChild;


    void Awake()
    {
        canMove = true;

        startAccPos = Input.acceleration.normalized;

        screenPosX = Screen.width / 2;

        rig = GetComponent<Rigidbody>();

        startingRotation = transform.rotation;
        startingSize = transform.localScale;
        startingTurnSpeed = leftRightSpeed;

        // Materials/Colours
        t = gameObject.GetComponentsInChildren<Transform>();
        firstChild = t[1];
        secondChild = t[2];

        dropRend = firstChild.gameObject.GetComponent<Renderer>();
        eyeRend = secondChild.gameObject.GetComponent<Renderer>();

        dropStartCol1 = dropRend.materials[0].color;
        dropStartCol2 = dropRend.materials[1].color;

        eyeStartCol = eyeRend.material.color;

    }

    void FixedUpdate()
    {
        // Controls
        if (canMove)
        {
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
                        moveRight = true;
                        moveLeft = false;

                    }
                    else if (Input.acceleration.normalized.x < startAccPos.x - disNum) // Left   0.25
                    {
                        moveLeft = true;
                        moveRight = false;

                    }
                    else
                    {
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
        }

        if (obtainedSpecial || obtainedBoost) // Powerups
        {

            // Special PowerUp
            if (obtainedSpecial)
            {
                dropRend.materials[1].color = specialCol;

                transform.localScale = specialSize;

                Vector2 fallQauntity = new Vector2(0, -specialFallSpeed);
                rig.velocity = new Vector2(rig.velocity.x, fallQauntity.y);

                slowWhenTurn = false;
                leftRightSpeed = specialTurnSpeed;

                specialTimer += Time.deltaTime;

                if (specialTimer >= specialTime)
                {
                    transform.localScale = startingSize;
                    specialTimer = 0;
                    slowWhenTurn = true;
                    obtainedSpecial = false;
                }

            }

            // Boost
            if (obtainedBoost)
            {

                dropRend.materials[1].color = boostCol;

                canMove = false;

                firstChild.gameObject.GetComponent<Collider>().enabled = false;


                transform.localScale = boostSize;

                Vector2 fallQauntity = new Vector2(0, -boostFallSpeed);
                rig.velocity = new Vector2(rig.velocity.x, fallQauntity.y);

                slowWhenTurn = false;

                specialTimer += Time.deltaTime;

                moveLeft = false;
                moveRight = false;

                if (specialTimer >= boostTime)
                {
                    transform.localScale = startingSize;
                    specialTimer = 0;
                    canMove = true;
                    slowWhenTurn = true;
                    firstChild.gameObject.GetComponent<Collider>().enabled = true;
                    obtainedBoost = false;
                }
            }

        }
        else if (obtainedSpecial == false && moveLeft == false && moveRight == false || obtainedBoost == false)       //Normal Falling and turn Speed
        {
            Vector2 fallQauntity = new Vector2(0, -fallSpeed);
            rig.velocity = new Vector2(rig.velocity.x, fallQauntity.y);

            slowWhenTurn = true;
            leftRightSpeed = startingTurnSpeed;

            dropRend.materials[1].color = dropStartCol2;
        }

        if (slowWhenTurn == true && moveLeft == true || moveRight == true)  // Fall speed decerases when turn left or right
        {
            Vector2 fallQauntity = new Vector2(0, -turnFallSpeed);
            rig.velocity = new Vector2(rig.velocity.x, fallQauntity.y);

        }
    }

    void OnCollisionEnter(Collision col)
    {
        // Player destroys objects BUT the borders
        if (col.gameObject.tag != "Border" && col.gameObject.tag != "Track" && obtainedSpecial == true || col.gameObject.tag != "Border" && col.gameObject.tag != "Track" && obtainedBoost == true)
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

        if (col.gameObject.tag == "Boost")
        {
            obtainedBoost = true;

            Destroy(col.gameObject);

        }
    }
}
