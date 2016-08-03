using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackCreationEndless : MonoBehaviour
{
    [Header("Platforms")]
    public List<GameObject> easyTracksList;
    public List<GameObject> mediumTracksList;
    public List<GameObject> hardTracksList;
    [Space(5)]
    public GameObject mergeTrack;
    public GameObject splitTrack;
    [Space(10)]
    public Transform playerTrans;
    Vector3 playerPos;

    // public float spawnLimit;
    public float destroyNum;

    public Transform platParent;

    bool canSpawnPlatforms;

    bool create1;
    bool create2;

    GameObject[] splitMergeOBJs;
    bool createSplitandMerge;
    bool spawnSplitTracks;

    bool makeSplit;
    bool makeSplitTracks;
    bool makeMerge;

    GameObject[] tracks1;
    GameObject[] tracks2;

    //float platfromsSpawnedUp;
    //int platIndex;
    //int platNum;

    [Header("Game Master")]
    public bool isEasy;
    [Space(5)]
    public int mediumStartNum;
    public bool isMedium;
    [Space(5)]
    public int hardStartNum;
    public bool isHard;
    [Space(5)]
    public float hardPos1;
    public float hardPos2;
    public float hardPos3;
    public float hardPos4;
    [Space(5)]
    public int splitNum;
    public int mergeNum;

    [Header("Pickups")]
    public GameObject specialObj;
    [Space(5)]
    public float speacialAppearNum;

    EndlessGameMaster gMaster;

    //bool make;

    void Awake()
    {
        canSpawnPlatforms = true;
        createSplitandMerge = true;

        playerPos = playerTrans.position;

        gMaster = GetComponent<EndlessGameMaster>();

        isEasy = true;
    }

    void Update()
    {
        tracks1 = GameObject.FindGameObjectsWithTag("Track");
        tracks2 = GameObject.FindGameObjectsWithTag("Track");

        PlatformMaintance();

        // Changes difficulty depending on how far the player has gone based on the score 
        if (gMaster.score >= mediumStartNum && gMaster.score < hardStartNum)   // Medium
        {
            isEasy = false;
            isHard = false;

            isMedium = true;
        }
        else if (gMaster.score >= hardStartNum)      // Hard
        {
            isHard = true;
            isMedium = false;
        }

    }

    void PlatformMaintance()
    {
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Track");
        splitMergeOBJs = GameObject.FindGameObjectsWithTag("SplitMerge");

        foreach (GameObject plat in platforms)
        {         // Destroys platforms
            if (plat.transform.position.y > playerTrans.position.y + destroyNum)
            {  // When to destroy platform
                Destroy(plat);
            }

        }

        //// Player has passed split/Merge object
        //foreach (GameObject plat in splitMergeOBJs)
        //{
        //    if (plat.transform.position.y > playerTrans.position.y)
        //    {
        //        //print("Over Split/Merge");

        //        canSpawnPlatforms = true;
        //        makeSplit = false;
        //    }
        //}

        SpawnPlatforms();
    }

    void SpawnPlatforms()  //(UpTo)
    {
        // Positions
        Vector3 pos = new Vector3(playerPos.x, playerTrans.position.y - 5, playerPos.z);
        Vector3 pos2 = new Vector3(playerPos.x, playerTrans.position.y - 20, playerPos.z);
        Vector3 pos3 = new Vector3(playerPos.x, playerTrans.position.y - 35, playerPos.z);
        Vector3 pos4 = new Vector3(playerPos.x, playerTrans.position.y - 50, playerPos.z);
        Vector3 pos5 = new Vector3(playerPos.x, playerTrans.position.y - 65, playerPos.z);

        Vector3 pos7 = new Vector3(playerPos.x, playerTrans.position.y - 80, playerPos.z);
        Vector3 pos8 = new Vector3(playerPos.x, playerTrans.position.y - 95, playerPos.z);
        Vector3 pos9 = new Vector3(playerPos.x, playerTrans.position.y - 110, playerPos.z);
        Vector3 pos10 = new Vector3(playerPos.x, playerTrans.position.y - 125, playerPos.z);

        Vector3 posHard1 = new Vector3(playerPos.x, playerTrans.position.y - hardPos1, playerPos.z);
        Vector3 posHard2 = new Vector3(playerPos.x, playerTrans.position.y - hardPos2, playerPos.z);
        Vector3 posHard3 = new Vector3(playerPos.x, playerTrans.position.y - hardPos3, playerPos.z);
        Vector3 posHard4 = new Vector3(playerPos.x, playerTrans.position.y - hardPos4, playerPos.z);


        // TODO: Add hard platform psoition, to compoinsate for the new scale sizes 

        PlatformCreation1(pos, pos2, pos3, pos4, pos5);//, pos6);

        if (isHard)
        {
            PlatformCreation2(posHard1, posHard2, posHard3, posHard4);
        }
        else
        {
            PlatformCreation2(pos7, pos8, pos9, pos10);
        }

        // Special Pickup Creation
        if (playerTrans.position.y <= playerPos.y - speacialAppearNum)
        {
            print("Special");

            Instantiate(specialObj, new Vector3(playerPos.x, playerTrans.position.y - 20, playerPos.z), Quaternion.Euler(0, 90, 0));

            speacialAppearNum += speacialAppearNum;
        }


    }



    void PlatformCreation1(Vector3 platformPos1, Vector3 platformPos2, Vector3 platformPos3, Vector3 platformPos4, Vector3 platformPos5)//, Vector3 platformPos6)   // Instantiates the platforms at the start
    {
        if (canSpawnPlatforms)
        {
            create1 = true;

            foreach (GameObject t in tracks1)
            {
                if (platformPos1.y < t.transform.position.y)        // When to spawn new platforms  NOTE: Make 5f and public variable
                {
                    create1 = false;
                }

                t.transform.parent = platParent;

            }

            if (create1 && isEasy)  // Start off Easy
            {
                Instantiate(easyTracksList[Mathf.RoundToInt(Random.Range(0, easyTracksList.Count))], platformPos1, Quaternion.identity);
                Instantiate(easyTracksList[Mathf.RoundToInt(Random.Range(0, easyTracksList.Count))], platformPos2, Quaternion.identity);
                Instantiate(easyTracksList[Mathf.RoundToInt(Random.Range(0, easyTracksList.Count))], platformPos3, Quaternion.identity);
                Instantiate(easyTracksList[Mathf.RoundToInt(Random.Range(0, easyTracksList.Count))], platformPos4, Quaternion.identity);
                Instantiate(easyTracksList[Mathf.RoundToInt(Random.Range(0, easyTracksList.Count))], platformPos5, Quaternion.identity);

            }
        }

    }

    void PlatformCreation2(Vector3 platformPos1, Vector3 platformPos2, Vector3 platformPos3, Vector3 platformPos4) // Instantiates the platforms continualsy after the start
    {
        if (canSpawnPlatforms)
        {
            create2 = true;

            foreach (GameObject t in tracks2)
            {
                if (platformPos1.y > t.transform.position.y - 15)
                {  // When to spawn new platforms  NOTE: Make 5f and public variable
                    create2 = false;
                }

                t.transform.parent = platParent;
            }

            if (create2 && isEasy)
            {   // Easy
                Instantiate(easyTracksList[Mathf.RoundToInt(Random.Range(0, easyTracksList.Count))], platformPos1, Quaternion.identity);
                Instantiate(easyTracksList[Mathf.RoundToInt(Random.Range(0, easyTracksList.Count))], platformPos2, Quaternion.identity);
                Instantiate(easyTracksList[Mathf.RoundToInt(Random.Range(0, easyTracksList.Count))], platformPos3, Quaternion.identity);
                Instantiate(easyTracksList[Mathf.RoundToInt(Random.Range(0, easyTracksList.Count))], platformPos4, Quaternion.identity);

            }
            else if (create2 && isMedium)
            {   // Medium
                Instantiate(mediumTracksList[Mathf.RoundToInt(Random.Range(0, mediumTracksList.Count))], platformPos1, Quaternion.identity);
                Instantiate(mediumTracksList[Mathf.RoundToInt(Random.Range(0, mediumTracksList.Count))], platformPos2, Quaternion.identity);
                Instantiate(mediumTracksList[Mathf.RoundToInt(Random.Range(0, mediumTracksList.Count))], platformPos3, Quaternion.identity);
                Instantiate(mediumTracksList[Mathf.RoundToInt(Random.Range(0, mediumTracksList.Count))], platformPos4, Quaternion.identity);

            }
            else if (create2 && isHard)
            {  // Hard
                Instantiate(hardTracksList[Mathf.RoundToInt(Random.Range(0, hardTracksList.Count))], platformPos1, Quaternion.identity);
                Instantiate(hardTracksList[Mathf.RoundToInt(Random.Range(0, hardTracksList.Count))], platformPos2, Quaternion.identity);
                Instantiate(hardTracksList[Mathf.RoundToInt(Random.Range(0, hardTracksList.Count))], platformPos3, Quaternion.identity);
                Instantiate(hardTracksList[Mathf.RoundToInt(Random.Range(0, hardTracksList.Count))], platformPos4, Quaternion.identity);

            }
        }


    }

    // Split Tracks
    void SplitandMerge()
    {
        Vector3 splitPos = new Vector3(playerPos.x, playerTrans.position.y - 130, playerPos.z);
        makeSplit = true;

        if (makeSplit)
        {
            print("Split");

            if (createSplitandMerge)
            {
                Instantiate(splitTrack, splitPos, Quaternion.identity);
                canSpawnPlatforms = false;
                createSplitandMerge = false;
            }

            // If player pased split platform

            if (playerTrans.position.y == splitTrack.transform.position.y)
            {
                print("Player Pass");
                makeSplitTracks = true;
            }

        }
    }

    //Make split tracks
    void SpawnSplitTracks()
    {
        print("Spawn");

        Vector3 pos1 = new Vector3(playerTrans.position.x - 5, playerTrans.position.y - 10, playerPos.z);
        Vector3 pos2 = new Vector3(playerTrans.position.x + 5, playerTrans.position.y - 10, playerPos.z);
        Vector3 pos3 = new Vector3(playerTrans.position.x - 5, playerTrans.position.y - 25, playerPos.z);
        Vector3 pos4 = new Vector3(playerTrans.position.x + 5, playerTrans.position.y - 25, playerPos.z);

        SplitTracks(pos1, pos2, pos3, pos4);

    }

    void SplitTracks(Vector3 trackPos1, Vector3 trackPos2, Vector3 trackPos3, Vector3 trackPos4)
    {
        bool make = true;

        foreach (GameObject plat in splitMergeOBJs)
        {         // Destroys Platforms
            if (trackPos1.y < plat.transform.position.y - 15)
            {  // When to spawn new platforms  NOTE: Make 5f and public variable
                make = false;
            }

            plat.transform.parent = platParent;
        }


        if (make)
        {
            print("Spawn Split");

            Instantiate(easyTracksList[Mathf.RoundToInt(Random.Range(0, easyTracksList.Count))], trackPos1, Quaternion.identity);
            Instantiate(easyTracksList[Mathf.RoundToInt(Random.Range(0, easyTracksList.Count))], trackPos2, Quaternion.identity);
            Instantiate(easyTracksList[Mathf.RoundToInt(Random.Range(0, easyTracksList.Count))], trackPos3, Quaternion.identity);
            Instantiate(easyTracksList[Mathf.RoundToInt(Random.Range(0, easyTracksList.Count))], trackPos4, Quaternion.identity);
        }



    }
}