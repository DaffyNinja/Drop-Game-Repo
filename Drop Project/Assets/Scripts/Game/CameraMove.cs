using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{

    public float speed;
    [Space(5)]
    public float camUpDis;
    public float camDownDis;
    public Transform playerTrans;
    [Space(5)]
    public float cameraOrthSize;

    Camera cam;

    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographicSize = cameraOrthSize;
       // cam.transform.position = new Vector3(playerTrans.position.x + disX, playerTrans.position.y + disY, -10);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -speed, 0);

        Vector3 viewPos = cam.WorldToViewportPoint(playerTrans.position);

        if (viewPos.y > camUpDis)
        {
            print("Up");
        }
        else if (viewPos.y < camDownDis)
        {
            print("Down");
        }




    }


}
