using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public InputField username;
	public Text roundText;
	public Text scoreText;
	public GameObject updateScoreboard;

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
			//Debug.Log ("Game Finshed");
			player.SetActive (false);
			updateScoreboard.SetActive (true);
		} else if (!gameFinished) {
			if (enemiesCount == 0) {
				gameFinished = true;
				round += 1;
				Debug.Log ("Win Round");
			} else if (playerCount == 0) {
				Debug.Log ("Lose Round");
				gameFinished = true;
				round = 4;
				player.SetActive (false);
				updateScoreboard.SetActive (true);
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

	public void updateScore(){
		//update score
		string json = "{'username':'" + username.text.ToString() + "','score':" + scoreText.text.ToString() + "}";
		Debug.Log (json);

		string URL = "134.209.97.218:5051/scoreboards/13517019";

		Dictionary<string,string> parameters = new Dictionary<string,string> ();
		parameters.Add ("Content-Type", "application/json");
		parameters.Add ("Content-Length", json.Length.ToString ());

		json = json.Replace ("'", "\"");

		Debug.Log (json);

		byte[] postData = System.Text.Encoding.UTF8.GetBytes (json);

		WWW www = new WWW (URL, postData, parameters);

		StartCoroutine (WaitForRequest (www));
		Debug.Log ("udh start coroutine");
	}

	IEnumerator WaitForRequest(WWW www){
		Debug.Log("udh wait for request");
		yield return www;
		if (www.error == null) {
			Debug.Log ("success");
			Debug.Log (www.text);
		} else {
			Debug.Log ("error");
			Debug.Log (www.error);
		}
		SceneManager.LoadScene ("Menu");
	}
}
