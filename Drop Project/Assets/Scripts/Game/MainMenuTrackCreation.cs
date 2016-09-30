using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenuTrackCreation : MonoBehaviour
{

    public List<GameObject> tracksObjs;
    [Space(5)]
    public float zDis;
    public float destroyNum;
    public Transform trackParent;

    float xPos;
    float yPos;
    float zPos;
    GameObject[] tracksArray;

    bool create1;
    bool create2;
    bool isStart;

    [Space(5)]
    public Transform cameraTrans;
    Vector3 cameraStartPos;


    // Use this for initialization
    void Awake()
    {
        cameraStartPos = cameraTrans.position;

        xPos = cameraTrans.position.x;
        yPos = cameraTrans.position.y;
       

        isStart = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tracksArray = GameObject.FindGameObjectsWithTag("Track");

        TrackMain();

    }

    void TrackMain()
    {
        GameObject[] tracks = GameObject.FindGameObjectsWithTag("Track");
        TrackPositions();

        foreach (GameObject t in tracks)
        {
            if (t.transform.position.y > cameraTrans.position.y + destroyNum)
            {
                Destroy(t);

            }
        }

    }

    void TrackPositions()
    {
        // Positions
        Vector3 pos = new Vector3(cameraStartPos.x, cameraTrans.position.y, cameraStartPos.z + zDis);
        Vector3 pos2 = new Vector3(cameraStartPos.x, cameraTrans.position.y - 16.5f, cameraStartPos.z + zDis);
        Vector3 pos3 = new Vector3(cameraStartPos.x, cameraTrans.position.y - 16.5f * 2, cameraStartPos.z + zDis);
        Vector3 pos4 = new Vector3(cameraStartPos.x, cameraTrans.position.y - 16.5f * 3, cameraStartPos.z + zDis);
        Vector3 pos5 = new Vector3(cameraStartPos.x, cameraTrans.position.y - 16.5f * 4, cameraStartPos.z + zDis);
        Vector3 pos6 = new Vector3(cameraStartPos.x, cameraTrans.position.y - 16.5f * 5, cameraStartPos.z + zDis);
        Vector3 pos7 = new Vector3(cameraStartPos.x, cameraTrans.position.y - 16.5f * 6, cameraStartPos.z + zDis);

        Vector3 pos8 = new Vector3(cameraStartPos.x, cameraTrans.position.y - 16.5f * 7, cameraStartPos.z + zDis);
        Vector3 pos9 = new Vector3(cameraStartPos.x, cameraTrans.position.y - 16.5f * 8, cameraStartPos.z + zDis);
        Vector3 pos10 = new Vector3(cameraStartPos.x, cameraTrans.position.y - 16.5f * 9, cameraStartPos.z + zDis);


        if (isStart)
        {
            TrackCreation1(pos, pos2, pos3, pos4, pos5, pos6);

            create2 = false;
        }
        else if (isStart == false)
        {
            TrackCreation2(pos7, pos8, pos9, pos10);
        }
    }

    void TrackCreation1(Vector3 trackPos1, Vector3 trackPos2, Vector3 trackPos3, Vector3 trackPos4, Vector3 trackPos5, Vector3 trackPos6)
    {
        create1 = true;

        foreach (GameObject t in tracksArray)
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
            Instantiate(tracksObjs[Mathf.RoundToInt(Random.Range(0, tracksObjs.Count))], trackPos1, Quaternion.Euler(0, 90, 0));
            Instantiate(tracksObjs[Mathf.RoundToInt(Random.Range(0, tracksObjs.Count))], trackPos2, Quaternion.Euler(0, 90, 0));
            Instantiate(tracksObjs[Mathf.RoundToInt(Random.Range(0, tracksObjs.Count))], trackPos3, Quaternion.Euler(0, 90, 0));
            Instantiate(tracksObjs[Mathf.RoundToInt(Random.Range(0, tracksObjs.Count))], trackPos4, Quaternion.Euler(0, 90, 0));
            Instantiate(tracksObjs[Mathf.RoundToInt(Random.Range(0, tracksObjs.Count))], trackPos5, Quaternion.Euler(0, 90, 0));
            Instantiate(tracksObjs[Mathf.RoundToInt(Random.Range(0, tracksObjs.Count))], trackPos6, Quaternion.Euler(0, 90, 0));

            create1 = false;
        }

    }

    void TrackCreation2(Vector3 trackPos1, Vector3 trackPos2, Vector3 trackPos3, Vector3 trackPos4)
    {
        create2 = true;

        foreach (GameObject t in tracksArray)
        {
            if (trackPos1.y > t.transform.position.y - 16.5f && isStart == false)
            {
                create2 = false;
            }

            t.transform.parent = trackParent;
        }

        if (create2 && isStart == false)
        {
            Instantiate(tracksObjs[Mathf.RoundToInt(Random.Range(0, tracksObjs.Count))], trackPos1, Quaternion.Euler(0, 90, 0));
            Instantiate(tracksObjs[Mathf.RoundToInt(Random.Range(0, tracksObjs.Count))], trackPos2, Quaternion.Euler(0, 90, 0));
            Instantiate(tracksObjs[Mathf.RoundToInt(Random.Range(0, tracksObjs.Count))], trackPos3, Quaternion.Euler(0, 90, 0));
            Instantiate(tracksObjs[Mathf.RoundToInt(Random.Range(0, tracksObjs.Count))], trackPos4, Quaternion.Euler(0, 90, 0));

            create2 = false;
        }

    }


}
