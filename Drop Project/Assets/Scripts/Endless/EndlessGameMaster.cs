﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndlessGameMaster : MonoBehaviour
{
    public float score;
    [Space(5)]                
    public bool storeHighScore;
    public float highScore;
    float currentHighScore;
    [Space(5)]
    public Text scoreText;
    public Text highScoreUI;


    public Text goScoreText;
    public Text gohighScoreUI;
    public Text newHighscoreText;

    public Button restartButton;
    [Space(5)]
    public GameObject inGamePanel;
    public GameObject gameOverPanel;
    public GameObject tutorialPanel;

    string highScoreKey = "HighScore";

    [Header("Loss Text")]
    [TextArea(1, 20)]
    public List<string> lossText;
    int ranNum;

    [Space(5)]
    public Text griefTextBox;
    public bool hasText;

    [Header("Game Over")]
    public bool isGameOver;
    public Text gameOverText;
    [Header("Audio")]
    public AudioSource musicSource;
    // public bool playMusic;

    [Header("Tutorial")]
    public bool runTut;
    public Text tutText;

    public Button leftButton;
    bool leftPressed;
    int leftPressNum;
    public Button rightButton;
    bool rightPressed;
    int rightPressNum;

    bool pressedScreen;

    [Space(5)]
    public Transform playerTrans;
    Vector3 playerStartPos;

    TrackCreationTwo track2;

    void Awake()
    {
        track2 = GetComponent<TrackCreationTwo>();


        isGameOver = false;
        score = 0;

        gameOverText.gameObject.SetActive(false);
        griefTextBox.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        newHighscoreText.gameObject.SetActive(false);

        playerStartPos = playerTrans.position;

        ranNum = Random.Range(0, lossText.Count);

        currentHighScore = PlayerPrefs.GetFloat("highScore");

        gameOverPanel.SetActive(false);
        tutorialPanel.SetActive(false);
        inGamePanel.SetActive(true);
    }


    void FixedUpdate()
    {
        //highScoreUI = highScore;

        // Press back button on android phone or Esc key on PC
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // Tutorial
        if (runTut)
        {
            tutorialPanel.SetActive(true);

            tutText.text = "Press the LEFT or Right side of the screen to move";

            if (leftPressNum >= 3 && rightPressNum >= 3)  // Wehn to stop tut
            {
                runTut = false;
            }

        }
        else if (!runTut)
        {
            if (track2.isMedium == false)
            {
                track2.isEasy = true;
            }

            tutorialPanel.SetActive(false);

            tutText.text = null;
        }


        if (isGameOver)  // If its Game Over
        {
            playerTrans.gameObject.GetComponent<PlayerEndless>().fallSpeed = 0;
            playerTrans.gameObject.GetComponent<PlayerEndless>().leftRightSpeed = 0;
            playerTrans.gameObject.GetComponent<PlayerEndless>().turnFallSpeed = 0;


            Camera.main.gameObject.GetComponent<EndlessCamera>().speed = 0;

            gameOverPanel.SetActive(true);
            inGamePanel.SetActive(false);

            gameOverText.text = "Game Over";
            gameOverText.gameObject.SetActive(true);

            griefTextBox.text = lossText[ranNum];

            griefTextBox.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);

            goScoreText.text = Mathf.RoundToInt(score).ToString();
            gohighScoreUI.text = highScore.ToString();


            // HighScore
            if (storeHighScore == true)
            {
                CheckHighScore();
            }
            else
            {
                highScore = 0;
            }
        }
        else     // Score
        {
            if (playerTrans.position.y < playerStartPos.y && playerTrans.GetComponent<PlayerEndless>().obtainedBoost == false && playerTrans.GetComponent<PlayerEndless>().obtainedSpecial == false)  // Increase Score
            {
                score += 1 * Time.deltaTime;

            }
            else if (playerTrans.GetComponent<PlayerEndless>().obtainedSpecial == true && playerTrans.GetComponent<PlayerEndless>().obtainedBoost == false)  // Special Score increase
            {
                score += 1 * Time.deltaTime * 3;
            }
            else if (playerTrans.GetComponent<PlayerEndless>().obtainedBoost == true && playerTrans.GetComponent<PlayerEndless>().obtainedSpecial == false)  // Boost Score increase
            {
                score += 1 * Time.deltaTime * 6;
            }

        }

        //Audio
        if (MainMenu. isMute)  // Mute
        {
            musicSource.mute = true;
        }
        else
        {
            musicSource.mute = false;
        }

        scoreText.text = Mathf.RoundToInt(score).ToString();
        highScoreUI.text = currentHighScore.ToString();

    }

    // High Score
    void CheckHighScore()
    {
        if (score > highScore)   // New Highscore
        {
            newHighscoreText.gameObject.SetActive(true);
            highScore = Mathf.RoundToInt(score);
            PlayerPrefs.SetFloat("highScore", highScore);
        }
        else
        {
            newHighscoreText.gameObject.SetActive(false);
        }
    }

    //Buttons
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LeftTutButton()
    {
        leftPressNum += 1;
    }

    public void RightTutButton()
    {
        rightPressNum += 1;
    }






}