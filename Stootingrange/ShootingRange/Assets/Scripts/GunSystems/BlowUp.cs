    using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlowUp : MonoBehaviour
{
    public float delay;
    public float radius;
    public float force;
    public GameObject explosionEffect;
    float countdown;
    bool hasExploded = false;
    bool playsound = false;
    private AudioSource AudioSourceaudioSource;

    private void Start()
    {
        countdown = delay;
        AudioSourceaudioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded) 
        {
            
            Explode();
            isCaling();
            hasExploded = true;
        }
    }

    private void callsound()
    {
        playsound = AudioSourceaudioSource;
    }
    private void isCaling()
    {
        playsound = true;
        AudioSourceaudioSource.Play();
    }

    private void Explode()
    {
        GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);

        Destroy(explosion,3f);
        callsound();
        Physics.OverlapSphere(transform.position, radius);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObject in colliders)
        {
            Destructible dest  = nearbyObject.GetComponent<Destructible>();
            if (dest != null)
            { 
                dest.Destroyy();
            }
            
        }
        Collider[] collidersTomove = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in collidersTomove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(gameObject);
    }
}
