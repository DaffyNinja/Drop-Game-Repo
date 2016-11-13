using UnityEngine;
using System.Collections;

public class RotatingObstacle : MonoBehaviour
{

    public float speed;
    
    public bool isLeft;
    public bool isRandom;

    int ranNum;

    // Use this for initialization
    void Awake()
    {
        ranNum = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeft && !isRandom)   // Left
        {
            transform.Rotate(-speed, 0, 0);
        }
        else if (!isLeft && !isRandom)  // Right 
        {
            transform.Rotate(speed, 0, 0);
        }
        else if (isRandom && !isLeft) //Random
        {
            if (ranNum == 1)
            {
                transform.Rotate(speed, 0, 0);
            }
            else
            {
                transform.Rotate(-speed, 0, 0);
            }
        }

    }
}
