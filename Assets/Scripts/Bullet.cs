using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public GameObject c;
     float damage;

	// Use this for initialization
	void Start () {
        damage= 100;
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

	void OnCollisionEnter(Collision col)
	{
        Debug.Log("Collided");
        if(col.gameObject.tag == "UI")
        {
            c.GetComponent<GameController>().startGame();
        }
        
        Destroy (this.gameObject);
        
	}
    
}
