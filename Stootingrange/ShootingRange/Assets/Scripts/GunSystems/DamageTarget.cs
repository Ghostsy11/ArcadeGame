using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTarget : MonoBehaviour
{
    public float health = 100f;
    keepScore keep;

    private void Start()
    {
        keep = GetComponent<keepScore>();
    }

    private void Update()
    {
        keep = GetComponent<keepScore>();
    }
    public void TakeDamgae(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    } 
    void Die()
    {
        keep = FindObjectOfType<keepScore>();
        Destroy(gameObject);
        keep.AddScore(1);
    }

}
