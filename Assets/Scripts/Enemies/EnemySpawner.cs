using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 15f;
    public Text waveText;
    private int waveNumber;

    private void Start()
    {
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
                ShowWaveText();
                //change stats
                //spawn boss?
                spawnInterval = 15f;

            }
            
            // Instantiate the enemy prefab at the specified spawn point
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

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
