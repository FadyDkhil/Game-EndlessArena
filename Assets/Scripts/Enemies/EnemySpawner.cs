using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    
    //other spot
    private float randomNumber;
    public GameObject otherSpot;
    //STATS
    private GameObject stats;
    private EnemyStats enemyStats;
    //end STATS
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 10f;
    public Text waveText;
    private int waveNumber;

    private void Start()
    {
        stats = GameObject.FindGameObjectWithTag("EnemyStats");
        enemyStats = stats.GetComponent<EnemyStats>();
        // Start spawning enemies
        waveNumber = 0;
        spawnInterval = 0f;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true) // Spawn enemies indefinitely
        {
            if(spawnInterval > 4.0f){
                spawnInterval -= 1.5f;
            }else{
                //show wave text
                ShowWaveText();
                //change stats
                enemyStats.attackDamage++;
                enemyStats.attackCooldown = enemyStats.attackCooldown - 0.1f;
                enemyStats.maxHealth = enemyStats.maxHealth + 2.0f;
                //spawn boss?
                spawnInterval = 10f;

            }
            
            if(Random.Range(0,2) == 1){
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            }
            else{
                Instantiate(enemyPrefab, otherSpot.transform.position, otherSpot.transform.rotation);
            }
            // Instantiate the enemy prefab at the specified spawn point
            //Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            // Wait for the specified interval before spawning the next enemy
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void ShowWaveText()
    {
        waveNumber++;
        waveText.text = "Wave " + waveNumber.ToString();
        StartCoroutine(FadeWaveText());
    }

    IEnumerator FadeWaveText()
    {
        waveText.color = new Color(waveText.color.r, waveText.color.g, waveText.color.b, 0f); // Start with zero alpha (invisible)
        waveText.gameObject.SetActive(true);

        float fadeDuration = 1.0f; // Adjust this value for the duration of the fade animation
        float startTime = Time.time;

        while (Time.time - startTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, (Time.time - startTime) / fadeDuration);
            waveText.color = new Color(waveText.color.r, waveText.color.g, waveText.color.b, alpha);
            yield return null;
        }

        // Wait for a delay (e.g., 3 seconds)
        yield return new WaitForSeconds(3f);

        startTime = Time.time;
        while (Time.time - startTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, (Time.time - startTime) / fadeDuration);
            waveText.color = new Color(waveText.color.r, waveText.color.g, waveText.color.b, alpha);
            yield return null;
        }

        // Set text inactive after fading out
        waveText.gameObject.SetActive(false);
    }
}
