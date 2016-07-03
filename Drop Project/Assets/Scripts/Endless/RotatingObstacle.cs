using UnityEngine;
using System.Collections;

public class RotatingObstacle : MonoBehaviour
{

    public float speed;

    public bool isLeft;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isLeft)
        {
            transform.Rotate(0, 0, speed);
        }
        else
        {
            transform.Rotate(0, 0, -speed);
        }
    }
}
