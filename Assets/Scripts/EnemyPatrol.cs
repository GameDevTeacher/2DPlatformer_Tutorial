using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 4f;
    private Rigidbody2D _rigidbody2D;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(
            moveSpeed, 0f);
    }
}