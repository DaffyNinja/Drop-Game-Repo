using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class EndlessGameMaster : MonoBehaviour
{
    public float score;
	float highScore;
    [Space(5)]
    public Text scoreText;
	[Header("Game Over")]
	public bool isGameOver;
	public Text gameOverText;
	public Text highScoreText;

	[Space(5)]
    public Transform playerTrans;
    Vector3 playerStartPos;

    void Awake()
    {
		isGameOver = false;
        score = 0;

		gameOverText.gameObject.SetActive(false);
		highScoreText.gameObject.SetActive(false);

        playerStartPos = playerTrans.position;
    }


    void FixedUpdate()
    {
        if (playerTrans.position.y < playerStartPos.y)
        {
            score += 1 * Time.deltaTime;
        }

		if(isGameOver)
		{
			gameOverText.gameObject.SetActive(true);
		}

        scoreText.text = Mathf.RoundToInt(score).ToString();
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