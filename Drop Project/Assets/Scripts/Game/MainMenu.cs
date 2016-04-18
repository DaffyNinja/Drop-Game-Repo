using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public void PlayButton()
    {
       // SceneManager.LoadScene(1);
    }

    public void Level1Button()
    {
        SceneManager.LoadScene(1);
    }

    public void Leve2Button()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitButton()
    {
        Application.Quit();
    }


}
