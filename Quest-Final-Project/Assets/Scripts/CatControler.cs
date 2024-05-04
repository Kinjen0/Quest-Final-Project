using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatControler : MonoBehaviour
{
    // Using code from the book for the patrolRoute
    public Transform patrolRoute;

    // Locations will not be used anymore for this project
    public List<Transform> locations;

    private int loacationIndex = 0;

    private Animator anim;

    private NavMeshAgent agent;

    // gameobject to store the player, so that it can start to follow them
    public GameObject player; 

    public bool playerInSphere = false;

    // boolean to track if the pet has been fed a treat, after which they will start to follow the player
    public bool hasEaten;
    public bool isSitting; 

    // Stopping distance for the navmesh 
    public float stoppingDistance; 

    //public GameManagerScript gameManagerScript;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //InitializePatrolRoute();

        //MoveToNextPatrolLocation();

        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", true);
        agent.destination = player.transform.position;
        agent.stoppingDistance = stoppingDistance;
        isSitting = false;


        hasEaten = false;
    }


    private void Update()
    {
        if(!isSitting)
        {
            anim.SetBool("isWalking", true);

            agent.destination = player.transform.position;
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInSphere = true;
            anim.SetBool("isWalking", false);
            anim.SetBool("isSitting", true);
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
            isSitting = true;
            
        }

    }
    public void OnTriggerExit(Collider other)
    {
        anim.SetBool("isWalking", true);

        if (other.gameObject.CompareTag("Player"))
        {
            // bit of code to make it so the cat will follow the player.
            playerInSphere = false;

            agent.isStopped = false;
            anim.SetBool("isSitting", false);
            agent.destination = player.transform.position;
            isSitting=false;
        }
    }
    // Method for use in the treat script
    public void eatTreat()
    {
        hasEaten = true;
        //gameManagerScript.quests[1] = true; 
    }




}
