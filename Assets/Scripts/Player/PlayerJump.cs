using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _force;

    private Rigidbody2D _rigidbody2D;

    private bool IsGrounded => _rigidbody2D.velocity.y == 0;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
            Jump();
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _force);
    }
}
