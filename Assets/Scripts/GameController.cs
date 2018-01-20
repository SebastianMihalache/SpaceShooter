using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazzardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    private int score;
    public Text restartText;
    public Text gameOverText;
    private bool gameover;
    private bool restart;

    private void Start()
    {
        gameover = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";
       StartCoroutine (SpawnWaves());
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("scene");
            }
        }
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < hazzardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameover)
            {
                restartText.text = "Press 'R' to restart";
                restart = true;
                break;
            }
            
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();

    }

    private void UpdateScore ()
    {
        scoreText.text = "Count " + score.ToString ();

    }

    public void GameOver()
    {
        gameOverText.text = "GAME OVER";
        gameover = true;
    }

}
