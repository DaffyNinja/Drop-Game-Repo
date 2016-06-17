using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EndlessGameMaster : MonoBehaviour
{
    public float score;
    [Space(10)]
    public Text scoreText;

    public Transform playerTrans;
    Vector3 playerStartPos;

    void Awake()
    {
        score = 0;

        playerStartPos = playerTrans.position;
    }


    void FixedUpdate()
    {
        if (playerTrans.position.y < playerStartPos.y)
        {
            score += 1 * Time.deltaTime;

          
        }

        scoreText.text = Mathf.RoundToInt(score).ToString();
    }

}