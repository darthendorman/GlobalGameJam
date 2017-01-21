using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject[] objects;
	public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime;            // How long between each spawn
	public int numberMultiplierPerWave;
	public Transform[] spawnPoints;
    public GameObject text;

	private int waveNumber = 0;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnRandom", spawnTime, spawnTime);

	}

	public void SpawnRandom()
	{
		waveNumber++;

        //displayes waveNumbers to face
        displayWaveNumber(waveNumber);
		

		for (int i = 0; i < waveNumber * numberMultiplierPerWave; i++) {
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		}
	}


    void displayWaveNumber(int wave)
    {

    }
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
