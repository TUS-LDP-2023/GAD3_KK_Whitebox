using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{

    public Transform[] patrolPoints;
    private int points = 0; 
    public Rigidbody rb;

    enum State
    {
        PATROLLING,
        SPOTTED
    }

    State currentState;

    NavMeshAgent agent;
    public Transform playerTarget;
    public Animator animator;

    public bool Spotted = false;

    void Start()
    {
        State currentState = State.PATROLLING;

        agent = GetComponent<NavMeshAgent>();

        rb = GetComponent<Rigidbody>(); 

        animator = GetComponent<Animator>();    

    }

    void Update()
    {
        if(agent.remainingDistance < 0.1 && currentState == State.PATROLLING)
        {
            MovetoNextPoint();
        }

        if(Spotted == true)
        {
            currentState = State.SPOTTED;
        }
        else
        {
            currentState = State.PATROLLING;
        }
        if (currentState == State.SPOTTED)
        {
            agent.destination = playerTarget.position;
            agent.stoppingDistance = 2;
            if (agent.remainingDistance < 0.5) 
            {
                agent.speed = 0f;
            }
            else if (agent.remainingDistance > 0.5)
            {
                agent.speed = 3.5f;
            }
        }

        if (currentState == State.PATROLLING)
        {
            MovetoNextPoint();
            agent.stoppingDistance = 0.1f;
        }



    }

    void MovetoNextPoint()
    {
        if(patrolPoints.Length == 0)
        {
            return;
        }

        agent.destination = patrolPoints[points].position;
        if(agent.remainingDistance < 0.1)
        {
        points = (points + 1) % patrolPoints.Length;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Spotted = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Spotted = false;
        }
    }
}
