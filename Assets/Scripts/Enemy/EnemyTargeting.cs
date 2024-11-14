using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeting : Enemy
{
    float moveSpeed = 2.0f;
    GameObject Player;
    Vector3 screenBounds;

    void Start()
    {
        setLevel(3);

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        float spawnX = Random.Range(0, 2) == 0 ? -screenBounds.x - 1 : screenBounds.x + 1;
        float spawnY = Random.Range(0, 2) == 0 ? -screenBounds.y - 1 : screenBounds.y + 1;

        transform.position = new Vector2(spawnX, spawnY);

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
