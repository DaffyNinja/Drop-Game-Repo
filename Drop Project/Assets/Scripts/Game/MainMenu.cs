using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject CreditsPanel;
    [Space(5)]
    public float cameraFallSpeed;

    static public bool isMute;

    [Space(5)]
    public Image touchButtonImg;
    public Image acelButtonImg;

    //public Sprite CheckSpr;
    //public Sprite offSprite;

    [Space(5)]
    public Image muteIm;

    public Sprite muteSpr;
    public Sprite unMuteSpr;

    [Space(5)]
    public AudioSource mainMenuASrc;

    void Awake()
    {
        settingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);

        PlayerEndless.isTouch = true;

    }

    void FixedUpdate()
    {
        transform.Translate(0, -cameraFallSpeed, 0);

        if (isMute == true)
        {
            muteIm.sprite = muteSpr;
            mainMenuASrc.mute = true;
        }
        else
        {
            muteIm.sprite = unMuteSpr;
            mainMenuASrc.mute = false;
        }

        if (Input.GetKey(KeyCode.Escape)) // If the player presses the back button on an Android deveice they quit game
        {
            Application.Quit();
        }

        if (PlayerEndless.isTouch == true && PlayerEndless.isAccelerate == false)
        {
            touchButtonImg.color = Color.green;

            acelButtonImg.color = Color.white;
        }
        else if (PlayerEndless.isAccelerate == true && PlayerEndless.isTouch == false)
        {
            acelButtonImg.color = Color.green;

            touchButtonImg.color = Color.white;
        }
        else
        {
            acelButtonImg.color = Color.white;

            touchButtonImg.color = Color.white;
        }


    }

    public void MainMenuButton()
    {
        mainMenuPanel.SetActive(true);

        settingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }

    public void SettingsButton()
    {
        settingsPanel.SetActive(true);

        mainMenuPanel.SetActive(false);
        CreditsPanel.SetActive(false);

    }

    public void CreditsButton()
    {
        CreditsPanel.SetActive(true);

        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(false);

    }

    public void Level1Button()
    {
        SceneManager.LoadScene(1);
    }

    public void MuteButton()  // Turn mute bool on or off
    {
        isMute = !isMute;
    }

    public void TouchButton()
    {
        PlayerEndless.isAccelerate = false;
        PlayerEndless.isTouch = true;
        
    }

    public void AccelButton()
    {
        PlayerEndless.isTouch = false;
        PlayerEndless.isAccelerate = true;
        

    }

    public void Quit()
    {
        Application.Quit();
    }


}
