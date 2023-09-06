using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    //public GameObject Enemy;
    //private EnemyAI enemy;
    public float attackDamage = 2.0f;
    void Start()
    {
        //enemy = Enemy.GetComponent<EnemyAI>();
        attackDamage = 2.0f;
      //  pc = GetComponent<PlayerController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            EnemyAI enemy=other.GetComponent<EnemyAI>();
            enemy.TakeDamage(attackDamage);
            //Debug.Log("ENEMY ATTACKED!");

            
        // Handle enemy damage here
        // You might want to access the enemy's health component and subtract damage
        // You can also play a sound or particle effect here
        }
    }
}
