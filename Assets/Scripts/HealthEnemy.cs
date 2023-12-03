using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{
    public int enemyMaxHealth = 100;
    public int enemyCurrentHealth;
    public NavMeshAgent agent;
    public EnemyAI enemyAI;
    Animator animator;
    public Image healthbarRed;
    public Image healthbarYellow;
    private float target = 1;
    public float reduceSpeed = 1;
    public AudioSource hurt;

    private void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        animator = GetComponent<Animator>();
        agent = transform.parent.GetComponent<NavMeshAgent>();   
    }

    public void DamageEnemy(int damage)
    {
        enemyAI.currentState = EnemyAI.State.FOLLOWING_PLAYER;
        enemyCurrentHealth -= damage;
        hurt.Play();
        if (enemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        UpdateHealthbarYellow();
        UpdateHealthbarRed();
        Invoke("ScrollEffect", 1);
    }
    public void UpdateHealthbarYellow()
    {
        target = (float)enemyCurrentHealth / enemyMaxHealth;
    }
    public void UpdateHealthbarRed()
    {
        healthbarRed.fillAmount = (float)enemyCurrentHealth / enemyMaxHealth;
    }
    public void ScrollEffect()
    {
        healthbarYellow.fillAmount = Mathf.MoveTowards(healthbarYellow.fillAmount, target, reduceSpeed * Time.deltaTime);
    }
    public void Death()
    {
        Destroy(gameObject);
    }

}
