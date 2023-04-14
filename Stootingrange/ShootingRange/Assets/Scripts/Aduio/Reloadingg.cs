using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reloadingg : MonoBehaviour
{
    public GameObject Reloading;

    // Start is called before the first frame update
    void Start()
    {
        Reloading.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            footsteps();
        }

        if (Input.GetKeyUp("r"))
        {
            StopFootsteps();
        }

    }

    void footsteps()
    {
        Reloading.SetActive(true);
    }

    void StopFootsteps()
    {
        Reloading.SetActive(false);
    }
}
