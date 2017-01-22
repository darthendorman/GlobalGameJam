using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject[] objects;
	public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime;            // How long between each spawn
	public int numberMultiplierPerWave;
	public Transform[] spawnPoints;
    public GameObject HUD;
    public Text text;

	private int waveNumber = 0;

	// Use this for initialization
	void Start () {
		SpawnRandom ();
		InvokeRepeating ("SpawnRandom", spawnTime, spawnTime);
        text.GetComponent<Text>();
	}

	public void SpawnRandom()
	{
		waveNumber++;

        //displayes waveNumbers to face
        StartCoroutine(displayWaveNumber(waveNumber));
		

		for (int i = 0; i < waveNumber * numberMultiplierPerWave; i++) {
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		}
	}

    IEnumerator displayWaveNumber(int waveNumber)
    {
        text.text = "Wave " + waveNumber;
        HUD.SetActive(true);
        yield return new WaitForSeconds(3);
        HUD.SetActive(false);
        
    }

    
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
