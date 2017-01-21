using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Enemy") {
			collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
			Destroy (collider.gameObject);
		}
	}
}
