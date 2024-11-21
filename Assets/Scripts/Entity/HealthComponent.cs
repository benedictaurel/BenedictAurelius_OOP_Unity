using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 100;
    int health;
    CombatManager combatManager;

    void Start()
    {
        health = maxHealth;
        combatManager = FindObjectOfType<CombatManager>();
    }

    public int getHealth() {
        return health;
    }

    public void Substract(int health) {
        this.health -= health;

        if (this.health <= 0) {
            Destroy(gameObject);
            combatManager.OnEnemyKilled();
        }
    }
}
