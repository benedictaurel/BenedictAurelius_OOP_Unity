using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForward : Enemy
{
    float moveSpeed = 2.0f;
    bool moveUp = true;
    Vector3 screenBounds;

    void Start()
    {
        setLevel(2);

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        float spawnX = Random.Range(-screenBounds.x, screenBounds.x);
        float spawnY = Random.Range(0, 2) == 0 ? -screenBounds.y - 1 : screenBounds.y + 1;

        transform.position = new Vector2(spawnX, spawnY);

        moveUp = spawnY < 0;
    }

    void Update()
    {
        float y = moveUp ? moveSpeed * Time.deltaTime : -moveSpeed * Time.deltaTime;
        transform.Translate(0, y, 0);

        if (transform.position.y < -screenBounds.y - 1)
        {
            moveUp = true;
        }

        if (transform.position.y > screenBounds.y + 1)
        {
            moveUp = false;
        }
    }
}
