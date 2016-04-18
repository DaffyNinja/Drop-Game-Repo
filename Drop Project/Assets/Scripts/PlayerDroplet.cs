using UnityEngine;
using System.Collections;

public class PlayerDroplet : MonoBehaviour
{

    public float fallSpeed;
    public float leftRightspeed;
    public float quickSpeed;
    public float slowSpeed;

    [Header("Split")]
    public float splitPosX; 
    public bool canSplit;

    GameObject splitDropObj;




    // public float sprintSpeed;

    float startSpeed;

    private Rigidbody2D rig2D;

    [Space(5)]
    public GameMaster gMaster;



    // Use this for initialization
    void Start()
    {

        rig2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Controls();


        if (canSplit)
        {
            splitDropObj = this.gameObject;

            transform.position = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);

            Vector3 splitObjPos = new Vector3(transform.position.x + splitPosX, transform.position.y, transform.position.z);

            GameObject clone = Instantiate(splitDropObj, splitObjPos, Quaternion.identity) as GameObject;

            clone.GetComponent<PlayerDroplet>().canSplit = false;

            canSplit = false;
        }

        print(canSplit.ToString());

    }

    void Controls()
    {


        // PC || Left Right                                                       
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 moveQauntity = new Vector2(leftRightspeed, 0);
            rig2D.velocity = new Vector2(moveQauntity.x, rig2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {

            Vector2 moveQauntity = new Vector2(-leftRightspeed, 0);
            rig2D.velocity = new Vector2(moveQauntity.x, rig2D.velocity.y);
        }

        // Down Up and Fall
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 moveQauntity = new Vector2(0, -slowSpeed);
            rig2D.velocity = new Vector2(rig2D.velocity.x, moveQauntity.y);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {

            Vector2 moveQauntity = new Vector2(0, -quickSpeed);
            rig2D.velocity = new Vector2(rig2D.velocity.x, moveQauntity.y);
        }
        else
        {
            Vector2 fallQauntity = new Vector2(0, -fallSpeed);
            rig2D.velocity = new Vector2(rig2D.velocity.x, fallQauntity.y);
        }


        /* // Xbox Controller
        if (Input.GetAxis("Horizontal") >= 1)
        {
            // print("Right");

            Vector2 moveQauntity = new Vector2(leftRightspeed, 0);
            rig2D.velocity = new Vector2(moveQauntity.x, rig2D.velocity.y);



        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            // print("Left");


            Vector2 moveQauntity = new Vector2(-leftRightspeed, 0);
            rig2D.velocity = new Vector2(moveQauntity.x, rig2D.velocity.y);


        } */

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Gold")
        {
            gMaster.goldNum += 1;

            Destroy(col.gameObject);

         

        }


    }

    void OnTriggerExit2D(Collider2D col)
    {


        if (col.gameObject.tag == "Split")
        {
            canSplit = true;
        }
        //else
        //{
        //    canSplit = false;
        //}
    }
}