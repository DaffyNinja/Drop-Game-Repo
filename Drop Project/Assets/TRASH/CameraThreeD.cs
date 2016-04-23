using UnityEngine;
using System.Collections;

public class CameraThreeD : MonoBehaviour {

    public float speed;
    public float camUpDis;
    public float camDownDis;
    [Space(5)]
    public Transform playerTrans;

    PlayerDroplet playerDrop;

    Rigidbody rig;


    Camera cam;

    // Use this for initialization
    void Start ()
    {
        //transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y, -6.34f);

        cam = GetComponent<Camera>();
        rig = GetComponent<Rigidbody>();

        transform.position = new Vector3(transform.position.x, playerTrans.position.y + 4, transform.position.z);

        playerDrop = playerTrans.GetComponent<PlayerDroplet>();

    }
	
	// Update is called once per frame
	void Update ()
    {

        // transform.Translate(0, -speed, 0);

        rig.AddForce(0, -speed, 0);

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
