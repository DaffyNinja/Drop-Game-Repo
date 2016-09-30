using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{

    public float cameraFallSpeed; 
  
    static public bool isMute;

    [Space(5)]
    public Image muteIm;

    public Sprite muteSpr;
    public Sprite unMuteSpr;


    void FixedUpdate()
    {
        transform.Translate(0, -cameraFallSpeed, 0);

        if (isMute == true)
        {
            muteIm.sprite = muteSpr;
        }
        else
        {
            muteIm.sprite = unMuteSpr;
        }
    }

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

    public void Level4Buttton()
    {
        SceneManager.LoadScene(4);
    }

    public void Level5Buttton()
    {
        SceneManager.LoadScene(5);
    }

    public void Level6Buttton()
    {
        SceneManager.LoadScene(6);
    }

    public void Level7Buttton()
    {
        SceneManager.LoadScene(7);
    }

    public void Level8Buttton()
    {
        SceneManager.LoadScene(8);
    }

    public void Level9Buttton()
    {
        SceneManager.LoadScene(9);
    }

    public void Level10Buttton()
    {
        SceneManager.LoadScene(10);
    }

    public void MuteButton()
    {
        print("Pressed");

        isMute = !isMute;
    }

    public void Quit()
    {
        Application.Quit();
    }


}
