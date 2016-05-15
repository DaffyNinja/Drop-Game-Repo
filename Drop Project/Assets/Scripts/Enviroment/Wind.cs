using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour
{

    public float windForce;
    [Space(5)]
    public bool onX;
    public bool onY;
    public bool onZ;


    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
           // print("Wind");

            if (onX)
            {
                col.gameObject.GetComponentInParent<Rigidbody>().AddForce(windForce, 0, 0);
            }

            if (onY)
            {
                col.gameObject.GetComponentInParent<Rigidbody>().AddForce(0, windForce, 0);
            }

            if (onZ)
            {
                col.gameObject.GetComponentInParent<Rigidbody>().AddForce(0, 0, windForce);
            }
        }
             

    }
}
