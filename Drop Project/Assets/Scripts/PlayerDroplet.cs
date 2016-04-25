using UnityEngine;
using System.Collections;

public class PlayerDroplet : MonoBehaviour
{

    public float fallSpeed;
    public float leftRightspeed;
    public float slowSpeed;

    float startSpeed;
    float startingFallSpeed;

    [Header("Touch")]
    public float screenPosX;
    public float upScreenPos;
    public float midScreenPos;

    public bool moveRight;
    public bool moveLeft;
    public bool moveUp;

    [Space(5)]
    public float quickSpeed;
    public bool canMoveDown;
    public bool moveDown;

    Vector2 touchPos;

    [Space(5)]
    public bool pcControls;
    public bool touchControls;


    [Header("Split")]
    public float splitPosX; 
    public bool canSplit;

    GameObject splitDropObj;

    [Header("LargeDrop")]
    public float largeFallSpeed;
    public float largeLeftRightSpeed;
    public Vector3 dropScale;
    public bool isLarge;


    [Header("Droplet Pickup")]
    public float fallSpeedIncrease;
    public float sizeIncrease;

    public float timeTillDecrease;
    public bool obtainedDrop;

    float dropTimer;
    Vector3 startingSize;

    private Rigidbody rig;

    [Space(5)]
    public GameMaster gMaster;



    // Use this for initialization
    void Start()
    {

        rig = GetComponent<Rigidbody>();

        startingSize = transform.localScale;

        startingFallSpeed = fallSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        Controls();

        if (canSplit)
        {
            splitDropObj = this.gameObject;

            transform.position = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);

            Vector3 splitObjPos = new Vector3(transform.position.x + splitPosX, transform.position.y, transform.position.z);

            GameObject clone = Instantiate(splitDropObj, splitObjPos, Quaternion.identity) as GameObject;

            clone.GetComponent<PlayerDroplet>().canSplit = false;

            canSplit = false;
        }

        if (obtainedDrop)
        {
            dropTimer += Time.deltaTime;

            if (dropTimer >= timeTillDecrease)
            {
                transform.localScale = startingSize;

                fallSpeed = startingFallSpeed;

                obtainedDrop = false;

            }
        }
        else if (!obtainedDrop)
        {
            dropTimer = 0;
        }

        if (isLarge == true)
        {
            LargeDropVoid();

        }


       // print(canSplit.ToString());

    }

    void Controls()
    {

        if (touchControls)
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

            if (touchPos.y > upScreenPos)
            {
                //print("Up");

                moveUp = true;
            }
            else if (touchPos.y < upScreenPos && touchPos.y > 0)
            {
                // print("Middle");
                moveUp = false;
            }




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

            if (moveUp)
            {
                Vector2 moveQauntity = new Vector2(0, -slowSpeed);
                rig.velocity = new Vector2(rig.velocity.x, moveQauntity.y);

                GetComponentInChildren<Renderer>().material.color = Color.red;

            }
            else if (canMoveDown && moveDown)
            {
                Vector2 moveQauntity = new Vector2(0, -quickSpeed);
                rig.velocity = new Vector2(rig.velocity.x, moveQauntity.y);

                GetComponentInChildren<Renderer>().material.color = Color.green;
            }
            else
            {

                Vector2 fallQauntity = new Vector2(0, -fallSpeed);
                rig.velocity = new Vector2(rig.velocity.x, fallQauntity.y);

                GetComponentInChildren<Renderer>().material.color = Color.yellow;
            }

        }


        if (pcControls)
        {
            // PC || Left Right                                                       
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                Vector2 moveQauntity = new Vector2(leftRightspeed, 0);
                rig.velocity = new Vector2(moveQauntity.x, rig.velocity.y);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {

                Vector2 moveQauntity = new Vector2(-leftRightspeed, 0);
                rig.velocity = new Vector2(moveQauntity.x, rig.velocity.y);
            }

            // Down Up and Fall
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                Vector2 moveQauntity = new Vector2(0, -slowSpeed);
                rig.velocity = new Vector2(rig.velocity.x, moveQauntity.y);

                GetComponentInChildren<Renderer>().material.color = Color.red;
            }
            else if (canMoveDown && Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                Vector2 moveQauntity = new Vector2(0, -quickSpeed);
                rig.velocity = new Vector2(rig.velocity.x, moveQauntity.y);

                GetComponentInChildren<Renderer>().material.color = Color.green;
            }
            else
            {
                Vector2 fallQauntity = new Vector2(0, -fallSpeed);
                rig.velocity = new Vector2(rig.velocity.x, fallQauntity.y);

                GetComponentInChildren<Renderer>().material.color = Color.yellow;
            }
        }

        /* // Xbox Controller
        if (Input.GetAxis("Horizontal") >= 1)
        {
            // print("Right");

            Vector2 moveQauntity = new Vector2(leftRightspeed, 0);
            rig2D.velocity = new Vector2(moveQauntity.x, rig2D.velocity.y);



        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            // print("Left");


            Vector2 moveQauntity = new Vector2(-leftRightspeed, 0);
            rig2D.velocity = new Vector2(moveQauntity.x, rig2D.velocity.y);


        } */

    }

    void LargeDropVoid()
    {
        transform.localScale = dropScale;

        fallSpeed = largeFallSpeed;

        //isLarge = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Dry" && isLarge == true)
        {
            Destroy(col.gameObject);

        }

    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Large Drop")
        {
            isLarge = true;

            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Drop Pick")
        {

            obtainedDrop = true;

            transform.localScale = new Vector3(transform.localScale.x + sizeIncrease, transform.localScale.y + sizeIncrease, transform.localScale.z + sizeIncrease);

            fallSpeed += fallSpeedIncrease;

            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Gold")
        {
            gMaster.goldNum += 1;

            Destroy(col.gameObject);
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Split")
        {
            canSplit = true;
        }
   
    }
}