using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBehaviour : MonoBehaviour
{
    private ParticleSystem particle;
    private TrailRenderer trail;
    private MeshRenderer meshRenderer;
    private Rigidbody rb;
    public AudioSource breakP;
    public GameObject damager;
    void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        trail = GetComponentInChildren<TrailRenderer>();
        meshRenderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy")
        {
            meshRenderer.enabled = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            particle.Play();
            trail.enabled = false;
            Invoke(nameof(DestroyPotion), 3);
            CreateDamager();
            Debug.Log("Potion Hit");
            breakP.Play();
        }
    }

    public void DestroyPotion()
    {
        Destroy(gameObject);
    }

    public void CreateDamager()
    {
        damager.SetActive(true);
        Debug.Log("Damager Created");

    }

}




