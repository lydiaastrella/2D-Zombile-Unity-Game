using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text roundText;

	int total_round=3;
	int round;
	public int enemiesCount = 0;
	public int playerCount = 0;
	int enemyPerRound;
	bool gameFinished = true;

	public GameObject enemy;
	public Transform[] spawnPoints;
	public GameObject player;
	public Transform playerSpawn;

	//Use this for initialization
	void Start () {
		Debug.Log("start");
		round = 1;
		enemyPerRound = spawnPoints.Length/total_round;
		//Instantiate (enemies, spawnPoints.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		if (gameFinished && round <= 3) {
			Spawn ();
		} else if (gameFinished && round > 3) {
			Debug.Log ("Game Finshed");
		} else if (!gameFinished) {
			if (enemiesCount == 0) {
				gameFinished = true;
				round += 1;
				Debug.Log ("Win Round");
			} else if (playerCount == 0) {
				Debug.Log ("Lose Round");
				gameFinished = true;
				round = 4;
			}
		}
	}

	void Spawn(){
		Debug.Log ("spawn");
		roundText.text = round.ToString();
		enemiesCount = enemyPerRound * round;
		playerCount = 1;
		player.transform.position = playerSpawn.position;
		//Instantiate (player, playerSpawn.position, Quaternion.identity);
		for (int i = 0; i < enemiesCount; i++) {
			GameObject enemySpawned = Instantiate (enemy, spawnPoints [i].position, Quaternion.identity);
			enemySpawned.SetActive (true);
		}
		gameFinished = false;
	}
}
