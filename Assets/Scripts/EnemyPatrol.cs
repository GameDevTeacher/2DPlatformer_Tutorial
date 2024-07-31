using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 4f;
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;

    private Vector2 _position;
    private Vector2 _scale;
    
    private Transform _fallCheckPoint;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _fallCheckPoint = GetComponentInChildren<Transform>();
    }

    private void Update()
    {
        _position = transform.position;
        _scale = transform.localScale;
    }

    private void FixedUpdate()
    { 
        _rigidbody2D.linearVelocity = new Vector2(moveSpeed * _scale.x, _rigidbody2D.linearVelocity.y); 
    }

    private void LateUpdate()
    {
        if (DetectedWallOrFall())
        {
            _scale = new Vector3(-_scale.x, 1f, 1f);
        }

        if (DetectedPlayer())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // Injure Player
        }
    }
    
    private bool DetectedWallOrFall()
    {
        // Origin, Direction, Distance, PhysicsLayer
        return Physics2D.Raycast(new Vector2(_position.x, _position.y + 0.2f), Vector2.left * _scale, 1f, whatIsGround) || !Physics2D.Raycast(_fallCheckPoint.position, Vector2.down, 1.4f, whatIsGround);
    }

    private bool DetectedPlayer()
    {
        return
            Physics2D.OverlapBox(new Vector2((_position.x+0.2f)* 
            _scale.x, _position.y + 0.3f)
            ,_scale, 0f, whatIsPlayer)
            || 
            Physics2D.OverlapBox(new Vector2(_position.x, _position.y + 0.3f)
            ,_scale, 0f, whatIsPlayer);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a yellow cube at the transform position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector2((_position.x+0.2f)* 
                                        _scale.x, _position.y + 0.3f), _scale);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(_position.x, _position.y + 0.3f), _scale);
    }
}