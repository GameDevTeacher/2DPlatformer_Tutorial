using UnityEngine;

namespace TestEnvironment
{
    public class PlayerMovement : MonoBehaviour
    {

        private float _moveSpeed;
    
        private InputManager _input;
        private Rigidbody2D _rigidbody2D;
        // Start is called before the first frame update
        private void Start()
        {
            _input = GetComponent<InputManager>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        private void FixedUpdate()
        {
            _rigidbody2D.velocity = new Vector2(_input.MoveVector.x * _moveSpeed, 0f);
        }
    }
 
}