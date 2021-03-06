﻿using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public float delaySpeedFreefall;
    public float windowSpeed;
    [Space(5)]
    public bool transMove;
    public float transSpeed;
    [Space(5)]
    public float camUpDis;
    public float camDownDis;
    [Space(5)]
    public float disX;
    public float disY;
    public float disZ;
    [Space(5)]
    public float cameraFOVSize;
    [Space(5)]
    public Transform playerTrans;
    public Transform windowCamPos;

    //  Vector3 startingPos;

    bool canChange;

    public bool canMoveCam = true;



    PlayerDroplet playerDrop;

    Rigidbody rig;

    Camera cam;

    // Use this for initialization
    void Start()
    {
        canChange = true;

        cam = GetComponent<Camera>();
        //  rig = GetComponent<Rigidbody>();

        cam.fieldOfView = cameraFOVSize;

        playerDrop = playerTrans.gameObject.GetComponent<PlayerDroplet>();
    }

    void Update()
    {
        
        if (canChange)
        {
            if (playerDrop.isWindow == true)  //Window Mode
            {
                transform.parent = null;

                transform.eulerAngles = new Vector3(0, 0, 0);
                transform.position = new Vector3(windowCamPos.position.x, windowCamPos.position.y, windowCamPos.position.z - 25f);
                canChange = false;
            }
            else            // Infreefall
            {
                transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y + disY, playerTrans.position.z);
               // Vector3.Lerp(transform.position,new Vector3(playerTrans.position.x, playerTrans.position.y + 12, playerTrans.position.z),delaySpeedFreefall);
            }

        }
        else if (playerDrop.puddleMode == false)  //  Movedown window
        {
            gameObject.AddComponent<Rigidbody>();

            rig = GetComponent<Rigidbody>();
            rig.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            rig.useGravity = false;
            rig.drag = 1;

            rig.AddForce(0, -windowSpeed, 0);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //startingPos = transform.position;

        Vector3 viewPos = cam.WorldToViewportPoint(playerTrans.position);

        if (playerDrop.isWindow)
        {
            if (viewPos.y > camUpDis)
            {
                print("Up");
            }
            else if (viewPos.y < camDownDis)
            {
                print("Down");
            }
        }
        else if (playerDrop.isFreefall)
        {
            if (viewPos.y > camUpDis)
            {
                print("Freefall Up");
            }
            else if (viewPos.y < camDownDis)
            {
                print("Down");
            }

        }


        if (playerDrop.puddleMode == true && canMoveCam == true)
        {
            //print("In Puddle: Camera");

            transform.position = new Vector3(playerDrop.transform.position.x, playerDrop.transform.position.y + 2, playerDrop.transform.position.z - 25f);
            transform.eulerAngles = new Vector3(30, 0, 0);
            canMoveCam = false;


        }

    }


}
