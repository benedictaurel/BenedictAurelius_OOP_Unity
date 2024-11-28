using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] Weapon weaponHolder;
    Weapon weapon;

    AudioSource audioSource;

    bool isGameActive = false;
    MainMenu mainMenu;

    void Awake() {
        weapon = Instantiate(weaponHolder);
        audioSource = GetComponent<AudioSource>();
        mainMenu = FindObjectOfType<MainMenu>();
    }

    void Start() {
        if (weapon != null) {
            TurnVisual(false, weapon);
        }
        weapon.transform.SetParent(transform, false);
        weapon.transform.localPosition = transform.position;
        weapon.parentTransform = transform;
        audioSource.Stop();
    }

    public void EnablePickup() {
        isGameActive = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (!isGameActive) return;

        if (weapon != null && other.gameObject.CompareTag("Player")) {
            Weapon currentWeapon = other.GetComponentInChildren<Weapon>();

            if (currentWeapon != null) { // Kalo udah ada
                weapon.transform.SetParent(other.transform);
                weapon.transform.localPosition = new Vector2(0.0f, 0.0f);
                TurnVisual(false, currentWeapon);
            }
            // Kalo belom ada
            TurnVisual(true);
            weapon.transform.SetParent(other.transform);
            weapon.transform.localPosition = new Vector2(0.0f, 0.0f);
        }
    }

    void TurnVisual(bool on)
    {
        audioSource.Play();
        weapon.gameObject.SetActive(on);
    }

    void TurnVisual(bool on, Weapon weapon)
    {
        audioSource.Play();
        weapon.gameObject.SetActive(on);
    }
}