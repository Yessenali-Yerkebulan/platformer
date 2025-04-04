using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private Vector2 _direction;
    private Rigidbody2D _rigidbody2D;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;

    [SerializeField] private LayerCheck _groundCheck;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 dir)
    {
        _direction = dir;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_direction.x * _speed, _rigidbody2D.velocity.y);

        var isJumping = _direction.y > 0;
        if (isJumping)
        {
            if (IsGrounded())
            {
                _rigidbody2D.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);

            }
        } else if (_rigidbody2D.velocity.y > 0)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        return _groundCheck.IsTouchingLayer;
    }

    public void SaySomething()
    {
        Debug.Log("Say Something");
    }
}
