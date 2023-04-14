using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxStats : MonoBehaviour
{
    public float health;


    public void TakeDamageOnBox(float hp)
    {

        health -= hp;

    }
}
