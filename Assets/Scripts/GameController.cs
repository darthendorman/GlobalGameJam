using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject[] objects;
	public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime;            // How long between each spawn
	public int numberMultiplierPerWave;
	public Transform[] spawnPoints;

	private int waveNumber = 0;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnRandom", spawnTime, spawnTime);
	}

	public void SpawnRandom()
	{
		waveNumber++;

		// TODO: Implement HUD to say "Wave X start"

		for (int i = 0; i < waveNumber * numberMultiplierPerWave; i++) {
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
