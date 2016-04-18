using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerDropletAndroid : MonoBehaviour
{

    public float fallSpeed;
    public float leftRightspeed;
    public float quickSpeed;
    public float slowSpeed;

    public bool moveLeft;
    public bool moveRight;

    //[Space(5)]
    //public Button leftButton;
    //public Button rightButton;

    [Header("Touch")]
    public float screenPosX;

    Vector2 touchPos;

    [Space(5)]
    public GameMaster gMaster;



    // public float sprintSpeed;

    float startSpeed;

    private Rigidbody2D rig2D;

    // Use this for initialization
    void Start()
    {

        rig2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            Vector2 moveQauntity = new Vector2(leftRightspeed, 0);
            rig2D.velocity = new Vector2(moveQauntity.x, rig2D.velocity.y);
            // moveRight = false;
        }
        else if (moveLeft)
        {

            Vector2 moveQauntity = new Vector2(-leftRightspeed, 0);
            rig2D.velocity = new Vector2(moveQauntity.x, rig2D.velocity.y);
            //moveLeft = false;

        }

        Vector2 fallQauntity = new Vector2(0, -fallSpeed);
        rig2D.velocity = new Vector2(rig2D.velocity.x, fallQauntity.y);


        //Touch Controls
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            touchPos = Input.GetTouch(0).position;
        }
        else
        {
            touchPos = new Vector2(0, 0);

            moveRight = false;
            moveLeft = false;
        }

        if (touchPos.x > screenPosX)
        {
            print("Right");

            moveRight = true;
            moveLeft = false;

        }
        else if (touchPos.x < screenPosX && touchPos.x > 0)
        {
            print("Left");

            moveLeft = true;
            moveRight = false;
        }

        // End

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Gold")
        {
            gMaster.goldNum += 1;

            Destroy(col.gameObject);

        }

    }




}
