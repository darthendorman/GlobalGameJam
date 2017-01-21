using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject[] objects;
	public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime = 3f;            // How long between each spawn
	public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnRandom", spawnTime, spawnTime);
	}

	public void SpawnRandom()
	{
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
