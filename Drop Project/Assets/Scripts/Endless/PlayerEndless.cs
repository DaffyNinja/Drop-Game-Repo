using UnityEngine;
using System.Collections;

public class PlayerEndless : MonoBehaviour
{

    public float fallSpeed;
    public float leftRightSpeed;

    public float turnAmmount;
    Quaternion startingRotation;

    [Header("Special Pickup")]
    public float fallSpeedIncrease;
    public Vector3 specialSize;
    Vector3 startingSize;

    public float powerTime;
    public bool obtainedSpecialDrop;

    float specialTimer;

    [Header("Touch")]
    public float screenPosX;

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
        screenPosX = Screen.width / 2;

        rig = GetComponent<Rigidbody>();

        startingRotation = transform.rotation;

        startingSize = transform.localScale;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Controlls
        if (isPC)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                Vector3 moveQauntity = new Vector3(leftRightSpeed, 0, 0);
                rig.velocity = new Vector3(moveQauntity.x, rig.velocity.y, rig.velocity.z);

                transform.rotation = Quaternion.Euler(-turnAmmount, 90, 0);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                Vector3 moveQauntity = new Vector3(-leftRightSpeed, 0, 0);
                rig.velocity = new Vector3(moveQauntity.x, rig.velocity.y, rig.velocity.z);

                transform.rotation = Quaternion.Euler(turnAmmount, 90, 0);
            }
            else
            {
                transform.rotation = startingRotation;
            }

        }
        else if (isTouch)    // TOuch controls
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

        Vector2 fallQauntity = new Vector2(0, -fallSpeed);
        rig.velocity = new Vector2(rig.velocity.x, fallQauntity.y);

        PowerPickup();
    }

    void PowerPickup()
    {
        if (obtainedSpecialDrop)
        {
            transform.localScale = specialSize;
            rig.AddForce(0, -fallSpeed + fallSpeedIncrease, 0);

            specialTimer += Time.deltaTime;

            if (specialTimer >= powerTime)
            {
                transform.localScale = startingSize;
                obtainedSpecialDrop = false;
            }
        }
        else
        {
            specialTimer = 0;
        }


    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Plat")
        {
            print("plat");

            if (obtainedSpecialDrop == true)
            {
                Destroy(col.gameObject);
            }

           
        }

        //Destroy(col.gameObject);

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Border")
        {
            print("Border Hit");
        }

        if (col.gameObject.tag == "Special")
        {
            print("Special Hit");

            obtainedSpecialDrop = true;

            Destroy(col.gameObject);

        }


    }
}
