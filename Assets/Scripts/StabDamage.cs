using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabDamage : MonoBehaviour
{
    public AudioSource stab;
    private void OnTriggerEnter(Collider other)
    {
        HealthEnemy enemyHealth = other.GetComponent<HealthEnemy>();

        if (other.gameObject.tag == "Enemy")
        {
            enemyHealth.DamageEnemy(Random.Range(10, 15));
            Debug.Log("Stab");
            stab.Play();
        }
    }

}
