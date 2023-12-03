using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePotion : MonoBehaviour
{
    

    private void Start()
    {
        Debug.Log("Damager Present");
    }
    private void OnTriggerEnter(Collider other)
    {
        HealthEnemy enemyHealth = other.GetComponent<HealthEnemy>();

        if (other.gameObject.tag == "Enemy")
        {
            enemyHealth.DamageEnemy(Random.Range(5, 10));
            Destroy(gameObject);
        }
    }

}
