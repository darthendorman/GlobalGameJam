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

}
