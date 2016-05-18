using UnityEngine;
using System.Collections;

public class WindowDebug : MonoBehaviour
{

    public bool playWindow;

    public Transform windowPos;
    public PlayerDroplet playDrop;
    public CameraMove camMove;

    public bool isPuddle;
    public Transform playerPuddlePos;

    // Use this for initialization
    void Start()
    {
        if (playWindow)
        {
            playDrop.transform.position = new Vector3(windowPos.position.x,windowPos.position.y,windowPos.position.z);

            playDrop.isFreefall = false;

            playDrop.isWindow = true;
        }
        else if (isPuddle == true)
        {
            playDrop.isFreefall = false;

            playDrop.isWindow = true;

            playDrop.transform.position = playerPuddlePos.position;

            camMove.transform.position = new Vector3(playDrop.transform.position.x, playDrop.transform.position.y + 2, playDrop.transform.position.z - 25f);

        }
    }

}
