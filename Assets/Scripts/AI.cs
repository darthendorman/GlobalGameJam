using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

	public float enemyMovementSpeed;
	public float damping;
	public Transform target;
	Rigidbody rigidbody;
	Renderer myRender;

	// Use this for initialization
	void Start () {
		myRender.GetComponent<Renderer> ();	
		rigidbody = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		LookAtPlayer ();
		AttackPlayer ();
	}

	void LookAtPlayer()
	{
		Quaternion rotation = Quaternion.LookRotation (target.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
	}

	void AttackPlayer()
	{
		rigidbody.AddForce (transform.forward * enemyMovementSpeed);
	}
}
