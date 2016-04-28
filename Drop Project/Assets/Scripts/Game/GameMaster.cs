using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameMaster : MonoBehaviour
{

    public int goldNum;

    public Text goldText;

    public Text testText;

    public bool debug;  

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!debug)
        {
            goldText.text = goldNum.ToString();


            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();

            }
        }

        //if (Input.GetKey(KeyCode.Escape))
        //{
        //    print("Back");

        //    testText.text = "Back";

        //}
        //else if (Input.GetKey(KeyCode.Menu))
        //{
        //    //print("Menu");

        //    Debug.Log("Menu");

        //    testText.text = "Menu";

        //    // Application.Quit();
        //}






    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void QuitButton()
    {
        SceneManager.LoadScene(0);
    }
}
