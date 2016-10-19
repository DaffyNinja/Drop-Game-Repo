using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{

    public float cameraFallSpeed;

    static public bool isMute;


    [Space(5)]
    public Image touchButtonImg;
    public Image acelButtonImg;

    public Sprite CheckSpr;
    public Sprite offSprite;



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

        if (Input.GetKey(KeyCode.Escape)) // If the player presses the back button on an Android deveice they quit game
        {
            Application.Quit();
        }

        if (PlayerEndless.isTouch == true)
        {
            touchButtonImg.sprite = CheckSpr;
        }
        else
        {
            touchButtonImg.sprite = offSprite;
        }

        if (PlayerEndless.isAccelerate == true)
        {
            acelButtonImg.sprite = CheckSpr;
        }
        else
        {
            acelButtonImg.sprite = offSprite;
        }
        
        
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

       

        PlayerEndless.isTouch = !PlayerEndless.isTouch;
    }

    public void AccelButton()
    {
        PlayerEndless.isAccelerate = !PlayerEndless.isAccelerate;


    }

    public void Quit()
    {
        Application.Quit();
    }


}
