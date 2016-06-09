using UnityEngine;
using System.Collections;

public class PlayerEndless : MonoBehaviour
{

    public float fallSpeed;
    public float leftRightSpeed;

    Rigidbody rig;

    // Use this for initialization
    void Start()
    {
        rig = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 moveQauntity = new Vector3(leftRightSpeed, 0, 0);
            rig.velocity = new Vector3(moveQauntity.x, rig.velocity.y, rig.velocity.z);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 moveQauntity = new Vector3(-leftRightSpeed, 0, 0);
            rig.velocity = new Vector3(moveQauntity.x, rig.velocity.y, rig.velocity.z);
        }

        Vector2 fallQauntity = new Vector2(0, -fallSpeed);
        rig.velocity = new Vector2(rig.velocity.x, fallQauntity.y);

    }
}
