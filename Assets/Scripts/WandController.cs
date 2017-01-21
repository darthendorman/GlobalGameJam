using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : SteamVR_TrackedController {
    public Vector3 pPos;
    public Vector3 pos;
    public float charge;
    public float max;
    public float targetDistance;
	//Use the bullet prefab from the Component Inspector
	public GameObject Bullet; 

	//Use the speed of the bullet from the Component Insepctor
	public float Bullet_Force;

	// Use this for initialization
	protected override void Start () {
		base.Start ();
        max = 100;
        targetDistance = 20;
        charge = 0;
        pPos = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();
        float distance = Mathf.Abs(Vector3.Distance(pPos, pos));
        if (charge < max)
        {
            charge += distance / targetDistance;
        }
        if(charge == 100)
        {
            GameObject Temporary_Bullet1;
            Temporary_Bullet1 = Instantiate(Bullet, this.transform.position, this.transform.rotation) as GameObject;
        }
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
