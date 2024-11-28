using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthComponent : MonoBehaviour
{
    Enemy enemy;
    public int maxHealth = 100;
    int health;
    CombatManager combatManager;
    StatsMenu stats;
    public int totalPoints = 0;

    void Start()
    {
        health = maxHealth;
        combatManager = FindObjectOfType<CombatManager>();
        stats = FindObjectOfType<StatsMenu>();
        enemy = GetComponentInParent<Enemy>();
    }

    public int getHealth() {
        return health;
    }

    public void Substract(int health) {
        this.health -= health;

        if (this.health <= 0) {
            if (gameObject.CompareTag("Enemy")) {
                totalPoints += enemy.GetLevel();
                stats.AddPoints(totalPoints);
                combatManager.OnEnemyKilled();
            }

            Destroy(gameObject);
        }
    }
}
