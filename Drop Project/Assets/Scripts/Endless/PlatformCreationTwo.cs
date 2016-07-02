using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformCreationTwo : MonoBehaviour
{

    public List<GameObject> trackOBJs;

    [Space(5)]
    public Transform playerTrans;
    Vector3 playerStartPos;

    [Space(5)]
    public float xPosMin;
    public float xPosMax;

    GameObject[] tracks;




    // Use this for initialization
    void Awake()
    {
        tracks = GameObject.FindGameObjectsWithTag("Track");

        playerStartPos = playerTrans.position;



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlatformMaintance();

    }

    void PlatformMaintance()
    {
        //float platCheck = playerTrans.position.y - platformCheck;



        foreach (GameObject t in tracks)
        {         // Destroys platforms
            if (t.transform.position.y > playerTrans.position.y + 45)
            {  // When to destroy platform
                print("Destroy");
                Destroy(t);
            }
        }

        TrackPlatforms();
    }

    void TrackPlatforms()  //(UpTo)
    {
        // Positions
        Vector3 pos = new Vector3(playerStartPos.x + 5, playerTrans.position.y - 5, playerStartPos.z);
        //Vector3 pos2 = new Vector3(playerStartPos.x + 15, playerTrans.position.y - 30, playerStartPos.z);
        // Vector3 pos3 = new Vector3(playerStartPos.x - 5F, playerTrans.position.y - 30, playerStartPos.z);

        // Vector3 pos4 = new Vector3(playerStartPos.x + (Random.Range(xPosMin, xPosMax)), playerTrans.position.y - 40, playerStartPos.z);
        //  Vector3 pos5 = new Vector3(playerStartPos.x + (Random.Range(xPosMin, xPosMax)), playerTrans.position.y - 50, playerStartPos.z);

        TrackCreation(pos);//, pos2, pos3);//, pos4, pos5);

    }



    void TrackCreation(Vector3 trackPos1)//, Vector3 trackPos2, Vector3 trackPos3)//, Vector3 platformPos4, Vector3 platformPos5)//, Vector3 platformPos6)   // Instantiates the platforms at the start
    {
        bool create = true;

        GameObject[] track = GameObject.FindGameObjectsWithTag("Track");

        foreach (GameObject t in track)
        {
            if (trackPos1.y > t.transform.position.y - 17.5f)  // To Fix
            {
                print("False");
                create = false;
            }
        }

        if (create)
        {
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos1, Quaternion.Euler(0, 90, 0));
            // Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], platformPos2, Quaternion.Euler(0, 90, 0));
            //  Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], platformPos3, Quaternion.Euler(0, 90, 0));

            create = false;
            // Instantiate(trackOBJ[0], platformPos4, Quaternion.Euler(0, 90, 0));
            //  Instantiate(trackOBJ[0], platformPos5, Quaternion.Euler(0, 90, 0));
        }

    }
}
