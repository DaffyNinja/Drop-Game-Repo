using UnityEngine;
using System.Collections;

public class PistonsMove : MonoBehaviour
{

    public float speed;

    public float xPos;

    public bool isStart;
    public bool moveBack;


    Vector3 startingPos;
    Vector3 Movepos;

    // Use this for initialization
    void Awake()
    {
        isStart = true;

        startingPos = transform.position;

        Movepos = new Vector3(transform.position.x + xPos, transform.position.y, transform.position.z);


    }

    // Update is called once per frame
    void Update()
    {

        if (isStart)
        {
            transform.position = Vector3.Lerp(startingPos, Movepos, speed * Time.time);

            //if (transform.position.x == startingPos.x)
            //{
            //    moveBack = false;
            //}
            //else if (transform.position.x >= Movepos.x)
            //{
            //    moveBack = true;
            //}

            //if (moveBack)
            //{
            //    print("Back");
            //    transform.position = Vector3.Lerp(Movepos, startingPos, speed * Time.time);
            //}
            //else
            //{
            //    print("Forward");
            //    transform.position = Vector3.Lerp(startingPos, Movepos, speed * Time.time);
            //}
        }


    }
}
