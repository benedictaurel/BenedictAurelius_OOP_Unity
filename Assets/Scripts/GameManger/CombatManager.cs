using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners;
    public float timer = 0;
    [SerializeField] float waveInterval = 5f;
    public int waveNumber = 0;
    public int totalEnemies = 0;
    StatsMenu stats;

    private void Start()
    {
        waveNumber = 0;
        stats = FindObjectOfType<StatsMenu>();
    }

    private void Update()
    {
        if (totalEnemies == 0 || waveNumber == 0) {
            timer += Time.deltaTime;
            if (timer >= waveInterval)
            {
                StartNewWave();
            }
        }
    }

    private void StartNewWave()
    {
        totalEnemies = 0;
        timer = 0;
        waveNumber++;
        stats.UpdateWave(waveNumber);
        
        foreach (var spawner in enemySpawners)
        {
            spawner.StartSpawning();
        }
    }

    public void OnEnemyKilled()
    {
        totalEnemies--;
        stats.UpdateEnemiesLeft(totalEnemies);
    }
}