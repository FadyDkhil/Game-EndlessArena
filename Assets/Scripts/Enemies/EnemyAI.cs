using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float chaseRange = 10f;
    public float attackRange = 2f;
    public float attackCooldown = 2f;
    public float attackDamage;
    public Transform player;
    public Animator enemyAnimator;
    private NavMeshAgent navMeshAgent;
    private float nextAttackTime = 0f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimator.SetBool("isMoving", false);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            enemyAnimator.SetBool("isMoving",true);
            // Chase the player
            navMeshAgent.SetDestination(player.position);

            if (distanceToPlayer <= attackRange)
            {
                // Attack the player
                if (Time.time >= nextAttackTime)
                {
                    enemyAnimator.SetTrigger("Attack");
                    // Implement attack logic here, e.g., deal damage to the player
                    nextAttackTime = Time.time + attackCooldown;
                }
            }
        }
        else
        {
            enemyAnimator.SetBool("isMoving",false);
            // Stop chasing and idle or patrol if needed
            navMeshAgent.SetDestination(transform.position);
        }
    }
}
