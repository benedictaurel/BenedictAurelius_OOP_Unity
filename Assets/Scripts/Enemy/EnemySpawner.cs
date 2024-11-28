using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public Enemy spawnedEnemy;
    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 3;
    public int totalKill = 0;
    private int totalKillWave = 0;
    [SerializeField] private float spawnInterval = 3f;

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0;
    public int defaultSpawnCount = 1;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;
    public CombatManager combatManager;
    public bool isSpawning = false;
    StatsMenu stats;

    public void Start()
    {
        spawnCount = defaultSpawnCount;
        stats = FindObjectOfType<StatsMenu>();
    }

    public void StartSpawning()
    {
        bool isFirstCall = true;
        int currentWaveLevel = (combatManager.waveNumber - 1) % 3 + 1;
        if (spawnedEnemy.GetLevel() <= currentWaveLevel)
        {
            isSpawning = true;
            combatManager.totalEnemies += spawnCount;

            if (isFirstCall)
            {
                stats.UpdateEnemiesLeft(combatManager.totalEnemies);
                isFirstCall = false;
            }

            StartCoroutine(SpawnRoutine());
        }
    }

    public void StopSpawning()
    {
        isSpawning = false;
        StopAllCoroutines();
    }

    private IEnumerator SpawnRoutine()
    {
        int currentSpawnCount = 0;
        int totalSpawnCount = spawnCount;
        while (isSpawning && currentSpawnCount < totalSpawnCount) {
            currentSpawnCount++;
            Enemy enemy = Instantiate(spawnedEnemy, transform.position, Quaternion.identity);
            enemy.enemyKilledEvent.AddListener(OnEnemyKilled);

            yield return new WaitForSeconds(spawnInterval);
        }

        StopSpawning();
    }

    private void OnEnemyKilled()
    {
        totalKill++;
        totalKillWave++;

        if (totalKill >= minimumKillsToIncreaseSpawnCount)
        {
            totalKill = 0;
            spawnCountMultiplier += multiplierIncreaseCount;
            spawnCount = defaultSpawnCount * spawnCountMultiplier;
        }
    }
}