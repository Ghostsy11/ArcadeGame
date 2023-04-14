using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator animator_M;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            animator_M.SetBool("OpenDoor", true);
       
        }

     
    }

    private void OnTriggerExit(Collider other)
    {
        animator_M.SetBool("OpenDoor", false);
    }
}

