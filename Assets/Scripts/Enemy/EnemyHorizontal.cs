using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontal : Enemy
{
    float moveSpeed = 2.0f;
    bool moveRight = true;
    Vector3 screenBounds;

    void Start()
    {
        SetLevel(1);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        float spawnX = Random.Range(0, 2) == 0 ? -screenBounds.x - 1 : screenBounds.x + 1;
        float spawnY = Random.Range(-screenBounds.y + 1, screenBounds.y - 1);

        transform.position = new Vector2(spawnX, spawnY);

        moveRight = spawnX < 0;
    }

    void Update()
    {
        float x = moveRight ? moveSpeed * Time.deltaTime : -moveSpeed * Time.deltaTime;
        transform.Translate(x, 0, 0);

        if (transform.position.x < -screenBounds.x - 1)
        {
            moveRight = true;
        }

        if (transform.position.x > screenBounds.x + 1)
        {
            moveRight = false;
        }
    }
}
