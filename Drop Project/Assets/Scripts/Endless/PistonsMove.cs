using UnityEngine;
using System.Collections;

public class PistonsMove : MonoBehaviour
{

    public float fowardSpeed;
    public float backSpeed;

    public float xPos;

    // public bool isStart;
    public bool isMoving;


    Vector3 startingPos;
    Vector3 Movepos;

    float moveTimer;

    // Use this for initialization
    void Awake()
    {
        

        startingPos = transform.position;

        Movepos = new Vector3(transform.position.x + xPos, transform.position.y, transform.position.z);


    }

    // Update is called once per frame
    void Update()
    {
        moveTimer = Mathf.Clamp(moveTimer, 0, 1);


        if (isMoving)  // Back
        {
            moveTimer += backSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(startingPos, Movepos, moveTimer);

            if (moveTimer >= 1)
            {
                isMoving = false;
            }

        }
        else    // Foward
        {
            moveTimer -= fowardSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(startingPos, Movepos, moveTimer);

            if (moveTimer <= 0)
            {
                isMoving = true;
            }


        }

        // transform.position = Vector3.Lerp(startingPos, Movepos, speed * Time.time);





    }
}
