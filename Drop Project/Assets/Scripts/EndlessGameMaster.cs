using UnityEngine;
using System.Collections;

public class EndlessGameMaster : MonoBehaviour
{

    public Transform[] platformsPre;
    [Space(10)]
    public float platformsSpawnedUpTo = 0.0f;

    public Transform playerTrans;
    public Transform platParent;

    public float nextPlatformCheckY = 0.0f;
    public float newXNum;

    // Use this for initialization
    void Start()
    {

        Cursor.visible = false;


    }

    // Update is called once per frame
    void Update()
    {

        PlatformMaintenaince();

        //SpawnPlats (1);
    }

    void PlatformMaintenaince()
    {

        //nextPlatformCheckY = playerTrans.position.y + 10;
        nextPlatformCheckY = playerTrans.position.y + 20;  //25

        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Shape");

        //bool create = true;

        foreach (GameObject platform in platforms)
        {
            if (platform.transform.position.y < (playerTrans.position.y - 35))  // When to destroy platform
            {
                Destroy(platform);
            }
        }

        SpawnPlats(nextPlatformCheckY);

    }

    void SpawnPlats(float upTo)
    {
        float spawnHeight = platformsSpawnedUpTo;
        while (spawnHeight <= upTo)
        {
            //float x = Random.Range(-10.0f,10.0f);

            float XPos;
            float XNeg;

            Vector2 posPlus;
            Vector2 posNeg;

            int platformIndex;

            if (playerTrans.position.y < 250)
            {
                newXNum = 2500;
            }
            else if (playerTrans.position.y > 250)
            {
                newXNum = 2250;
            }

            if (playerTrans.position.y > 350)
            {
                newXNum = 2000;
            }

            if (playerTrans.position.y > 450)
            {
                newXNum = 1750;
            }

            if (playerTrans.position.y > 550)
            {
                newXNum = 1500;
            }

            if (playerTrans.position.y > 650)
            {
                newXNum = 1250;
            }

            if (playerTrans.position.y > 750)
            {
                newXNum = 1000;
            }

            if (playerTrans.position.y > 850)
            {
                newXNum = 750;
            }


            XPos = Random.Range(playerTrans.transform.position.x - newXNum, playerTrans.transform.position.x + newXNum);
            XNeg = Random.Range(-playerTrans.transform.position.x - newXNum, -playerTrans.transform.position.x + newXNum);


            posPlus = new Vector2(XPos, playerTrans.transform.position.y + 50f);
            posNeg = new Vector2(XNeg, playerTrans.transform.position.y + 50f);

            platformIndex = Mathf.RoundToInt(Random.Range(0, platformsPre.Length));

            CreatePlatform(posPlus, platformIndex);
            CreatePlatform(posNeg, platformIndex);


            if (platformIndex == platformsPre.Length - 1)
            {
                //x = Random.Range(-10.0f,10.0f);

                if (playerTrans.position.y < 250)
                {
                    newXNum = 2500;
                }
                else if (playerTrans.position.y > 250)
                {
                    newXNum = 2250;
                }

                if (playerTrans.position.y > 350)
                {
                    newXNum = 2000;
                }

                if (playerTrans.position.y > 450)
                {
                    newXNum = 1750;
                }

                if (playerTrans.position.y > 550)
                {
                    newXNum = 1500;
                }

                if (playerTrans.position.y > 650)
                {
                    newXNum = 1250;
                }

                if (playerTrans.position.y > 750)
                {
                    newXNum = 1000;
                }

                if (playerTrans.position.y > 850)
                {
                    newXNum = 750;
                }

                XPos = Random.Range(playerTrans.transform.position.x - newXNum, playerTrans.transform.position.x + newXNum);
                XNeg = Random.Range(-playerTrans.transform.position.x - newXNum, -playerTrans.transform.position.x + newXNum);


                posPlus = new Vector2(XPos, playerTrans.transform.position.y + 50f);
                posNeg = new Vector2(XNeg, playerTrans.transform.position.y + 50f);


                CreatePlatform(posPlus, platformIndex);
                CreatePlatform(posNeg, platformIndex);

            }

            spawnHeight += Random.Range(1.6f, 3.5f);

        }

        //Debug.Log ("Spawn");

        platformsSpawnedUpTo = upTo;


    }

    void CreatePlatform(Vector2 position, int index)
    {

        //Debug.Log ("Creating");

      //  platParent = GameObject.Find("Platforms").transform;

        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Shape");
        bool create = true;

        foreach (GameObject platform in platforms)
        {
            if (position.y < platform.transform.position.y)
            {
                create = false;
            }
        }

        if (create)
        {
            //Debug.Log ("Creating");

            Transform pre = (Transform)Instantiate(platformsPre[index], position, Quaternion.identity);

            pre.transform.parent = platParent;
        }


    }

}
