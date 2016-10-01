using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackCreationTwo : MonoBehaviour
{
    [Header("Tracks")]
    public List<GameObject> startingTracks;
    public List<GameObject> easyTracks;
    public List<GameObject> mediumTracks;
    public List<GameObject> hardTracks;

    [Space(5)]
    public float destroyNum;
    public Transform trackParent;

    [Space(5)]
    public Transform playerTrans;
    Vector3 playerStartPos;

    bool create1;
    bool create2;

    [Header("Difficulty")]
    public float easyNum;
    public float mediumNum;
    public float hardNum;
    public bool isEasy;
    public bool isMedium;
    public bool isHard;

    [Header("Positions")]
    public float yPos1;
    public float yPos2;
    public float zPos;

    GameObject[] track;
    GameObject[] track2;

    public bool isStart;
    [Header("Special Pickups")]
    public bool spawnPickups;
    public float specialAppearNum;
    public List<GameObject> specialObjs;

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

        // Difficulty Change
        if (gMaster.score < mediumNum && gMaster.score < hardNum)   //Easy
        {
            isEasy = true;

            isMedium = false;
            isHard = false;
        }
        else if (gMaster.score >= mediumNum && gMaster.score <= hardNum)  //Medium
        {
            isMedium = true;

            isEasy = false;
            isHard = false;
        }
        else if (gMaster.score >= hardNum) //Hard
        {
            isHard = true;

            isMedium = false;
            isEasy = false;
        }

        TrackMaintance();
    }

    void TrackMaintance()  //When to destroy Tracks
    {
        GameObject[] tracks = GameObject.FindGameObjectsWithTag("Track");
        TrackPositions();

        foreach (GameObject t in tracks)
        {
            if (t.transform.position.y > playerTrans.position.y + destroyNum) // When to destroy platform   45
            {
                Destroy(t);
            }
        }

    }

    void TrackPositions()  // Gets the positions of the tracks and assigns them below
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
            TrackCreation2(pos7, pos8, pos9, pos10);
        }

        //Special Pickups
        if (playerTrans.position.y <= playerStartPos.y - specialAppearNum && spawnPickups)
        {
            Instantiate(specialObjs[Mathf.RoundToInt(Random.Range(0, specialObjs.Count))], new Vector3(playerStartPos.x + 0.85f, playerTrans.position.y - 30, playerStartPos.z), Quaternion.Euler(0, 90, 0));

            specialAppearNum += specialAppearNum;
        }
    }

    void TrackCreation1(Vector3 trackPos1, Vector3 trackPos2, Vector3 trackPos3, Vector3 trackPos4, Vector3 trackPos5, Vector3 trackPos6)   // Instantiates the platforms at the start
    {
        create1 = true;

        foreach (GameObject t in track)
        {
            if (trackPos1.y < t.transform.position.y)  
            {
                create1 = false;
                isStart = false;
            }

            t.transform.parent = trackParent;
        }

        if (create1 && isStart)
        {
            Instantiate(startingTracks[Mathf.RoundToInt(Random.Range(0, startingTracks.Count))], trackPos1, Quaternion.Euler(0, 90, 0));
            Instantiate(startingTracks[Mathf.RoundToInt(Random.Range(0, startingTracks.Count))], trackPos2, Quaternion.Euler(0, 90, 0));
            Instantiate(startingTracks[Mathf.RoundToInt(Random.Range(0, startingTracks.Count))], trackPos3, Quaternion.Euler(0, 90, 0));
            Instantiate(startingTracks[Mathf.RoundToInt(Random.Range(0, startingTracks.Count))], trackPos4, Quaternion.Euler(0, 90, 0));
            Instantiate(startingTracks[Mathf.RoundToInt(Random.Range(0, startingTracks.Count))], trackPos5, Quaternion.Euler(0, 90, 0));
            Instantiate(startingTracks[Mathf.RoundToInt(Random.Range(0, startingTracks.Count))], trackPos6, Quaternion.Euler(0, 90, 0));

            create1 = false;
        }

    }

    void TrackCreation2(Vector3 trackPos1, Vector3 trackPos2, Vector3 trackPos3, Vector3 trackPos4)//, Vector3 trackPos5, Vector3 trackPos6)   // Instantiates the platforms after the start
    {
        create2 = true;

        foreach (GameObject t in track)
        {
            if (trackPos1.y > t.transform.position.y - yPos2 && isStart == false) //22.5f
            {
                // print("False 2");
                create2 = false;
            }

            t.transform.parent = trackParent;
        }

        // Dificulty Change
        if (create2 == true && isEasy == true && isStart == false) // Is Easy
        {
            // print("Create 2");

            Instantiate(easyTracks[Mathf.RoundToInt(Random.Range(0, easyTracks.Count))], trackPos1, Quaternion.Euler(0, 90, 0));
            Instantiate(easyTracks[Mathf.RoundToInt(Random.Range(0, easyTracks.Count))], trackPos2, Quaternion.Euler(0, 90, 0));
            Instantiate(easyTracks[Mathf.RoundToInt(Random.Range(0, easyTracks.Count))], trackPos3, Quaternion.Euler(0, 90, 0));
            Instantiate(easyTracks[Mathf.RoundToInt(Random.Range(0, easyTracks.Count))], trackPos4, Quaternion.Euler(0, 90, 0));

            create2 = false;
        }
        else if (create2 == true && isMedium == true && isStart == false)  // Is Medium
        {
            Instantiate(mediumTracks[Mathf.RoundToInt(Random.Range(0, mediumTracks.Count))], trackPos1, Quaternion.Euler(0, 90, 0));
            Instantiate(mediumTracks[Mathf.RoundToInt(Random.Range(0, mediumTracks.Count))], trackPos2, Quaternion.Euler(0, 90, 0));
            Instantiate(mediumTracks[Mathf.RoundToInt(Random.Range(0, mediumTracks.Count))], trackPos3, Quaternion.Euler(0, 90, 0));
            Instantiate(mediumTracks[Mathf.RoundToInt(Random.Range(0, mediumTracks.Count))], trackPos4, Quaternion.Euler(0, 90, 0));

            create2 = false;

        }
        else if (create2 == true && isHard == true && isStart == false)  // Is Hard
        {
            Instantiate(hardTracks[Mathf.RoundToInt(Random.Range(0, hardTracks.Count))], trackPos1, Quaternion.Euler(0, 90, 0));
            Instantiate(hardTracks[Mathf.RoundToInt(Random.Range(0, hardTracks.Count))], trackPos2, Quaternion.Euler(0, 90, 0));
            Instantiate(hardTracks[Mathf.RoundToInt(Random.Range(0, hardTracks.Count))], trackPos3, Quaternion.Euler(0, 90, 0));
            Instantiate(hardTracks[Mathf.RoundToInt(Random.Range(0, hardTracks.Count))], trackPos4, Quaternion.Euler(0, 90, 0));

            create2 = false;

        }
    }

}
