using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints = new List<Transform>();            
    public int index = 0;
    public SphereCollider pov;
    private Animator animator;
    public enum State
    {
        PATROLLING,
        FOLLOWING_PLAYER,
        ATTACKING_PLAYER
    }
    public State currentState;

    NavMeshAgent agent;
    public Transform target;

    void Start()
    {
        agent = transform.parent.GetComponent<NavMeshAgent>();
        pov = GetComponent<SphereCollider>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        switch (currentState)
        {
            case State.PATROLLING:
                Patrol();
                pov.radius = 5f;
                agent.speed = 3.5f;
                animator.SetBool("Spotted", false);
                StopAllCoroutines();
                break;
            case State.FOLLOWING_PLAYER:
                agent.destination = target.position;
                pov.radius = 10f;
                agent.speed = 7f;
                animator.SetBool("Spotted", true);
                StopAllCoroutines();
                break;
            case State.ATTACKING_PLAYER:
                agent.destination = target.position;
                agent.speed = 0f;
                StartCoroutine(Attack());
                break;
        }

        if(currentState == State.FOLLOWING_PLAYER && agent.remainingDistance < 3)
        {
            if(currentState != State.ATTACKING_PLAYER)
            {
            currentState = State.ATTACKING_PLAYER;
            }
        } 
        else if (currentState == State.ATTACKING_PLAYER && agent.remainingDistance > 3)
        {
            if (currentState != State.FOLLOWING_PLAYER)
            {
                currentState = State.FOLLOWING_PLAYER;
            }
        }

    }

    public void Patrol()
    {

        if (agent.remainingDistance < 0.5)
        {
            index++;
        }

        if (index / patrolPoints.Count == 1)
        {
            index = 0;
        }

        agent.destination = patrolPoints[index].position;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            currentState = State.FOLLOWING_PLAYER;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            currentState = State.PATROLLING;
        }
    }

    IEnumerator Attack()
    {
        animator.SetTrigger("Attacking");
        yield return new WaitForSeconds(Random.Range(0.1f,1f));
        animator.SetTrigger("Attacking");
    }

}
