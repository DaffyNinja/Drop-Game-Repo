using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public bool rigMove;
    public float rigSpeed;
    [Space(5)]
    public bool transMove;
    public float transSpeed; 
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
    Vector3 playerPos;


    PlayerDroplet playerDrop;

    Rigidbody rig;

    Camera cam;

    // Use this for initialization
    void Start()
    {

        cam = GetComponent<Camera>();
        rig = GetComponent<Rigidbody>();

        cam.fieldOfView = cameraFOVSize;

        playerPos = playerTrans.position;
        playerDrop = playerTrans.gameObject.GetComponent<PlayerDroplet>();

        transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y + disY, playerTrans.position.z + disZ);

    }

    // Update is called once per frame
    void Update()
    {


        if (rigMove)
        {
            rig.AddForce(0, -rigSpeed, 0);
        }
        else if (transMove)
        {
            // transform.Translate(0, -transSpeed * Time.deltaTime, 0);

           this.transform.Translate(Vector3.up * -transSpeed * Time.deltaTime,0);
        }                                  

        Vector3 viewPos = cam.WorldToViewportPoint(playerTrans.position);

        if (viewPos.y > camUpDis)
        {
            print("Up");
        }
        else if (viewPos.y < camDownDis)
        {
            print("Down");
        }

        if (playerDrop.isLarge == true)
        {
            transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y + 5, playerTrans.position.z - 7);
        }

    }


}
