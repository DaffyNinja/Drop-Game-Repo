using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackCreationTEST : MonoBehaviour
{
    public List<GameObject> trackOBJs;
    [Space(5)]
    public Transform playerTrans;
    Vector3 playerPos;
    [Space(5)]
    public float yPos1;
    public float yPos2;
    public float zPos;
    [Header("PowerUps")]
    public GameObject speedBoostObj;
    public float speedBoostNum;
    bool makeSpeedBoost;

    GameObject[] tracks;

    bool canSpawnTracks;
    bool isStart;

    bool createTrack1;
    bool createTrack2;

    // Use this for initialization
    void Awake()
    {
        canSpawnTracks = true;
        isStart = true;

        playerPos = playerTrans.position;

        createTrack1 = true;

    }

    // Update is called once per frame
    void Update()
    {
        tracks = GameObject.FindGameObjectsWithTag("Track");

        TrackMaintanience();


    }

    void TrackMaintanience()
    {

        GameObject[] tracks = GameObject.FindGameObjectsWithTag("Track");
        SpawnTracks();

        foreach (GameObject t in tracks)
        {
            if (t.transform.position.y > playerTrans.position.y + 40)
            {
                Destroy(t);
            }

        }
    }

    void SpawnTracks()
    {
        Vector3 pos1 = new Vector3(playerPos.x, playerTrans.position.y - yPos1, playerPos.z - zPos);
        Vector3 pos2 = new Vector3(playerPos.x, playerTrans.position.y - yPos2, playerPos.z - zPos);
        Vector3 pos3 = new Vector3(playerPos.x, playerTrans.position.y - yPos2 * 2, playerPos.z - zPos);
        Vector3 pos4 = new Vector3(playerPos.x, playerTrans.position.y - yPos2 * 3, playerPos.z - zPos);
        Vector3 pos5 = new Vector3(playerPos.x, playerTrans.position.y - yPos2 * 4, playerPos.z - zPos);
        Vector3 pos6 = new Vector3(playerPos.x, playerTrans.position.y - yPos2 * 5, playerPos.z - zPos);

        Vector3 pos7 = new Vector3(playerPos.x, playerTrans.position.y - yPos2 * 6, playerPos.z - zPos);
        Vector3 pos8 = new Vector3(playerPos.x, playerTrans.position.y - yPos2 * 7, playerPos.z - zPos);
        Vector3 pos9 = new Vector3(playerPos.x, playerTrans.position.y - yPos2 * 8, playerPos.z - zPos);
        Vector3 pos10 = new Vector3(playerPos.x, playerTrans.position.y - yPos2 * 9, playerPos.z - zPos);

        if (isStart)
        {
            TrackCreation1(pos1, pos2, pos3, pos4, pos5, pos6);

            createTrack2 = false;
        }
        else if (isStart == false)
        {
            TrackCreation2(pos7, pos8, pos9, pos10);

        }


        // Pickups
        if (playerTrans.position.y <= playerPos.y - speedBoostNum)
        {
           // print("Speed Boost");

            Instantiate(speedBoostObj, new Vector3(playerPos.x, playerTrans.position.y - yPos2, playerPos.z), Quaternion.Euler(0,90,0));

            speedBoostNum += 40;
        }


    }

    void TrackCreation1(Vector3 trackPos1, Vector3 trackPos2, Vector3 trackPos3, Vector3 trackPos4, Vector3 trackPos5, Vector3 trackPos6)
    {
        createTrack1 = true;

        foreach (GameObject t in tracks)
        {
            if (trackPos1.y < t.transform.position.y)
            {
                createTrack1 = false;
                isStart = false;
            }

        }

        if (createTrack1 && isStart)
        {
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos1, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos2, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos3, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos4, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos5, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos6, Quaternion.Euler(0, 90, 0));

            createTrack1 = false;

        }


    }

    void TrackCreation2(Vector3 trackPos1, Vector3 trackPos2, Vector3 trackPos3, Vector3 trackPos4)
    {
        createTrack2 = true;

        foreach (GameObject t in tracks)
        {
            if (trackPos1.y > t.transform.position.y - yPos2)
            {
                createTrack2 = false;
            }

        }

        if (createTrack2)
        {
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos1, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos2, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos3, Quaternion.Euler(0, 90, 0));
            Instantiate(trackOBJs[Mathf.RoundToInt(Random.Range(0, trackOBJs.Count))], trackPos4, Quaternion.Euler(0, 90, 0));

            createTrack2 = false;

        }


    }


}
