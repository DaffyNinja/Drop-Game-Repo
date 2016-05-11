using UnityEngine;
using System.Collections;

public class WindowDebug : MonoBehaviour
{

    public bool playWindow;
    public Transform windowPos;
    public PlayerDroplet playDrop;

    // Use this for initialization
    void Start()
    {
        if (playWindow)
        {
            playDrop.transform.position = windowPos.position;

            playDrop.isFreefall = false;

            playDrop.isWindow = true;
        }
    }

}
