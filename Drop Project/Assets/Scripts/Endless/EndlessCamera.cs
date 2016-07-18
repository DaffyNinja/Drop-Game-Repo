using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndlessCamera : MonoBehaviour
{

    public float speed;
    [Space(5)]
    public float camUpDis;
    public float camDownDis;
    public Transform playerTrans;
//    [Header("Debug")]
//    public bool isDebug;
//    public Text gameOverText;
	[Space(5)]
	public EndlessGameMaster gMaster;

    Camera cam;


    // Use this for initialization
    void Awake()
    {
        cam = GetComponent<Camera>();

        //gMaster.gameOverText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(0, -speed, 0);  // Moves the camera down

        // Detects when the player is over the player camera view 
        Vector3 viewPos = cam.WorldToViewportPoint(playerTrans.position);

        if (viewPos.y > camUpDis) // If player is above camera view then GAME OVER
        {
           // print("Up");

			gMaster.isGameOver = true;

        }
        //else if (viewPos.y < camDownDis)
        //{
        //    print("Down");
        //}


    }
}
