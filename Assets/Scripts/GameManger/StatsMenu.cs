using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StatsMenu : MonoBehaviour
{
    UIDocument document;
    Label health;
    Label points;
    Label wave;
    Label enemiesLeft;
    Player player;
    public int totalPoints = 0;

    void Awake() {
        document = GetComponent<UIDocument>();
        health = document.rootVisualElement.Q("Health") as Label;
        points = document.rootVisualElement.Q("Points") as Label;
        wave = document.rootVisualElement.Q("Wave") as Label;
        enemiesLeft = document.rootVisualElement.Q("Enemies-Left") as Label;
        player = FindObjectOfType<Player>();
    }

    void FixedUpdate() {
        int currentHealth = player.GetComponent<HealthComponent>().getHealth();
        UpdateHealth(currentHealth);
    }

    public void UpdateHealth(int healthValue) {
        health.text = "Health: " + healthValue;
    }

    public void UpdatePoints(int pointsValue) {
        points.text = "Points: " + pointsValue;
    }

    public void AddPoints(int points) {
        totalPoints += points;
        UpdatePoints(totalPoints);
    }

    public void UpdateWave(int waveValue) {
        wave.text = "Wave: " + waveValue;
    }

    public void UpdateEnemiesLeft(int enemiesLeftValue) {
        enemiesLeft.text = "Enemies Left: " + enemiesLeftValue;
    }
}
