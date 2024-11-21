using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
    float moveSpeed = 0.5f;
    bool moveRight = true;
    Vector3 screenBounds;

    void Start()
    {
        SetLevel(3);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        float spawnX = Random.Range(0, 2) == 0 ? -screenBounds.x - 1 : screenBounds.x + 1;

        transform.position = new Vector2(spawnX, transform.position.y);

        moveRight = spawnX < 0;
    }

    void Update()
    {
        float x = moveRight ? moveSpeed * Time.deltaTime : -moveSpeed * Time.deltaTime;
        transform.Translate(x, 0, 0);

        if (transform.position.x < -screenBounds.x)
        {
            moveRight = true;
        }

        if (transform.position.x > screenBounds.x)
        {
            moveRight = false;
        }

        
    }
}
