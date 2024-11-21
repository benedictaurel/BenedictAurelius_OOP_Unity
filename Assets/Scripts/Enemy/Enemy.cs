using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int level;
    public UnityEvent enemyKilledEvent;

    private void Start() {
        enemyKilledEvent ??= new UnityEvent();
    }

    public int GetLevel(){
        return level;
    }

    public void SetLevel(int level){
        this.level = level;
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    private void OnDestroy() {
        enemyKilledEvent.Invoke();
    }
}
