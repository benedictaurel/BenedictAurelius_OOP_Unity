using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int level = 0;

    public int getLevel(){
        return level;
    }

    public void setLevel(int level){
        this.level = level;
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    void Levels() {
        // level
    }
}
