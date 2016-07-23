using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestAll : MonoBehaviour
{

    public Button testButton;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {

            print("Back");

            testButton.gameObject.SetActive(false);
        }
        else
        {
            testButton.gameObject.SetActive(true);
        }

        //if (Input.anyKey)
        //{
        //    print("Pressed");

        //}


    }
}
