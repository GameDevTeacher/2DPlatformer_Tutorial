using UnityEngine;
using UnityEngine.InputSystem;

namespace TestEnvironment
{
    public class InputManager : MonoBehaviour
    {
        public Vector2 MoveVector { get; private set; }
        public bool Jump { get; private set; }
        private bool _canJump;
        
        private bool _usingGamepad;
        private bool _usingDpad;
        
        private Keyboard _keyboard;
        private Gamepad _gamepad;
        private Vector2 _moveVector;
    
        public InputManager()
        {
            _moveVector = MoveVector;
        }
    
        private void Start()
        {
            _keyboard = Keyboard.current;
            _gamepad = Gamepad.current;
        }
    
        // Update is called once per frame
        private void Update()
        {
            
            if (_usingGamepad)
            {
                UpdateGamepadInput();  
            }
            else
            {
                UpdateKeyboardInput();
            }
        }
    
        private void UpdateKeyboardInput()
        {
            _moveVector.x = (_keyboard.dKey.isPressed ? 1 : 0) + (_keyboard.aKey.isPressed ? -1 : 0);
            _moveVector.y = (_keyboard.wKey.isPressed ? 1 : 0) + (_keyboard.sKey.isPressed ? -1 : 0);
            Jump = _keyboard.spaceKey.wasPressedThisFrame;
        }
    
        private void UpdateGamepadInput()
        {
            if (_usingDpad)
            {
                _moveVector.x = (_gamepad.dpad.right.isPressed ? 1 : 0) + (_gamepad.dpad.right.isPressed ? -1 : 0);
                _moveVector.y = (_gamepad.dpad.right.isPressed ? 1 : 0) + (_gamepad.dpad.right.isPressed ? -1 : 0); 
            }
            else
            {
                _moveVector = _gamepad.leftStick.ReadValue();
            }
    
            Jump = _gamepad.buttonSouth.wasPressedThisFrame;
        }
    }
}