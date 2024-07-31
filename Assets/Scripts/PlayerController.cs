using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D), typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")] [Space(10)]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpSpeed = 8f;
    
    private float _maxVerticalSpeed = -16;
    
    private Vector2 _moveVector;
    private bool _jump, _canJump;

    [Header("Animations")] [Space(10)]
    private static readonly int WalkAnimation = Animator.StringToHash("Character_Walk");
    private static readonly int IdleAnimation = Animator.StringToHash("Character_Idle");
    private static readonly int JumpAnimation = Animator.StringToHash("Character_Jump");
    private static readonly int FallAnimation = Animator.StringToHash("Character_Fall");
  
    
    private Keyboard _keyboard;
    [SerializeField] private LayerMask whatIsGround;

    [Header("Physics")]
    [SerializeField] private float gravityScale = 1f;
    [SerializeField] private Vector2 colliderSize = new Vector2(0.35f, 0.58f);
    [SerializeField] private Vector2 colliderOffset = new Vector2(-0.03f, 0.29f);
    
    [Header("Components")]
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private CapsuleCollider2D _capsuleCollider2D;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();

        _rigidbody2D.gravityScale = gravityScale;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        
        _capsuleCollider2D.size = colliderSize;
        _capsuleCollider2D.offset = colliderOffset;
        _keyboard = Keyboard.current;
    }


    private void Update()
    {
        UpdateInput();
        UpdateAnimations();
        UpdateMovement();
    }

    private void FixedUpdate()
    {
        FixedUpdateMovement();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag($"Death"))
        {
            RestartScene();
        }
    }

    private void UpdateMovement()
    {
        if (IsPlayerGrounded() && _jump)
        {
            _canJump = true;
        }
    }

    private void FixedUpdateMovement()
    {
        
        _rigidbody2D.linearVelocity = new Vector2(_moveVector.x * moveSpeed, _rigidbody2D.linearVelocity.y);
        //if (!IsPlayerGrounded()) return;
        if (!_canJump) return;
        _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.x, jumpSpeed);
        _canJump = false;
    }


    private void UpdateInput()
    {
        _moveVector.x = (_keyboard.dKey.isPressed ? 1 : 0) + (_keyboard.aKey.isPressed ? -1 : 0);
        _moveVector.y = (_keyboard.wKey.isPressed ? 1 : 0) + (_keyboard.sKey.isPressed ? -1 : 0);
        _jump = _keyboard.spaceKey.wasPressedThisFrame;
    }

    private void UpdateAnimations()
    {
        _spriteRenderer.flipX = _moveVector.x < 0;
        if (IsPlayerGrounded())
        {
            _animator.Play(_moveVector.x != 0f ? WalkAnimation : IdleAnimation);
        }
        else
        {
            _animator.Play(_rigidbody2D.linearVelocity.y < 0 ? FallAnimation : JumpAnimation);
        }
    }

    
    private bool IsPlayerGrounded()
    {
        var position = transform.position;
            
        Debug.DrawRay(position, Vector2.down, new Color(0.55f, 0f, 1f));
        var hit = Physics2D.Raycast(position, Vector2.down, 0.01f, whatIsGround);
        return hit.collider != null;
    }
    
    
    
    private static void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}