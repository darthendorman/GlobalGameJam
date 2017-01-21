using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {

	public Transform destination;

	private NavMeshAgent agent;

	public GameObject target;

	void Start()
	{
		agent = gameObject.GetComponent<NavMeshAgent>();
		destination = target.transform;
		agent.SetDestination(destination.position);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Bullet") {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Camera (eye)") {
			Destroy (this.gameObject);
		}
	}
}
