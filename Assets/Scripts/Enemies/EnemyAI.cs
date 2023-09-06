using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public float chaseRange = 10f;
    public float attackRange = 2f; 
    //public float attackDamage;
   // public Transform player;
    private string playerTag = "Player";
    private Transform player;
     
    public Animator enemyAnimator;
    private NavMeshAgent navMeshAgent;
    private float nextAttackTime = 0f;
    private float currentHealth;
    private Slider healthSlider;
    private PlayerController pc;

    //ENEMY STATS
    private GameObject stats;
    private EnemyStats enemyStats;

    //GET FROM ENEMYSTATS
    public float attackCooldown;
    public float maxHealth;
    void Start()
    {
        //Get enemystats
        stats = GameObject.FindGameObjectWithTag("EnemyStats");
        enemyStats = stats.GetComponent<EnemyStats>();
        //Retrieving stats
        attackCooldown = enemyStats.attackCooldown;
        maxHealth = enemyStats.maxHealth;
        //STATS RETRIEVED

        currentHealth = maxHealth;
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimator.SetBool("isMoving", false);
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
        if (player == null)
        {
            Debug.LogError("No GameObject with tag '" + playerTag + "' found in the scene.");
        }
        pc = player.GetComponent<PlayerController>();
        // Get the Slider component from the children of the enemy
        healthSlider = GetComponentInChildren<Slider>();

        if (healthSlider == null)
        {
            Debug.LogError("No Slider component found in children of the enemy GameObject.");
        }
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
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        // Make sure health doesn't go below 0
        currentHealth = Mathf.Max(currentHealth, 0f);
        UpdateHealthBar();

        // Check if the player's health reaches 0 or below, and handle death if needed
        if (currentHealth <= 0)
        {
            
            Die(); // Implement this method to handle player death
        }
    }

    private void Die(){
        pc.score++;
       // pc.scoreText.text = pc.score.ToString();
        Destroy(this.gameObject);
    }
    void UpdateHealthBar()
    {
        float healthPercentage = currentHealth / maxHealth;
        // Set the value of the health bar slider
        healthSlider.value = healthPercentage;
    }
}
