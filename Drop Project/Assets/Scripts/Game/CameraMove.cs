using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public float disX, disY, disZ;
    [Space(5)]
    public Transform playerTrans;
    Vector3 playerPos;
    [Space(5)]
    public float cameraPerSize;

    Camera cam;

    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
        //cam.orthographicSize = cameraOrthSize;

        playerPos = playerTrans.position;

       // cam.transform.position = new Vector3(playerTrans.position.x + disX, playerTrans.position.y + disY, -10);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, playerTrans.position.y + disY, playerTrans.position.z + disZ);

    }


}
