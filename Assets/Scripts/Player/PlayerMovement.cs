using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _direction = Vector2.right;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidBody2D;

    private void Awake()
    {
        _direction.Normalize();
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidBody2D.velocity = new Vector2(_speed, _rigidBody2D.velocity.y);
    }
}
