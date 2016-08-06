﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndlessGameMaster : MonoBehaviour
{
    public float score;
    float highScore;
    [Space(5)]
    public Text scoreText;
    public Text highScoreText;
    string highScoreKey = "HighScore";

    public Button restartButton;

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

        //highScoreText.gameObject.SetActive(false);

        playerStartPos = playerTrans.position;

        highScore = PlayerPrefs.GetFloat(highScoreKey, 0);

        ranNum = Random.Range(0, lossText.Count);
    }


    void FixedUpdate()
    {
        // Press back button on android phone or Esc key on PC
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        if (isGameOver)  // Game Over
        {
            playerTrans.gameObject.GetComponent<PlayerEndless>().fallSpeed = 0;
            Camera.main.gameObject.GetComponent<EndlessCamera>().speed = 0;

            gameOverText.text = ("Game Over");
            gameOverText.gameObject.SetActive(true);

            griefTextBox.text = lossText[ranNum];

            griefTextBox.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);


            // StoreHighScore();

        }
        else
        {
            if (playerTrans.position.y < playerStartPos.y)
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
        highScoreText.text = Mathf.RoundToInt(highScore).ToString();

        // print(highScore.ToString());
    }

    //High Score
    void StoreHighScore()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetFloat(highScoreKey, score);


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