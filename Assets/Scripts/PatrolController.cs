using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PatrolController : MonoBehaviour
{

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    float speed;

    [SerializeField]
    bool isFacingRight = true;

    Rigidbody2D _rb;

    void Awake()
    {
        
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        RaycastHit2D raycastHit2 = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.30F);
        if (!raycastHit2)
        {
            FlipX();
        }

        _rb.velocity = new Vector2(speed * Time.fixedDeltaTime, _rb.velocity.y);
    }

    void FlipX()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0F, 180.0F, 0.0F);
        speed *= -1;

    }
}
