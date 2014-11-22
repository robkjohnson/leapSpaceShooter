using UnityEngine;
using System.Collections;

public class GameConroller : MonoBehaviour 
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float startWait;
	public float spawnWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool reset;
	private int score;

	void Start()
	{
		score = 0;
		UpdateScore();
		gameOver = false;
		reset = false;

		restartText.text = "";
		gameOverText.text = "";
		StartCoroutine (spawnWaves ());
	}

	void Update()	
	{
		if (reset) 
		{
			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}


	IEnumerator spawnWaves()
	{
		yield return new WaitForSeconds(startWait);

		while(true)
		{
			for (int i=0;i<hazardCount;i++) 
			{
					Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					Quaternion spawnRotation = Quaternion.identity;
					Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);

			}
			yield return new WaitForSeconds(waveWait);

			if(gameOver)
			{
				restartText.text = "press 'R' to Reset";
				reset = true;
				break;
			}
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOverText.text = "GAME OVER!!";
		gameOver = true;


	}
}
