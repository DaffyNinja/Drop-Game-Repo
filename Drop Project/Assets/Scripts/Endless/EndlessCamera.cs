using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndlessCamera : MonoBehaviour
{

    public float speed;
    float startSpeed;
    public float boostSpeed;
    public float specialSpeed;
    [Space(5)]
    public float camUpDis;
    public float camDownDis;
    [Space(5)]
    public float downSpeedBoost;
    [Space(5)]
    public Transform playerTrans;
    public float yDis;
    [Space(5)]
    public bool isPhone;
    public float zDisPhone;
    public float zDisPc;
    [Space(5)]
    public EndlessGameMaster gMaster;
    PlayerEndless playSc;



    Camera cam;
    void Awake()
    {
        cam = GetComponent<Camera>();

        if (isPhone)
        {
            transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y + yDis, playerTrans.position.z - zDisPhone);
        }
        else
        {
            transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y + yDis, playerTrans.position.z - zDisPc);
        }

        startSpeed = speed;

        playSc = playerTrans.GetComponent<PlayerEndless>();

    }

    void FixedUpdate()
    {

        transform.Translate(0, -speed, 0);  // Moves the camera down

        // Detects when the player is over the player camera view 
        Vector3 viewPos = cam.WorldToViewportPoint(playerTrans.position);

        if (viewPos.y > camUpDis) // If player is above camera view then GAME OVER
        {
            gMaster.isGameOver = true;
        }


        //If player gets powerup
        if (playSc.obtainedSpecial == true && playSc.obtainedBoost == false)    // Special
        {
            speed = specialSpeed;
        }
        else if (playSc.obtainedBoost == true && playSc.obtainedSpecial == false)    // Boost
        {
            speed = boostSpeed;
        }
        else if (viewPos.y < camDownDis)    // Make camera boost when player reaches bottom of screen
        {
            speed = Mathf.Lerp(speed, speed + downSpeedBoost, 0.50f);
        }
        else
        {
            speed = startSpeed;
        }


    }
}
