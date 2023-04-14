using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootAudio : MonoBehaviour
{
    public Gun gun;

    public GameObject ShootingFire;
    
    // Start is called before the first frame update
    void Start()
    {
        ShootingFire.SetActive(false);
        gun = GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) /*&& gun.maxAmmo >= 0*/)
        {
            StooingA();
        }

        
        //if ((Input.GetKeyUp(KeyCode.Mouse0) && gun.maxAmmo == 0))
        //{
        //    StopFootsteps();
        //}

        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            StopShootingA();
        }

    }

    void StooingA()
    {
        ShootingFire.SetActive(true);
    }

    void StopShootingA()
    {
        ShootingFire.SetActive(false);
    }
}
