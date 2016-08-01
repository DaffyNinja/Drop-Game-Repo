using UnityEngine;
using System.Collections;

public class PistonsMove : MonoBehaviour
{

    public float speed;

    public float xPos;

    Vector3 startingPos;
    Vector3 Movepos;

    // Use this for initialization
    void Start()
    {

        startingPos = transform.position;

        Movepos = new Vector3(transform.position.x + xPos, transform.position.y, transform.position.z);


    }

    // Update is called once per frame
    void Update()
    {


        transform.position = Vector3.Lerp(startingPos, Movepos, speed * Time.time);



    }
}
