using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{

    public float attackDamage;
    //public GameObject Player;
    private PlayerController pc;
    
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            pc = playerObject.GetComponent<PlayerController>();
        }
        else
        {
            Debug.LogError("No GameObject with tag 'Player' found in the scene.");
        }
        attackDamage = 3.0f;
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
