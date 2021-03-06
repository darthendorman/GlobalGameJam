﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : SteamVR_TrackedController {
    
    public float charge;
    public float max;
    public float distance;
    public float targetDistance;
    GameObject Temporary_Bullet;
    public GameObject chargeBar;
    public GameObject gameController;

    public SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)controllerIndex); } }
    public Vector3 velocity { get { return controller.velocity; } }
    public Vector3 angularVelocity { get { return controller.angularVelocity; } }
    //Use the bullet prefab from the Component Inspector
    public GameObject Bullet; 

	//Use the speed of the bullet from the Component Insepctor
	public float Bullet_Force;

	// Use this for initialization
	protected override void Start () {
		base.Start ();
        charge = 0;
        distance = 0;
        
        
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();
        
            if (distance < targetDistance)
            {
                distance += controller.velocity.magnitude * Time.deltaTime;
            }
            updateBar(chargeBar);

        
        
	}

    void updateBar(GameObject bar)
    {

        chargeBar.transform.localScale = new Vector3((distance / targetDistance), transform.localScale.y, transform.localScale.z);

        

    }

	public override void OnTriggerClicked(ClickedEventArgs e)
	{
		base.OnTriggerClicked (e);
		if (distance > targetDistance)
        {
            Temporary_Bullet = Instantiate(Bullet, this.transform.position, this.transform.rotation) as GameObject;
			Temporary_Bullet.gameObject.GetComponent<Bullet> ().setDamage (distance * 100 / targetDistance);
            distance = 0;
        }
		Rigidbody Temporary_Rigidbody;
		Temporary_Rigidbody = Temporary_Bullet.GetComponent<Rigidbody> ();

		Temporary_Rigidbody.AddForce(transform.forward * Bullet_Force);

		// Self destruct after 10 seconds
		Destroy(Temporary_Bullet, 10.0f);

	}

}
