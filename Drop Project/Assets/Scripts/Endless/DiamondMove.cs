using UnityEngine;
using System.Collections;

public class DiamondMove : MonoBehaviour
{

    public float speed;

    int ranNum;

    // Use this for initialization
    void Awake()
    {
       // transform.rotation = new Quaternion(90, 0, 0,0);

        ranNum = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {

        if (ranNum == 1)
        {
            transform.Rotate(0, 0, speed);
        }
        else
        {
            transform.Rotate(0, 0, speed);
        }

    }
}
