using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {

    public Transform destination;

    private NavMeshAgent agent;

    public GameObject target;

    public float damageDealt;

    public float health;

    public GameObject gameController;


    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        target = GameObject.Find("Camera (eye)");
        destination = target.transform;

        agent.SetDestination(destination.position);

    }

    void Update()
    {
        if (gameController.GetComponent<GameController>().running == true)
        {
            if (health <= 0)
            {
                Die();
            }
            destination = target.transform;
        }
    }



    public void TakeDamage(float dmg)
    {
        this.health -= dmg;
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet") {
            TakeDamage(collision.gameObject.GetComponent<Bullet>().getDamage());
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Camera (eye)") {
            collider.gameObject.GetComponent<playerBehavior>().takeDamage(damageDealt);
            Destroy(this.gameObject);
        }
    
    }

}
