using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    private int maxHealth = 100;
    public int currentHealth;
    public Volume postProcessing;
    public AudioSource hurt;
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        postProcessing.weight = 1;
        hurt.Play();
        StartCoroutine(Hurt());

        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("Top Floor");
        }
    }

    IEnumerator Hurt()
    {
        yield return new WaitForSeconds(0.01f); 
        while(postProcessing.weight > 0)
        {
            postProcessing.weight -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }

}
