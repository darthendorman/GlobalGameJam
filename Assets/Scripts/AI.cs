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

    bool running;

    public AudioSource honk;
    public AudioSource laugh;


    AudioSource[] sounds;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        target = GameObject.Find("Camera (eye)");
        destination = target.transform;
        running = gameController.GetComponent<GameController>().running;
        
        
        
        sounds = gameObject.GetComponents<AudioSource>();
        honk = sounds[0];
        laugh = sounds[1];
    }

    void Update()
    {
        float distanceToTarget = Vector3.Distance(destination.position, gameObject.transform.position);
        agent.SetDestination(destination.position);
        running = gameController.GetComponent<GameController>().running;
        if( distanceToTarget < 3.0f && !laugh.isPlaying)
            {
                
                laugh.Play();
            }
        if (running) {
        destination = target.transform;
		agent.SetDestination (destination.position);
            if (health <= 0)
            {
                gameController.GetComponent<GameController>().score++;
                honk.Play();
                Die();
            }
        
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
