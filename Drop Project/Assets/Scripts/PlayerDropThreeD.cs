using UnityEngine;
using System.Collections;

public class PlayerDropThreeD : MonoBehaviour
{



    public float fallSpeed;
    public float leftRightspeed;

    Rigidbody rig;


    // Use this for initialization
    void Start()
    {
        rig = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 moveQauntity = new Vector2(leftRightspeed, 0);
            rig.velocity = new Vector2(moveQauntity.x, rig.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {

            Vector2 moveQauntity = new Vector2(-leftRightspeed, 0);
            rig.velocity = new Vector2(moveQauntity.x, rig.velocity.y);
        }

        Vector2 fallQauntity = new Vector2(0, -fallSpeed);
        rig.velocity = new Vector2(rig.velocity.x, fallQauntity.y);


    }
}
