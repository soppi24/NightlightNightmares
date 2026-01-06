using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;       
    public Transform prizeObject;         
    public Collider2D backgroundCollider; 
    public int maxEnemies = 5;           
    public float spawnInterval = 3f;      
    public float minSpawnDistanceFromRV = 5f;   
    public float minSpawnDistanceBetweenEnemies = 2f; 

    private List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("EnemySpawner: Enemy Prefab is not assigned.");
            enabled = false; 
            return;
        }
        if (prizeObject == null)
        {
            Debug.LogError("EnemySpawner: Prize Object is not assigned.");
            enabled = false;
            return;
        }
        if (backgroundCollider == null)
        {
            Debug.LogError("EnemySpawner: Background Collider is not assigned.");
            enabled = false;
            return;
        }

        InvokeRepeating(nameof(SpawnEnemies), 0f, spawnInterval);
    }
    void SpawnEnemies()
    {

        enemies.RemoveAll(enemy => enemy == null);

        int enemiesToSpawn = Mathf.Clamp(maxEnemies - enemies.Count, 0, maxEnemies);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector2 spawnPosition = GetValidSpawnPosition();

            if (enemyPrefab != null)
            {
                GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                enemies.Add(newEnemy);

                EnemyBehavior enemyScript = newEnemy.GetComponent<EnemyBehavior>();
                if (enemyScript != null && prizeObject != null)
                {
                    enemyScript.prize = prizeObject;
                }
            }
            else
            {
                Debug.LogError("EnemySpawner: Enemy Prefab is null, cannot instantiate.");
            }
        }
    }

    Vector2 GetValidSpawnPosition()
    {
        if (backgroundCollider == null)
        {
            Debug.LogError("EnemySpawner: Background Collider is missing.");
            return Vector2.zero; 
        }

        Bounds bounds = backgroundCollider.bounds;
        Vector2 spawnPosition;

        int attempts = 0; 
        do
        {
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);
            spawnPosition = new Vector2(randomX, randomY);

            attempts++;
        }
        while ((!IsFarEnoughFromPrize(spawnPosition) || !IsFarEnoughFromEnemies(spawnPosition)) && attempts < 50);

        if (attempts >= 50)
        {
            Debug.LogWarning("EnemySpawner: Could not find a valid spawn position after 50 attempts.");
        }

        return spawnPosition;
    }

    bool IsFarEnoughFromPrize(Vector2 position)
    {
        if (prizeObject == null)
        {
            Debug.LogError("EnemySpawner: Prize Object is not set.");
            return true;
        }

        Collider2D prizeCollider = prizeObject.GetComponent<Collider2D>();
        if (prizeCollider == null)
        {
            Debug.LogError("EnemySpawner: Prize Object is missing a Collider2D.");
            return true; 
        }

        Bounds prizeBounds = prizeCollider.bounds;

        if (prizeBounds.Contains(position))
        {
            return false;
        }

        float distanceToPrize = Vector2.Distance(position, prizeBounds.ClosestPoint(position));

        return distanceToPrize >= minSpawnDistanceFromRV;
    }


    bool IsFarEnoughFromEnemies(Vector2 position)
    {

        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                float distance = Vector2.Distance(position, enemy.transform.position);
                if (distance < minSpawnDistanceBetweenEnemies)
                {
                    return false;
                }
            }
        }
        return true; 
    }


}
