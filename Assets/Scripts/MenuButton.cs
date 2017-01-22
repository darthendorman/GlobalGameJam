using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {
    public GameController gameController;
    GameController gameScript;
    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void onTriggerEnter(Collider col)
    {
        Debug.Log("Start?");
        gameController.GetComponent<GameController>().startGame();
    }
}
