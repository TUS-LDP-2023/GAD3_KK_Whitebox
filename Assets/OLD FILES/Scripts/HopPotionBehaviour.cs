using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopPotionBehaviour : MonoBehaviour
{
    private ParticleSystem particle;
    private TrailRenderer trail;
    private MeshRenderer meshRenderer;
    private Rigidbody rb;
    public GameObject hop;
    void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        trail = GetComponentInChildren<TrailRenderer>();
        meshRenderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            meshRenderer.enabled = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            particle.Play();
            trail.enabled = false;
            Invoke(nameof(DestroyPotion), 3);
            CreateHop();
        }
    }

    public void DestroyPotion()
    {
        Destroy(gameObject);
    }

    public void CreateHop()
    {
        hop.SetActive(true);
    }

}
