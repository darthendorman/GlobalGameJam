﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision)
	{
        Debug.Log("Entered collision with " + collision.gameObject.name);
		gameObject.GetComponent<Renderer>().material.color = Color.red;
	}

    void OnTriggerEnter(Collider collider)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }
}
