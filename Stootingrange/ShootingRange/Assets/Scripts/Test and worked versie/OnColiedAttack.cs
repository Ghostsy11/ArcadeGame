using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnColiedAttack : MonoBehaviour
{


    damagingPlayer damagingPlayerr;
    private void Start()
    {
       GameObject player = GameObject.Find("Player");
        damagingPlayerr = player.GetComponent<damagingPlayer>();//player uit scene halen, dan daarop de component zoeken
        Debug.Log(damagingPlayerr);
    }
    
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.tag == "Player")
        {
            damagingPlayerr.TakeDamageOnPlayer(20);
            Destroy(gameObject);
           
        }
    }
}
    