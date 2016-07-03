﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackCreationTwo : MonoBehaviour
{

    public List<GameObject> trackOBJs;

    [Space(5)]
    public Transform playerTrans;
    Vector3 playerStartPos;

    bool create1;
    bool create2;

    [Space(5)]
    public float xPosMin;
    public float xPosMax;

    GameObject[] track;
    GameObject[] track2;
    bool isStart;




    // Use this for initialization
    void Awake()
    {
        isStart = true;

        playerStartPos = playerTrans.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        track = GameObject.FindGameObjectsWithTag("Track");
        //track2 = GameObject.FindGameObjectsWithTag("Track");

        PlatformMaintance();
    }

    void PlatformMaintance()
    {
        //float platCheck = playerTrans.position.y - platformCheck;

        GameObject[] tracks = GameObject.FindGameObjectsWithTag("Track");
        TrackPlatforms();

        print("Istart: " + isStart.ToString());


        foreach (GameObject t in tracks)
        {         // Destroys platforms
            if (t.transform.position.y > playerTrans.position.y + 30)
            {  // When to destroy platform
               //  print("Destroy");
                Destroy(t);
            }
        }


    }

    void TrackPlatforms()  //(UpTo)
    {
        // Positions
        Vector3 pos = new Vector3(playerStartPos.x + 5, playerTrans.position.y, playerStartPos.z);
        Vector3 pos2 = new Vector3(playerStartPos.x + 5, playerTrans.position.y - 15, playerStartPos.z);
        Vector3 pos3 = new Vector3(playerStartPos.x + 5F, playerTrans.position.y - 30, playerStartPos.z);
        Vector3 pos4 = new Vector3(playerStartPos.x + 5, playerTrans.position.y - 45, playerStartPos.z);
        Vector3 pos5 = new Vector3(playerStartPos.x + 5, playerTrans.position.y - 60, playerStartPos.z);

        if (isStart)
        {
            TrackCreation1(pos, pos2, pos3, pos4, pos5);
        }
        else
        {
            TrackCreation2(pos, pos2, pos3, pos4, pos5);
        }
    }

    void TrackCreation1(Vector3 trackPos1, Vector3 trackPos2, Vector3 trackPos3, Vector3 trackPos4, Vector3 trackPos5)//, Vector3 platformPos6)   // Instantiates the platforms at the start
    {
        create1 = true;

        foreach (GameObject t in track)
        {
            if (trackPos3.y < t.transform.position.y)  // To Fix
            {
                // print("False 1");
                create1 = false;
                isStart = false;
            }
        }

        if (create1 && isStart)
        {
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos1, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos2, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos3, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos4, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos5, Quaternion.Euler(0, 90, 0));

            create1 = false;
        }

    }

    void TrackCreation2(Vector3 trackPos1, Vector3 trackPos2, Vector3 trackPos3, Vector3 trackPos4, Vector3 trackPos5)//, Vector3 platformPos6)   // Instantiates the platforms at the start
    {
        create2 = true;

        foreach (GameObject t in track)
        {
            if (trackPos3.y > t.transform.position.y - 15)  // To Fix
            {
                // print("False 2");
                create2 = false;
            }
        }

        if (create2 && !isStart)
        {
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos1, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos2, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos3, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos4, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos5, Quaternion.Euler(0, 90, 0));

            create2 = false;
        }

    }

}