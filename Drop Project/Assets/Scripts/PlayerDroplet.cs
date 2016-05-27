﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerDroplet : MonoBehaviour
{

    public float fallSpeed;

    public float freeFallLeftRightSpeed;
    public float freeFallFowardBackSpeed;

    public float windowFallSpeed;
    public float windowLeftRightSpeed;
    [Space(5)]
    public bool canSlowDown;
    public float slowSpeed;
    public float slowLRSpeed;

    float startingFallSpeed;
    float startingLRSpeed;

    [Header("Modes")]
    public bool isFreefall;
    public bool isWindow;

    public bool puddleMode;



    [Header("Touch")]
    public float screenPosX;
    public float upScreenPos;
    public float midScreenPos;

    public bool moveRight;
    public bool moveLeft;
    public bool moveUp;


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
    [Space(5)]
    public float largeDropTime;
    float largeTimer;


    [Header("Droplet Pickup")]
    public float fallSpeedIncrease;
    public Vector3 speedSize;
    // public float sizeIncrease;

    public float timeTillDecrease;
    public bool obtainedDrop;

    float dropTimer;
    Vector3 startingSize;

    private Rigidbody rig;

    [Space(5)]
    public Transform windowPos;

    [Space(5)]
    public GameMaster gMaster;




    // Use this for initialization
    void Start()
    {

        rig = GetComponent<Rigidbody>();

        startingSize = transform.localScale;

        startingFallSpeed = fallSpeed;

        startingLRSpeed = windowLeftRightSpeed;

    }

    // Update is called once per frame
    void Update()
    {

        Controls();

        if (obtainedDrop)
        {
            print("Drop");

            transform.localScale = speedSize;

            rig.AddForce(0, -fallSpeedIncrease, 0);

            dropTimer += Time.deltaTime;

            if (dropTimer >= timeTillDecrease)
            {
                transform.localScale = startingSize;

                //fallSpeed = startingFallSpeed;



                obtainedDrop = false;
            }
        }
        else
        {
            dropTimer = 0;
        }

        if (canSplit)
        {
            splitDropObj = this.gameObject;

            transform.position = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);

            Vector3 splitObjPos = new Vector3(transform.position.x + splitPosX, transform.position.y, transform.position.z);

            GameObject clone = Instantiate(splitDropObj, splitObjPos, Quaternion.identity) as GameObject;

            clone.GetComponent<PlayerDroplet>().canSplit = false;

            canSplit = false;
        }

        //if (obtainedDrop == true)
        //{
        //    //print("Obtained Drop");

        //    SpeedDroplet();

        //}
        //else if (!obtainedDrop)
        //{
        //    dropTimer = 0;
        //}

        if (isLarge == true)
        {
            LargeDropVoid();
        }
        else if (isLarge == false && obtainedDrop == false)
        {
           // fallSpeed = startingFallSpeed;
            windowLeftRightSpeed = startingLRSpeed;
            transform.localScale = startingSize;
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
            else if (touchPos.y < upScreenPos && touchPos.y > 0 && canSlowDown == true)
            {
                // print("Middle");
                moveUp = false;
            }




            if (moveRight)
            {
                Vector2 moveQauntity = new Vector2(windowLeftRightSpeed, 0);
                rig.velocity = new Vector2(moveQauntity.x, rig.velocity.y);
                // moveRight = false;
            }
            else if (moveLeft)
            {

                Vector2 moveQauntity = new Vector2(-windowLeftRightSpeed, 0);
                rig.velocity = new Vector2(moveQauntity.x, rig.velocity.y);
                //moveLeft = false;

            }

            if (moveUp)
            {
                Vector2 moveQauntity = new Vector2(0, -slowSpeed);
                rig.velocity = new Vector2(rig.velocity.x, moveQauntity.y);



                // GetComponentInChildren<Renderer>().material.color = Color.red;

            }



            Vector2 fallQauntity = new Vector2(0, -fallSpeed);
            rig.velocity = new Vector2(rig.velocity.x, fallQauntity.y);

            //  GetComponentInChildren<Renderer>().material.color = Color.yellow;


        }


        if (pcControls)
        {
            if (isFreefall == false) // In window
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, windowPos.transform.position.z);

                rig.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

                // PC || Left Right  
                if (puddleMode == false)
                {
                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                    {
                        Vector3 moveQauntity = new Vector3(windowLeftRightSpeed, 0, 0);
                        rig.velocity = new Vector3(moveQauntity.x, rig.velocity.y, rig.velocity.z);
                    }
                    else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                    {
                        Vector3 moveQauntity = new Vector3(-windowLeftRightSpeed, 0, 0);
                        rig.velocity = new Vector3(moveQauntity.x, rig.velocity.y, rig.velocity.z);
                    }
                }

                Vector2 fallQauntity = new Vector2(0, -windowFallSpeed);
                rig.velocity = new Vector2(rig.velocity.x, fallQauntity.y);

                windowLeftRightSpeed = startingLRSpeed;

            }
            else // In free fall  
            {


                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    Vector3 moveQauntity = new Vector3(freeFallLeftRightSpeed, 0, 0);
                    rig.velocity = new Vector3(moveQauntity.x, rig.velocity.y, rig.velocity.z);

                }
                else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    Vector3 moveQauntity = new Vector3(-freeFallLeftRightSpeed, 0, 0);
                    rig.velocity = new Vector3(moveQauntity.x, rig.velocity.y, rig.velocity.z);
                }

                // Up and Fall
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, freeFallFowardBackSpeed);
                }
                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, -freeFallFowardBackSpeed);
                }
                else
                {
                    Vector3 fallQauntity = new Vector3(0, -fallSpeed, 0);
                    rig.velocity = new Vector3(rig.velocity.x, fallQauntity.y, rig.velocity.z);
                }

            }


        }
    }


    void LargeDropVoid()
    {
        //print("Hit");

        transform.localScale = dropScale;

        fallSpeed = largeFallSpeed;

        GetComponentInChildren<Renderer>().material.color = Color.white;

        largeTimer += Time.deltaTime;

        if (largeTimer >= largeDropTime)
        {
            GetComponentInChildren<Renderer>().material.color = Color.blue;
            largeTimer = 0;
            isLarge = false;
        }

        //isLarge = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Dry" && isLarge == true)
        {
            Destroy(col.gameObject);

        }

        if (col.gameObject.tag == "Puddle")
        {
            SceneManager.LoadScene(0);
        }

    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Window Trig")
        {
            isFreefall = false;
            isWindow = true;
        }

        if (col.gameObject.tag == "Large Drop")
        {
            isLarge = true;

            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Drop Pick")
        {
            // print("Drop");

            obtainedDrop = true;

            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Gold")
        {
            gMaster.goldNum += 1;

            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "End Point")
        {
            puddleMode = true;
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