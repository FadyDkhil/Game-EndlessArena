using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float attackDamage;
    public GameObject Player;
    private PlayerController pc;
    
    void Start()
    {
        attackDamage = 2.0f;
        pc = GetComponent<PlayerController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            if(pc.SwordAttacking == true){
                Debug.Log("ENEMY ATTACKED!");
            }
            
        // Handle enemy damage here
        // You might want to access the enemy's health component and subtract damage
        // You can also play a sound or particle effect here
        }
    }
}