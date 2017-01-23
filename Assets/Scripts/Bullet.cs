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
        if(col.gameObject.tag == "UI")
        {
        Debug.Log("Collided");
            c.GetComponent<GameController>().startGame();
            c.SetActive(false);
        }
        
        Destroy (this.gameObject);
        
	}
    
}
