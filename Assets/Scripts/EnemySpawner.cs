using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StartCondition
{
    INSTANT,
    ONPLAYERENTER
}

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Info")]
    public SpawnableObject[] enemies;

    [Header("Spawning Settings")]
    public int maxTotalEnemies = 10;
    public float spawnInterval = 10f;
    public Vector3 spawnAreaSize;
    public StartCondition startCondition;
    public Transform EnemiesParent;

    private int currentEnemiesCount = 0;
    private bool startedSpawning = false;

    private void Start()
    {
        StartSpawn();
    }

    private void Update()
    {
        if (startCondition == StartCondition.ONPLAYERENTER)
        {
            if (!startedSpawning && IsPlayerInSpawnArea())
            {
                    InvokeRepeating("Spawn", 0f, spawnInterval);
                    startedSpawning = true;
            }
            if (startedSpawning && !IsPlayerInSpawnArea())
            {

                    CancelInvoke("Spawn");
                    startedSpawning = false;
                
            }
        }
    }

    #region Spawning
    public void Spawn()
    {
        if (currentEnemiesCount >= maxTotalEnemies) return;

        currentEnemiesCount++;

        SpawnableObject enemy = DecideEnemyToSpawn();
        Vector3 spawnAreaCenter = transform.position;


        Vector3 spawnPosition = new Vector3(
                  Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2),
                  1000f,
                  Random.Range(spawnAreaCenter.z - spawnAreaSize.z / 2, spawnAreaCenter.z + spawnAreaSize.z / 2)
              );

        RaycastHit[] hits = Physics.RaycastAll(spawnPosition, Vector3.down, Mathf.Infinity);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag(Tags.TERRAIN))
            {
                spawnPosition.y = hit.point.y;
            }
            else
            {
                Debug.LogWarning("Spawn position is not over the terrain.");
            }
        }
        Instantiate(enemy.Prefab, spawnPosition, Quaternion.identity);

    }

    public void StartSpawn()
    {
        if (startCondition == StartCondition.INSTANT)
        {
            InvokeRepeating("Spawn", 0f, spawnInterval);
            startedSpawning = true;
        }

    }
    #endregion

    public bool IsPlayerInSpawnArea()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, spawnAreaSize / 2, Quaternion.identity);
        foreach (Collider gameObject in colliders)
        {
            if (gameObject.CompareTag(Tags.PLAYER))
            {
                return true;
            }
        }
        return false;
    }

    #region Decision Making
    private SpawnableObject DecideEnemyToSpawn()
    {
        float totalProbability = 0f;
        foreach (SpawnableObject enemy in enemies)
        {
            totalProbability += enemy.Probability;
        }

        float randomValue = Random.Range(0f, totalProbability);

        float cumulativeProbability = 0f;
        for (int i = 0; i < enemies.Length; i++)
        {
            cumulativeProbability += enemies[i].Probability;
            if (randomValue <= cumulativeProbability)
            {
                return enemies[i];
            }
        }

        Debug.LogWarning("No Enemy is chosen to spawn!");
        return null;
    }
    #endregion


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
