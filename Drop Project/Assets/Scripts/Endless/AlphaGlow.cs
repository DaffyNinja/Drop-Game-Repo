using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaGlow : MonoBehaviour
{

    public float minVal;
    public float maxVal;
    [Space(5)]
    public float glowAmmount;
    public float glowTime;
    float timer;

    bool increaseGlow;
    bool decreaseGlow;

    Image curImg;
    Color imgCol;

    // Use this for initialization
    void Start()
    {
        curImg = GetComponent<Image>();

        imgCol = curImg.color;
        imgCol.a = 0;
        curImg.color = imgCol;

    }

    // Update is called once per frame
    void Update()
    {

        if (increaseGlow == true)
        {
            timer += Time.deltaTime;

            imgCol = curImg.color;
            imgCol.a += glowAmmount;
            curImg.color = imgCol;

            if (timer >= glowTime)
            {
                increaseGlow = false;
            }
        }
        else
        {
            timer -= Time.deltaTime;

            imgCol = curImg.color;
            imgCol.a -= glowAmmount;
            curImg.color = imgCol;

            if (timer <= 0)
            {
                increaseGlow = true;
            }
        }

    }
}
