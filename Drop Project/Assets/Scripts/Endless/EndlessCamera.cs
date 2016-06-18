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
    [Header("Debug")]
    public bool isDebug;
    public Text gameOverText;

    Camera cam;


    // Use this for initialization
    void Awake()
    {
        cam = GetComponent<Camera>();

        gameOverText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(0, -speed, 0);  // Moves the camera down

        // Detects when the player is over the player camera view 
        Vector3 viewPos = cam.WorldToViewportPoint(playerTrans.position);

        if (viewPos.y > camUpDis)
        {
            print("Up");

            if (isDebug)
            {
                gameOverText.gameObject.SetActive(true);
            }

        }
        //else if (viewPos.y < camDownDis)
        //{
        //    print("Down");
        //}


    }
}
