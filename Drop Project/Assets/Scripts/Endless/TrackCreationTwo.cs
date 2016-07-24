using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackCreationTwo : MonoBehaviour
{
    [Header("Tracks")]
    public List<GameObject> trackObjs;
    public List<GameObject> borderlessTrackObjs;

    [Space(5)]
    public Transform playerTrans;
    Vector3 playerStartPos;

    bool create1;
    bool create2;

    [Space(5)]
    public bool isEasy;
    public bool isHard;

    [Space(5)]
    public float yPos1;
    public float yPos2;
    public float zPos;
    //public float yPos3;
    //public float yPos4;
    //public float yPos5;
    //public float yPos6;


    GameObject[] track;
    GameObject[] track2;

    public bool isStart;

    EndlessGameMaster gMaster;

    // Use this for initialization
    void Awake()
    {
        gMaster = GetComponent<EndlessGameMaster>();

        isStart = true;
        isEasy = true;
        create2 = false;


        playerStartPos = playerTrans.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        track = GameObject.FindGameObjectsWithTag("Track");
        //track2 = GameObject.FindGameObjectsWithTag("Track");

        if (gMaster.score < 10)
        {
            print("Easy");

            isEasy = true;
            isHard = false;
        }
        else
        {
            print("Hard");

            isHard = true;
            isEasy = false;
        }

        TrackMaintance();
    }

    void TrackMaintance()
    {
        //float platCheck = playerTrans.position.y - platformCheck;

        GameObject[] tracks = GameObject.FindGameObjectsWithTag("Track");
        TrackPositions();

        //  print("Istart: " + isStart.ToString());


        foreach (GameObject t in tracks)
        {         // Destroys platforms
            if (t.transform.position.y > playerTrans.position.y + 45)
            {  // When to destroy platform
               //  print("Destroy");
                Destroy(t);
            }
        }


    }

    void TrackPositions()
    {
        // Positions
        Vector3 pos = new Vector3(playerStartPos.x, playerTrans.position.y - yPos1, playerStartPos.z + zPos);
        Vector3 pos2 = new Vector3(playerStartPos.x, playerTrans.position.y - yPos2, playerStartPos.z + zPos);
        Vector3 pos3 = new Vector3(playerStartPos.x, playerTrans.position.y - yPos2 * 2, playerStartPos.z + zPos);
        Vector3 pos4 = new Vector3(playerStartPos.x, playerTrans.position.y - yPos2 * 3, playerStartPos.z + zPos);
        Vector3 pos5 = new Vector3(playerStartPos.x, playerTrans.position.y - yPos2 * 4, playerStartPos.z + zPos);
        Vector3 pos6 = new Vector3(playerStartPos.x, playerTrans.position.y - yPos2 * 5, playerStartPos.z + zPos);

        Vector3 pos7 = new Vector3(playerStartPos.x, playerTrans.position.y - yPos2 * 6, playerStartPos.z + zPos);
        Vector3 pos8 = new Vector3(playerStartPos.x, playerTrans.position.y - yPos2 * 7, playerStartPos.z + zPos);
        Vector3 pos9 = new Vector3(playerStartPos.x, playerTrans.position.y - yPos2 * 8, playerStartPos.z + zPos);
        Vector3 pos10 = new Vector3(playerStartPos.x, playerTrans.position.y - yPos2 * 9, playerStartPos.z + zPos);



        if (isStart)
        {
            TrackCreation1(pos, pos2, pos3, pos4, pos5, pos6);

            create2 = false;
        }
        else if (isStart == false)
        {
            TrackCreation2(pos7, pos8, pos9, pos10);//, pos5, pos6);
        }
    }

    void TrackCreation1(Vector3 trackPos1, Vector3 trackPos2, Vector3 trackPos3, Vector3 trackPos4, Vector3 trackPos5, Vector3 trackPos6)   // Instantiates the platforms at the start
    {
        create1 = true;

        foreach (GameObject t in track)
        {
            if (trackPos1.y < t.transform.position.y)  // To Fix
            {
                create1 = false;
                isStart = false;
            }
            //else
            //{
            //    isStart = true;
            //}
        }

        if (create1 && isStart)
        {
            // print("Create 1");

            Instantiate(trackObjs[Mathf.RoundToInt(Random.Range(0, trackObjs.Count))], trackPos1, Quaternion.Euler(0, 90, 0));
            Instantiate(trackObjs[Mathf.RoundToInt(Random.Range(0, trackObjs.Count))], trackPos2, Quaternion.Euler(0, 90, 0));
            Instantiate(trackObjs[Mathf.RoundToInt(Random.Range(0, trackObjs.Count))], trackPos3, Quaternion.Euler(0, 90, 0));
            Instantiate(trackObjs[Mathf.RoundToInt(Random.Range(0, trackObjs.Count))], trackPos4, Quaternion.Euler(0, 90, 0));
            Instantiate(trackObjs[Mathf.RoundToInt(Random.Range(0, trackObjs.Count))], trackPos5, Quaternion.Euler(0, 90, 0));
            Instantiate(trackObjs[Mathf.RoundToInt(Random.Range(0, trackObjs.Count))], trackPos6, Quaternion.Euler(0, 90, 0));

            create1 = false;
        }

    }

    void TrackCreation2(Vector3 trackPos1, Vector3 trackPos2, Vector3 trackPos3, Vector3 trackPos4)//, Vector3 trackPos5, Vector3 trackPos6)   // Instantiates the platforms at the start
    {
        //print("Track 2");

        create2 = true;

        foreach (GameObject t in track)
        {
            if (trackPos1.y > t.transform.position.y - yPos2 && isStart == false) //22.5f
            {
                // print("False 2");
                create2 = false;
            }
        }

        if (create2 == true && isEasy == true && isStart == false)
        {
            // print("Create 2");

            Instantiate(trackObjs[Mathf.RoundToInt(Random.Range(0, trackObjs.Count))], trackPos1, Quaternion.Euler(0, 90, 0));
            Instantiate(trackObjs[Mathf.RoundToInt(Random.Range(0, trackObjs.Count))], trackPos2, Quaternion.Euler(0, 90, 0));
            Instantiate(trackObjs[Mathf.RoundToInt(Random.Range(0, trackObjs.Count))], trackPos3, Quaternion.Euler(0, 90, 0));
            Instantiate(trackObjs[Mathf.RoundToInt(Random.Range(0, trackObjs.Count))], trackPos4, Quaternion.Euler(0, 90, 0));
            // Instantiate(trackObjs[Mathf.RoundToInt(Random.Range(0, trackObjs.Count))], trackPos5, Quaternion.Euler(0, 90, 0));
            // Instantiate(trackObjs[Mathf.RoundToInt(Random.Range(0, trackObjs.Count))], trackPos6, Quaternion.Euler(0, 90, 0));

            create2 = false;
        }

        if (isHard == true && create2 == true && isStart == false)
        {
            Instantiate(borderlessTrackObjs[Mathf.RoundToInt(Random.Range(0, borderlessTrackObjs.Count))], trackPos1, Quaternion.Euler(0, 90, 0));
            Instantiate(borderlessTrackObjs[Mathf.RoundToInt(Random.Range(0, borderlessTrackObjs.Count))], trackPos2, Quaternion.Euler(0, 90, 0));
            Instantiate(borderlessTrackObjs[Mathf.RoundToInt(Random.Range(0, borderlessTrackObjs.Count))], trackPos3, Quaternion.Euler(0, 90, 0));
            Instantiate(borderlessTrackObjs[Mathf.RoundToInt(Random.Range(0, borderlessTrackObjs.Count))], trackPos4, Quaternion.Euler(0, 90, 0));

        }

    }

}
