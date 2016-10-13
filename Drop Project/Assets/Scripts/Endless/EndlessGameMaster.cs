﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndlessGameMaster : MonoBehaviour
{
    public float score;
    public bool storeHighScore;
    public float highScore;
    float currentHighScore;
    [Space(5)]
    public Text scoreText;
    public Text highScoreText;
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


    [Space(5)]
    public Transform playerTrans;
    Vector3 playerStartPos;

    void Awake()
    {
        isGameOver = false;
        score = 0;

        gameOverText.gameObject.SetActive(false);
        griefTextBox.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    
        playerStartPos = playerTrans.position;

        ranNum = Random.Range(0, lossText.Count);

        currentHighScore = PlayerPrefs.GetFloat("highScore");

        gameOverPanel.SetActive(false);
        tutorialPanel.SetActive(false);
        inGamePanel.SetActive(true);
    }


    void FixedUpdate()
    {
        // Press back button on android phone or Esc key on PC
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (runTut)
        {
            tutorialPanel.SetActive(true);

            tutText.text = "Press the LEFT or Right side of the screen to move";
        }
        else if (!runTut)
        {
            tutorialPanel.SetActive(false);

            tutText.text = null;
        }


        if (isGameOver)  // If its Game Over
        {
            playerTrans.gameObject.GetComponent<PlayerEndless>().fallSpeed = 0;
            Camera.main.gameObject.GetComponent<EndlessCamera>().speed = 0;

            //
            gameOverPanel.SetActive(true);
            inGamePanel.SetActive(false);

            gameOverText.text = ("Game Over");
            gameOverText.gameObject.SetActive(true);

            griefTextBox.text = lossText[ranNum];

            griefTextBox.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);

            if (storeHighScore == true)
            {
                CheckHighScore();
            }
            else
            {
                highScore = 0;
            }
        }
        else
        {
            if (playerTrans.position.y < playerStartPos.y)  // Increase Score
            {
                score += 1 * Time.deltaTime;

            }
        }

        //Audio
        if (MainMenu.isMute)  // Mute
        {
            musicSource.mute = true;
        }
        else
        {
            musicSource.mute = false;
        }

        scoreText.text = Mathf.RoundToInt(score).ToString();
        highScoreText.text = currentHighScore.ToString();

      //  print("Highscore: " + PlayerPrefs.GetFloat("highScore").ToString());


    }

    // High Score
    void CheckHighScore()
    {
        if (score > highScore)
        {
            //print("New HighScore");
            highScore = Mathf.RoundToInt(score);
            PlayerPrefs.SetFloat("highScore", highScore);
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



}