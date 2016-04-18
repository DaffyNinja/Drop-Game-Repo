using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {

    public float forceAng;
    public float forceMag;

    AreaEffector2D areaEffect;


	// Use this for initialization
	void Start ()
    {
        areaEffect.forceAngle = forceAng;
        areaEffect.forceMagnitude = forceMag;

	}

}
