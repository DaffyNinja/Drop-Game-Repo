using UnityEngine;
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
    [Header("Game Over")]
	public bool isGameOver;
	public Text gameOverText;


	[Space(5)]
    public Transform playerTrans;
    Vector3 playerStartPos;

    void Awake()
    {
		isGameOver = false;
        score = 0;

		gameOverText.gameObject.SetActive(false);
		//highScoreText.gameObject.SetActive(false);

        playerStartPos = playerTrans.position;

        highScore = PlayerPrefs.GetFloat(highScoreKey, 0);
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

           // StoreHighScore();

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