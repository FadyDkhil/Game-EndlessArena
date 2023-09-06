using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float attackDamage = 2.0f;
    private float originalAttackDamage;
    private float damageBoostDuration = 15.0f;
    private bool isDamageBoosted = false;
    public GameObject swordUP;
    private GameObject stats;
    private PlayerStats playerStats;

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("PlayerStats");
        playerStats = stats.GetComponent<PlayerStats>();
        attackDamage = playerStats.attackDamage;
        swordUP.SetActive(false);
        originalAttackDamage = attackDamage;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyAI enemy = other.GetComponent<EnemyAI>();
            enemy.TakeDamage(attackDamage);
            // Debug.Log("ENEMY ATTACKED!");

            // Handle enemy damage here
            // You might want to access the enemy's health component and subtract damage
            // You can also play a sound or particle effect here
        }
    }

    public void DamageUp()
    {
        if (!isDamageBoosted)
        {
            // Increase attack damage by +5
            if(attackDamage * 2.5f < 10f)
            {
                attackDamage = 10f;
            }
            else
            {
                attackDamage += (attackDamage * 2.5f);
            }
            isDamageBoosted = true;
            swordUP.SetActive(true);

            // Start a timer to reset the attack damage after the specified duration
            StartCoroutine(ResetDamage());
        }
    }

    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(damageBoostDuration);

        // Reset attack damage to its original value
        attackDamage = originalAttackDamage;
        isDamageBoosted = false;
        swordUP.SetActive(false);
    }
}
