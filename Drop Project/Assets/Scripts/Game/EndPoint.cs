using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndPoint : MonoBehaviour
{

    public bool is2D;
    public bool is3D;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (is2D)
            if (col.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(0);
            }

    }

    void OnTriggerEnter(Collider col)
    {
        if (is3D)
            if (col.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(0);
            }

    }
}
