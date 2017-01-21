using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : SteamVR_TrackedController {

	//Use the bullet prefab from the Component Inspector
	public GameObject Bullet; 

	//Use the speed of the bullet from the Component Insepctor
	public float Bullet_Force;

	// Use this for initialization
	protected override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();
	}

	public override void OnTriggerClicked(ClickedEventArgs e)
	{
		base.OnTriggerClicked (e);

		GameObject Temporary_Bullet;
		Temporary_Bullet = Instantiate (Bullet, this.transform.position, this.transform.rotation) as GameObject;

		Rigidbody Temporary_Rigidbody;
		Temporary_Rigidbody = Temporary_Bullet.GetComponent<Rigidbody> ();

		Temporary_Rigidbody.AddForce(transform.forward * Bullet_Force);

		// Self destruct after 10 seconds
		Destroy(Temporary_Bullet, 10.0f);

	}

}
