using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public float freeFallSpeed;
    public float windowSpeed;
    [Space(5)]
    public bool transMove;
    public float transSpeed;
    //   public float smoothness;
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
    // Vector3 playerPos;

    Vector3 startingPos;

    bool canChange;


    PlayerDroplet playerDrop;

    Rigidbody rig;

    Camera cam;

    // Use this for initialization
    void Start()
    {

        canChange = true;

        cam = GetComponent<Camera>();
        rig = GetComponent<Rigidbody>();

        cam.fieldOfView = cameraFOVSize;

        //  playerPos = playerTrans.position;
        playerDrop = playerTrans.gameObject.GetComponent<PlayerDroplet>();

        //  transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y + disY, playerTrans.position.z + disZ);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        startingPos = transform.position;

        Vector3 viewPos = cam.WorldToViewportPoint(playerTrans.position);

        if (viewPos.y > camUpDis)
        {
            // print("Up");
        }
        else if (viewPos.y < camDownDis)
        {
            // print("Down");
        }

        if (canChange)
        {
            if (playerDrop.isFreefall == false)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);

                //  transform.position = new Vector3(windowCamPos.position.x, windowCamPos.position.y + 2, windowCamPos.position.z - 12.5f);

                transform.position = new Vector3(windowCamPos.position.x, windowCamPos.position.y + 2, windowCamPos.position.z - 12.5f);

                canChange = false;
            }
            else
            {
                rig.AddForce(0, -freeFallSpeed, 0);
            }

        }
        else
        {
            //  print("Window");
            rig.AddForce(0, -windowSpeed, 0);

        }

    }


}
