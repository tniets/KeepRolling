using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector2 _offset;

    private void Update()
    {
        transform.position = new Vector3(_target.position.x + _offset.x, transform.position.y + _offset.y, transform.position.z);
    }
}
