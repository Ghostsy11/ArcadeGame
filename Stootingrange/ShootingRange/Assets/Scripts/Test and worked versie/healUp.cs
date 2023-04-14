using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healUp : MonoBehaviour
{

    private ParticleSystem ps;
    Renderer r;
    private AudioSource pickAudio;
    damagingPlayer HealingUp;


    private void Start()
    {
        r = GetComponent<Renderer>();
        pickAudio = GetComponent<AudioSource>();
        ps = GetComponent<ParticleSystem>();
        ps.Stop();
    }
    private void Update()
    {
        HealingUp = GetComponent<damagingPlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickAudio.Play();
            ps.Play();
            r.enabled = false;
            HealingUp = FindObjectOfType<damagingPlayer>();
            HealingUp.Healing(20);

            Destroy(gameObject, 0.5f);
        }
    }
}
