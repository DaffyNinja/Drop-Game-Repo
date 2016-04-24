using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndPoint : MonoBehaviour
{


    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {

            print("End");

           // SceneManager.LoadScene(0);


        }

    }
}
