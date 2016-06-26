using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformCreationEndless : MonoBehaviour
{
	[Header ("Platforms")]
	public List<GameObject> easyPlatformsList;
	public List<GameObject> mediumPlatformsList;
	public List<GameObject> hardPlatformsList;

	public GameObject mergeTrack;
	public GameObject splitTrack;
	[Space (10)]
	public Transform playerTrans;
	Vector3 playerPos;

	public float spawnLimit;
	public float destroyNum;

	public Transform platParent;

	bool canSpawnPlatforms;

	bool create1;
	bool create2;
	bool createSplitandMerge;

	bool makeSplit;
	bool makeMerge;

	GameObject[] platforms1;
	GameObject[] platforms2;

	//float platfromsSpawnedUp;
	//int platIndex;
	//int platNum;

	[Header ("Game Master")]
	public bool isEasy;
	[Space (5)]
	public int mediumStartNum;
	public bool isMedium;
	[Space (5)]
	public int hardStartNum;
	public bool isHard;
	public float hardPos1;
	public float hardPos2;
	public float hardPos3;
	public float hardPos4;
	[Space (5)]
	public int splitNum;
	public int mergeNum;

	EndlessGameMaster gMaster;

	//bool make;

	void Awake ()
	{
		canSpawnPlatforms = true;
		createSplitandMerge = true;

		playerPos = playerTrans.position;

		gMaster = GetComponent<EndlessGameMaster> ();

		isEasy = true;

	}

	void Update ()
	{

		platforms1 = GameObject.FindGameObjectsWithTag ("Plat");
		platforms2 = GameObject.FindGameObjectsWithTag ("Plat");

		PlatformMaintance ();

		// Changes difficulty depending on how far the player has gone based on the score 
		if (gMaster.score >= mediumStartNum && gMaster.score < hardStartNum) {
			isEasy = false;
			isHard = false;

			isMedium = true;
		} else if (gMaster.score >= hardStartNum) {
			isHard = true;
			isMedium = false;
		}

		//Makes split and merge tracks
		if (gMaster.score >= 10 && gMaster.score < 30) {
			
			canSpawnPlatforms = false;

			makeSplit = true;

			SplitandMerge ();
		}

//		 else if (gMaster.score >= 20) {
//			canSpawnPlatforms = false;
//		}
//


		//print("Create1: " + create1.ToString());
		//print("Create2: " + create2.ToString());

		//  platIndex = Mathf.RoundToInt(Random.Range(0, platformsList.Count));
	}

	void PlatformMaintance ()
	{
		//float platCheck = playerTrans.position.y - platformCheck;

		GameObject[] platforms = GameObject.FindGameObjectsWithTag ("Plat");

		foreach (GameObject plat in platforms) {         // Destroys platforms
			if (plat.transform.position.y > playerTrans.position.y + destroyNum) {  // When to destroy platform
				Destroy (plat);
			}

		}

		SpawnPlatforms ();
	}

	void SpawnPlatforms ()  //(UpTo)
	{
		// Positions
		Vector3 pos = new Vector3 (playerPos.x, playerTrans.position.y - 5, playerPos.z);
		Vector3 pos2 = new Vector3 (playerPos.x, playerTrans.position.y - 20, playerPos.z);
		Vector3 pos3 = new Vector3 (playerPos.x, playerTrans.position.y - 35, playerPos.z);
		Vector3 pos4 = new Vector3 (playerPos.x, playerTrans.position.y - 50, playerPos.z);
		Vector3 pos5 = new Vector3 (playerPos.x, playerTrans.position.y - 65, playerPos.z);
		Vector3 pos6 = new Vector3 (playerPos.x, playerTrans.position.y - 80, playerPos.z);

		Vector3 pos7 = new Vector3 (playerPos.x, playerTrans.position.y - 95, playerPos.z);
		Vector3 pos8 = new Vector3 (playerPos.x, playerTrans.position.y - 110, playerPos.z);
		Vector3 pos9 = new Vector3 (playerPos.x, playerTrans.position.y - 125, playerPos.z);
		Vector3 pos10 = new Vector3 (playerPos.x, playerTrans.position.y - 140, playerPos.z);
		// Vector3 pos11 = new Vector3(playerPos.x, playerTrans.position.y - 180, playerPos.z);
		//Vector3 pos12 = new Vector3(playerPos.x, playerTrans.position.y - 200, playerPos.z);

		Vector3 posHard1 = new Vector3 (playerPos.x, playerTrans.position.y - hardPos1, playerPos.z);
		Vector3 posHard2 = new Vector3 (playerPos.x, playerTrans.position.y - hardPos2, playerPos.z);
		Vector3 posHard3 = new Vector3 (playerPos.x, playerTrans.position.y - hardPos3, playerPos.z);
		Vector3 posHard4 = new Vector3 (playerPos.x, playerTrans.position.y - hardPos4, playerPos.z);


		// TODO: Add hard platform psoition, to compoinsate for the new scale sizes 

		PlatformCreation1 (pos, pos2, pos3, pos4, pos5);//, pos6);

		if (isHard) {
			PlatformCreation2 (posHard1, posHard2, posHard3, posHard4);
		} else {
			PlatformCreation2 (pos7, pos8, pos9, pos10);
		}
	}



	void PlatformCreation1 (Vector3 platformPos1, Vector3 platformPos2, Vector3 platformPos3, Vector3 platformPos4, Vector3 platformPos5)//, Vector3 platformPos6)   // Instantiates the platforms at the start
	{
		if (canSpawnPlatforms) {
			create1 = true;

			// GameObject[] platforms = GameObject.FindGameObjectsWithTag("Plat");

			foreach (GameObject plat in platforms1) {         // Destroys Platforms
				// plat.gameObject.GetComponentInChildren<Renderer>().material.color = Color.green;

				if (platformPos1.y < plat.transform.position.y) {  // When to spawn new platforms  NOTE: Make 5f and public variable
					create1 = false;
				}

				plat.transform.parent = platParent;

			}

			if (create1 && isEasy) {   // Start off Easy
				Instantiate (easyPlatformsList [Mathf.RoundToInt (Random.Range (0, easyPlatformsList.Count))], platformPos1, Quaternion.identity);
				Instantiate (easyPlatformsList [Mathf.RoundToInt (Random.Range (0, easyPlatformsList.Count))], platformPos2, Quaternion.identity);
				Instantiate (easyPlatformsList [Mathf.RoundToInt (Random.Range (0, easyPlatformsList.Count))], platformPos3, Quaternion.identity);
				Instantiate (easyPlatformsList [Mathf.RoundToInt (Random.Range (0, easyPlatformsList.Count))], platformPos4, Quaternion.identity);
				Instantiate (easyPlatformsList [Mathf.RoundToInt (Random.Range (0, easyPlatformsList.Count))], platformPos5, Quaternion.identity);
				//Instantiate (easyPlatformsList [Mathf.RoundToInt (Random.Range (0, easyPlatformsList.Count))], platformPos6, Quaternion.identity);

			}
		}

	}

	void PlatformCreation2 (Vector3 platformPos1, Vector3 platformPos2, Vector3 platformPos3, Vector3 platformPos4) // Instantiates the platforms continualsy after the start
	{
		if (canSpawnPlatforms) {
			create2 = true;

			// GameObject[] platforms = GameObject.FindGameObjectsWithTag("Plat");

			foreach (GameObject plat in platforms2) {         // Destroys Platforms
				// plat.gameObject.GetComponentInChildren<Renderer>().material.color = Color.yellow;

				if (platformPos1.y > plat.transform.position.y - 15) {  // When to spawn new platforms  NOTE: Make 5f and public variable
					create2 = false;
				}

				plat.transform.parent = platParent;
			}

			if (create2 && isEasy) {   // Easy
				Instantiate (easyPlatformsList [Mathf.RoundToInt (Random.Range (0, easyPlatformsList.Count))], platformPos1, Quaternion.identity);
				Instantiate (easyPlatformsList [Mathf.RoundToInt (Random.Range (0, easyPlatformsList.Count))], platformPos2, Quaternion.identity);
				Instantiate (easyPlatformsList [Mathf.RoundToInt (Random.Range (0, easyPlatformsList.Count))], platformPos3, Quaternion.identity);
				Instantiate (easyPlatformsList [Mathf.RoundToInt (Random.Range (0, easyPlatformsList.Count))], platformPos4, Quaternion.identity);

			} else if (create2 && isMedium) {   // Medium
				Instantiate (mediumPlatformsList [Mathf.RoundToInt (Random.Range (0, mediumPlatformsList.Count))], platformPos1, Quaternion.identity);
				Instantiate (mediumPlatformsList [Mathf.RoundToInt (Random.Range (0, mediumPlatformsList.Count))], platformPos2, Quaternion.identity);
				Instantiate (mediumPlatformsList [Mathf.RoundToInt (Random.Range (0, mediumPlatformsList.Count))], platformPos3, Quaternion.identity);
				Instantiate (mediumPlatformsList [Mathf.RoundToInt (Random.Range (0, mediumPlatformsList.Count))], platformPos4, Quaternion.identity);

			} else if (create2 && isHard) {  // Hard
				Instantiate (hardPlatformsList [Mathf.RoundToInt (Random.Range (0, hardPlatformsList.Count))], platformPos1, Quaternion.identity);
				Instantiate (hardPlatformsList [Mathf.RoundToInt (Random.Range (0, hardPlatformsList.Count))], platformPos2, Quaternion.identity);
				Instantiate (hardPlatformsList [Mathf.RoundToInt (Random.Range (0, hardPlatformsList.Count))], platformPos3, Quaternion.identity);
				Instantiate (hardPlatformsList [Mathf.RoundToInt (Random.Range (0, hardPlatformsList.Count))], platformPos4, Quaternion.identity);

			}
		}


	}

	void SplitandMerge ()
	{
		Vector3 splitPos = new Vector3 (playerPos.x, playerTrans.position.y - 130, playerPos.z);
		Vector3 mergePos = new Vector3 (playerPos.x, playerTrans.position.y - 10, playerPos.z);

		if (createSplitandMerge) {
			if (makeSplit) {
				
				print ("Split");

				Instantiate (splitTrack, splitPos, Quaternion.identity);

				makeSplit = false;
				createSplitandMerge = false;

			}
		}
	}



}