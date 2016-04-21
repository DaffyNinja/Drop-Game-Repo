using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public void Level1Button()
    {
        SceneManager.LoadScene(1);
    }

    public void Level2Button()
    {
        SceneManager.LoadScene(2);
    }

    public void Level3Buttton()
    {
        SceneManager.LoadScene(3);
    }

}
