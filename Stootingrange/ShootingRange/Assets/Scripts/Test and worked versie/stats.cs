using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statss : MonoBehaviour
{
    public float health = 100;

    public void TakeDamageOnPlayer(float hp)
    {
        health -= hp;

    }
}
