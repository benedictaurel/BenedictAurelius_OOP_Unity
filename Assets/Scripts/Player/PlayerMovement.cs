using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 maxSpeed;
    [SerializeField] Vector2 timeToFullSpeed;
    [SerializeField] Vector2 timeToStop;
    [SerializeField] Vector2 stopClamp;

    Vector2 moveDirection;
    Vector2 moveVelocity;
    Vector2 moveFriction;
    Vector2 stopFriction;
    Vector2 ppos;
    Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        moveVelocity = 2 * maxSpeed/timeToFullSpeed;
        moveFriction = -2 * maxSpeed/(timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed/(timeToStop * timeToStop);
    }

    public void Move() {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))) {
        //     rb.velocity = Vector2.zero;
        //     return;
        // }

        moveVelocity -= GetFriction() * Time.deltaTime;

        moveVelocity.x = Mathf.Clamp(moveDirection.x * maxSpeed.x, -maxSpeed.x, maxSpeed.x);
        moveVelocity.y = Mathf.Clamp(moveDirection.y * maxSpeed.y, -maxSpeed.y, maxSpeed.y);

        if (moveVelocity.magnitude < stopClamp.magnitude) {
            rb.velocity = Vector2.zero;
        }

        rb.velocity = moveVelocity;
    }

    Vector2 GetFriction() {
        return new Vector2(
            moveVelocity.x != 0 ? moveFriction.x : stopFriction.x,
            moveVelocity.y != 0 ? moveFriction.y : stopFriction.y
        );
    }
    public void MoveBound() {
        ppos = Camera.main.WorldToViewportPoint(transform.position);
        ppos.x = Mathf.Clamp(ppos.x, 0.0f, 1.0f);
        ppos.y = Mathf.Clamp(ppos.y, 0.0f, 0.95f);
        Vector3 newPosition = Camera.main.ViewportToWorldPoint(ppos);
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }

    public bool IsMoving() {
        return rb.velocity.magnitude > 0;
    }
}
