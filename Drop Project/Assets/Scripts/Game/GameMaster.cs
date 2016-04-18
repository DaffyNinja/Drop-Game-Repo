using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameMaster : MonoBehaviour
{

    public int goldNum;

    public Text goldText;

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
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

        }


    }

    public void QuitButton()
    {
        SceneManager.LoadScene(0);
    }
}
