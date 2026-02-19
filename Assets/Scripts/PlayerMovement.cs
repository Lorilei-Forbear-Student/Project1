using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 5f;
    private bool isFacingRight = true;
    private Vector2 movement;
    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        Flip();
    }
    private void FixedUpdate()
    {
        rb.velocity = movement * speed;
    }


    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
