using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public PlayerMovement playerMovement;
    public Animator animator;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    void Start(){
        playerMovement = GetComponent<PlayerMovement>();
        animator = GameObject.Find("EngineEffect").GetComponent<Animator>();
    }

    void FixedUpdate() {
        playerMovement.Move();
    }

    void LateUpdate() {
        animator.SetBool("IsMoving", playerMovement.IsMoving());
    }
}