using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackComponent : MonoBehaviour
{
    public Bullet bullet;
    public int damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(gameObject.tag)) {
            Debug.Log(gameObject.tag + " hit " + other.tag);
            return;
        }

        
        HitboxComponent hitbox = other.GetComponent<HitboxComponent>();

        if (hitbox == null)
            return;

        if (bullet != null) {
            hitbox.Damage(bullet.damage);
        } else {
            hitbox.Damage(damage);
        }

        InvincibilityComponent invincibility = other.GetComponent<InvincibilityComponent>();
        if (invincibility != null) {
            invincibility.StartInvincibility();
        }
    }
}
