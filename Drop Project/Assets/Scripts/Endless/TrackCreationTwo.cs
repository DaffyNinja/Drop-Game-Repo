using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackCreationTwo : MonoBehaviour
{

    public List<GameObject> trackOBJs;

    [Space(5)]
    public Transform playerTrans;
    Vector3 playerStartPos;

    [Space(5)]
    public float xPosMin;
    public float xPosMax;

    GameObject[] track;




    // Use this for initialization
    void Awake()
    {


        playerStartPos = playerTrans.position;



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        track = GameObject.FindGameObjectsWithTag("Track");

        PlatformMaintance();

    }

    void PlatformMaintance()
    {
        //float platCheck = playerTrans.position.y - platformCheck;

        GameObject[] tracks = GameObject.FindGameObjectsWithTag("Track");



        foreach (GameObject t in tracks)
        {         // Destroys platforms
            if (t.transform.position.y > playerTrans.position.y + 10)
            {  // When to destroy platform
                print("Destroy");
                Destroy(t);
            }
        }

        TrackPlatforms1();
    }

    void TrackPlatforms1()  //(UpTo)
    {
        // Positions
        Vector3 pos = new Vector3(playerStartPos.x + 5, playerTrans.position.y - 5, playerStartPos.z);
        Vector3 pos2 = new Vector3(playerStartPos.x + 5, playerTrans.position.y - 30, playerStartPos.z);
        Vector3 pos3 = new Vector3(playerStartPos.x + 5F, playerTrans.position.y - 50, playerStartPos.z);
        Vector3 pos4 = new Vector3(playerStartPos.x + 5, playerTrans.position.y - 70, playerStartPos.z);
        Vector3 pos5 = new Vector3(playerStartPos.x + 5, playerTrans.position.y - 90, playerStartPos.z);

        TrackCreation1(pos, pos2, pos3, pos4, pos5);

    }



    void TrackCreation1(Vector3 trackPos1, Vector3 trackPos2, Vector3 trackPos3, Vector3 trackPos4, Vector3 trackPos5)//, Vector3 platformPos6)   // Instantiates the platforms at the start
    {
        bool create = true;

        foreach (GameObject t in track)
        {
            if (trackPos5.y > t.transform.position.y - 30)  // To Fix
            {
                print("False");
                create = false;
            }
        }

        if (create)
        {
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos1, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos2, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos3, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos4, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos5, Quaternion.Euler(0, 90, 0));

            create = false;
        }

    }


}
