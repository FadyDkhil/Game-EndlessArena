using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float attackDamage = 3.0f;
    public float attackCooldown = 2f;
    public float maxHealth = 6f;


    // Start is called before the first frame update
    void Start()
    {
        attackDamage = 2.0f;
        attackCooldown = 2.1f;
        maxHealth = 4f;
    }
}
