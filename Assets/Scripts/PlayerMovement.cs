using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // TODO: STEP 1: Movement & Jump
    
    // Step 1
    public float moveSpeed = 5f;
    public float jumpSpeed = 7f;
    private float _horizontalInput;
    private Rigidbody2D _rigidbody2D;
    //Step 3
    public bool isPlayerGrounded;
    public LayerMask whatIsGround;
    //Step 4 - make a simple level with the 2D Static Sprites

    private void Start()
    {
        // Step 1
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        // Step 1
        _horizontalInput = (Keyboard.current.dKey.isPressed ? 1 : 0) + (Keyboard.current.aKey.isPressed ? -1 : 0);
        //Step 2
        
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeed);
        }
        
        //Step 3
        /*
         * //isPlayerGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.55f, whatIsGround);
         *  if (Keyboard.current.spaceKey.wasPressedThisFrame && isPlayerGrounded)
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeed);
            }
         */
    }

    private void FixedUpdate()
    {
        // Step 1
        _rigidbody2D.velocity = new Vector2(_horizontalInput * moveSpeed, _rigidbody2D.velocity.y);
    }
}