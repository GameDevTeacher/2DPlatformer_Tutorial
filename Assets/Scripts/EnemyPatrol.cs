using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 4f;
    public LayerMask whatIsGround;
    private Rigidbody2D _rigidbody2D;
    
    private void Start()
    { _rigidbody2D = GetComponent<Rigidbody2D>(); }
    
    private void FixedUpdate()
    { _rigidbody2D.velocity = new Vector2(
        moveSpeed * transform.localScale.x, 
        _rigidbody2D.velocity.y); 
    }

    private void LateUpdate()
    {
        if (DetectedWallOrFall())
        {
            transform.localScale = new Vector3(
                -transform.localScale.x, 1f, 1f);
        }
        
        if (DetectedPlayer())
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().name);
            //Application.Quit();
        }

    }
    
    private bool DetectedWallOrFall()
    {
        // Origin, Direction, Distance, PhysicsLayer
        return Physics2D.Raycast(
            new Vector2(transform.position.x, 
                transform.position.y + 0.2f),
            Vector2.left * transform.localScale , 
            0.6f, whatIsGround);
    }
}