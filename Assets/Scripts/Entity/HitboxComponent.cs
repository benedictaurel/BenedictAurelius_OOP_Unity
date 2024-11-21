using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    public HealthComponent health;
    public InvincibilityComponent invincibility;

    void Start() {
        health = GetComponent<HealthComponent>();
        invincibility = GetComponent<InvincibilityComponent>();
    }

    public void Damage(int damage) {
        if (!invincibility.isInvincible) {
            health.Substract(damage);
        }
    }

    public void Damage(Bullet bullet) {
        if (!invincibility.isInvincible) {
            health.Substract(bullet.damage);
        }
    }
}
