using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUpPrefabs; // An array to hold your power-up prefabs.
    public Vector3 spawnRangeMin = new Vector3(-113f, 9.4f, 30f); // Minimum spawn position.
    public Vector3 spawnRangeMax = new Vector3(-95f, 9.4f, 48.5f); // Maximum spawn position.
    public float spawnInterval = 20f; // Time interval for spawning power-ups.
    public float powerUpDuration = 10f; // Time duration for which power-ups will be active.

    private void Start()
    {
        // Start spawning power-ups
        StartCoroutine(SpawnPowerUps());
    }

    IEnumerator SpawnPowerUps()
    {
        while (true) // Spawn power-ups indefinitely
        {
            // Randomly choose a power-up prefab from the array
            GameObject randomPowerUpPrefab = powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)];

            // Calculate a random spawn position within the specified range
            Vector3 randomSpawnPosition = new Vector3(
                Random.Range(spawnRangeMin.x, spawnRangeMax.x),
                Random.Range(spawnRangeMin.y, spawnRangeMax.y),
                Random.Range(spawnRangeMin.z, spawnRangeMax.z)
            );

            // Instantiate the chosen power-up at the random spawn position
            GameObject spawnedPowerUp = Instantiate(randomPowerUpPrefab, randomSpawnPosition, Quaternion.identity);

            // Set a timer to destroy the power-up after the duration
            Destroy(spawnedPowerUp, powerUpDuration);

            // Wait for the specified interval before spawning the next power-up
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

