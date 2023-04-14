using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraPositon : MonoBehaviour
{

    public Transform camaraPosition;

    void Update()
    {
        

        transform.position = camaraPosition.position;
    }
}
