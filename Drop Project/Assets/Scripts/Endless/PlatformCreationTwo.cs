﻿using UnityEngine;
using System.Collections;

public class PlatformCreationTwo : MonoBehaviour
{

    public GameObject[] trackOBJ;

    public Transform playerTrans;
    Vector3 playerStartPos;


    // Use this for initialization
    void Awake()
    {

        playerStartPos = playerTrans.position;

    }

    // Update is called once per frame
    void Update()
    {
        PlatformMaintance();

    }

    void PlatformMaintance()
    {
        //float platCheck = playerTrans.position.y - platformCheck;

        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Plat");


        foreach (GameObject plat in platforms)
        {         // Destroys platforms
            if (plat.transform.position.y > playerTrans.position.y + 45)
            {  // When to destroy platform
                Destroy(plat);
            }


        }

        SpawnPlatforms();
    }

    void SpawnPlatforms()  //(UpTo)
    {
        // Positions
        Vector3 pos = new Vector3(playerStartPos.x + 5f, playerTrans.position.y - 10, playerStartPos.z);
        Vector3 pos2 = new Vector3(playerStartPos.x + 5f, playerTrans.position.y - 20, playerStartPos.z);
        Vector3 pos3 = new Vector3(playerStartPos.x + 5f, playerTrans.position.y - 30, playerStartPos.z);
        Vector3 pos4 = new Vector3(playerStartPos.x + 5f, playerTrans.position.y - 40, playerStartPos.z);
        Vector3 pos5 = new Vector3(playerStartPos.x + 5f, playerTrans.position.y - 50, playerStartPos.z);

        PlatformCreation(pos, pos2, pos3, pos4, pos5);

    }



    void PlatformCreation(Vector3 platformPos1, Vector3 platformPos2, Vector3 platformPos3, Vector3 platformPos4, Vector3 platformPos5)//, Vector3 platformPos6)   // Instantiates the platforms at the start
    {
        bool create = true;

        GameObject[] tracks = GameObject.FindGameObjectsWithTag("Track");


        foreach (GameObject t in tracks)
        {
            if (platformPos1.y < t.transform.position.y)
            {
                //print("False");
                create = false;
            }
        }

        if (create)
        {
            Instantiate(trackOBJ[0], platformPos1, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJ[0], platformPos2, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJ[0], platformPos3, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJ[0], platformPos4, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJ[0], platformPos5, Quaternion.Euler(0, 90, 0));
        }

    }
}
