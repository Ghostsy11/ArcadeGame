using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        //Player= GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, step);
 
    }
}
