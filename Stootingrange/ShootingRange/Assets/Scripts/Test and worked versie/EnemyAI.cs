using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField] Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField] float walkPointRange;
    [SerializeField] float timeBetweenAttacks;
    bool alreadyAtacked;
    damagingPlayer damagingPlayerr;
    [SerializeField] float sightRange, attackRange;
    public bool playerInsightRange, playerInAttack;
    public int dAmagePLayer;

   // private playerStats playerStats;
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent= GetComponent<NavMeshAgent>();
        damagingPlayerr = player.GetComponent<damagingPlayer>();
        // playerStats = GetComponent<playerStats>();

    }

    void Update()
    {
        playerInsightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttack = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInsightRange && !playerInAttack) Patroling();
        if (playerInsightRange && !playerInAttack) ChasePlayer();
        if (playerInAttack && playerInsightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3  distanceTowalkPoint = transform.position - walkPoint;
        if (distanceTowalkPoint.magnitude < 1f)
            walkPointSet = false;

    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, - transform.up,2f, whatIsGround))
            walkPointSet= true;

    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        
        if (!alreadyAtacked)
        {
            //attack code here 
            Debug.Log("au");
            damagingPlayerr.TakeDamageOnPlayer(dAmagePLayer);

            alreadyAtacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    private void ResetAttack()
    {
        alreadyAtacked= false;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Enemy"))
    //    {
    //        playerStats.UpdateHealth(damageTHePlayer);
    //        Debug.Log(playerStats);
    //    }
    //}


    //public void ReceiveDamage()
    //{


    //    playerStats.UpdateHealth(damageTHePlayer);


    //}
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

}
