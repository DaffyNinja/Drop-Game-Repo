using UnityEngine;
using System.Collections;

public class EndlessCamera : MonoBehaviour {

    public float speed;

   // Rigidbody rig;

    // Use this for initialization
    void Start ()
    {
       // rig = GetComponent<Rigidbody>();

	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // rig.AddForce(0, -speed, 0);

        transform.Translate(0, -speed, 0);

    }
}
