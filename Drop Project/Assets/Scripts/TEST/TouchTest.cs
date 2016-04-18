using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchTest : MonoBehaviour
{

    public Text debugText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Start");

        if (Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            debugText.text = "Touch";
        }
        else if(Input.GetTouch(0).phase <= TouchPhase.Stationary)
        {
            debugText.text = "Null";
        }

    }
}
