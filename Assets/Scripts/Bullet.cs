using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	float damage;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setDamage(float dmg){
		damage = dmg;
	}

	public float getDamage() {
		return damage;
	}

	void OnCollisionEnter(Collision collision)
	{
		Destroy (this.gameObject);
	}
}
