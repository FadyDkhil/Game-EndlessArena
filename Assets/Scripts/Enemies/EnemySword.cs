using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{

    private GameObject stats;
    private EnemyStats enemyStats;

    public float attackDamage;
    //public GameObject Player;
    private PlayerController pc;
    
    void Start()
    {
        //Get enemystats
        stats = GameObject.FindGameObjectWithTag("EnemyStats");
        enemyStats = stats.GetComponent<EnemyStats>();
        //STATS RETRIEVED
        attackDamage = enemyStats.attackDamage;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            pc = playerObject.GetComponent<PlayerController>();
        }
        else
        {
            Debug.LogError("No GameObject with tag 'Player' found in the scene.");
        }
        //pc = Player.GetComponent<PlayerController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            pc.TakeDamage(attackDamage);
        // Handle enemy damage here
        // You might want to access the enemy's health component and subtract damage
        // You can also play a sound or particle effect here
        }
    }
}
