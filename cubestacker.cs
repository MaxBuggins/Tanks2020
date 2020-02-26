using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubestacker : MonoBehaviour
{
    Rigidbody rb;
    public ParticleSystem m_ExplosionParticles;

    void Start()
    {

    }

    void Update()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void OnCollisionEnter(Collision other)
    {

        Rigidbody targetRigidbody = other.gameObject.GetComponent<Rigidbody>();

        m_ExplosionParticles.transform.parent = null;

        m_ExplosionParticles.Play();

        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);
    }
}
