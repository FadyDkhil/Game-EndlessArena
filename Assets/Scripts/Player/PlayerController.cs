using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float maxHealth = 100f;
    [SerializeField]
    private float currentHealth;
    public Slider healthSlider;
    public Animator playerAnimator;
    public float attackDamage;
    public Text scoreText;
    public int score;
    public GameObject lightHealth;
    // public bool SwordAttacking;

    // Start is called before the first frame update
    void Start()
    {
        lightHealth.SetActive(false);
        score = 0;
        // SwordAttacking = false;
        currentHealth = maxHealth;
        playerAnimator = GetComponent<Animator>();
        attackDamage = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateHealthBar();
        scoreText.text = score.ToString();
    }
    
    void UpdateHealthBar()
    {
        float healthPercentage = currentHealth / maxHealth;
        // Set the value of the health bar slider
        healthSlider.value = healthPercentage;
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
        Destroy(this.gameObject);
    }

    public void Attack()
    {
        // Trigger the attack animation
        playerAnimator.SetTrigger("Attack");
        // SwordAttacking = true;

        // Handle any attack-related logic here
        // For example, apply damage to enemies or other actions
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("ENEMY ATTACKED!");
        // Handle enemy damage here
        // You might want to access the enemy's health component and subtract damage
        // You can also play a sound or particle effect here
        }
    }
    public void Heal(float healingAmount)
    {
        if(currentHealth+healingAmount > 99f){
            currentHealth = 100f;
        }
        else
        {
            currentHealth += healingAmount;
        }
        // Make sure health doesn't go below 0
        currentHealth = Mathf.Max(currentHealth, 0f);
        UpdateHealthBar();
        lightHealth.SetActive(true);
        StartCoroutine(HealingLight());

    }
     IEnumerator HealingLight()
    {
        yield return new WaitForSeconds(0.75f);
        lightHealth.SetActive(false);
        
    }

}
