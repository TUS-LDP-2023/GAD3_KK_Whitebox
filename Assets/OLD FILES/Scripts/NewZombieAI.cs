using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewZombieAI : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform[] patrolPoints;
    private int points = 0;
    private Animator animator;
    public Rigidbody rb;

    enum State
    {
        PATROLLING,
        SPOTTED
    }

    State currentState = State.PATROLLING;
    public Transform playerTarget;
    public bool Spotted = false;
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();

    }
    void MovetoNextPoint()
    {
        if (patrolPoints.Length == 0)
        {
            return;
        }

        agent.destination = patrolPoints[points].position;
        if (agent.remainingDistance < 0.1)
        {
            points = (points + 1) % patrolPoints.Length;
        }
    }

    private void Update()
    {
        if (agent.remainingDistance < 0.1 && currentState == State.PATROLLING)
        {
            MovetoNextPoint();
        }

        if(Spotted == true)
        {
            currentState = State.SPOTTED;
        } else
        {
            currentState = State.PATROLLING;
        }

        if(currentState == State.SPOTTED)
        {
            agent.destination = playerTarget.position;
        }

        if(rb.velocity.magnitude > 0.1)
        {
            animator.SetBool("isWalking", true);
        }

    }

    
}
