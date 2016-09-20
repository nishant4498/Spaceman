﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues; 
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;
	private int score;

    void Update() {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                SceneManager.LoadScene("Main Menu");
            }
        }
    }

	void Start(){
		score = 0;
        gameOver = false;
        restart = false;
        restartText.text = "";
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		while(true){
			for(int i=0; i < hazardCount; i++){
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x),spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

            if (gameOver) {
                restartText.text = "Press 'Esc' to restart";
                restart = true;
                break;
            }
		}
	}

	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

    public void GameOver()
    {
        restartText.text = "Game Over!";
        gameOver = true;
    }
}
