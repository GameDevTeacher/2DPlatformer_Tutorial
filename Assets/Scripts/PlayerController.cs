using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 7f;
    
    public bool isPlayerGrounded;
    public LayerMask whatIsGround;

    private Keyboard _keyboard;
    private bool _jumpInput;
    private bool _jumpedInput;
    private bool _canJump;
    private float _horizontalInput;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _keyboard = Keyboard.current;
    }

    private void Update()
    {
        isPlayerGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.01f, whatIsGround);
        
        UpdateInput();
        
        if (_jumpInput && isPlayerGrounded)
        { _canJump = true; }

        if (_jumpedInput && _rigidbody2D.velocity.y > 0f)
        {
            _rigidbody2D.velocity = new Vector2(
                _rigidbody2D.velocity.x,
                _rigidbody2D.velocity.y * 0.2f);
        }
        
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_horizontalInput * moveSpeed, _rigidbody2D.velocity.y);
        if (_canJump)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeed);
            _canJump = false;
        }
    }
    private void UpdateInput()
    {
        _horizontalInput = (_keyboard.dKey.isPressed ? 1 : 0) + (_keyboard.aKey.isPressed ? -1 : 0);
        _jumpInput = _keyboard.spaceKey.wasPressedThisFrame;
        _jumpedInput = _keyboard.spaceKey.wasReleasedThisFrame;
        // Interact, Climb, Crouch, Sprint, Glide, Dash, 
    }
}