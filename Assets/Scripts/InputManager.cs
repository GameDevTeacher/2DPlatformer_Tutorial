using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
   
    [Header("Movement")]
// This variable is used to hold the Input value from WASD, Dpad or Left Stick
    [HideInInspector] public Vector2 moveVector;

    [Header("Jump")]
    
    [HideInInspector] public bool canJump;
// These variables are used to hold Input values from Spacebar or South button
    [HideInInspector] public bool jumpPressed, jumpReleased, jumpHeld;

    [Header("Interact")]
    [HideInInspector] public bool canInteract;
// These variables are used to hold Input Values from the F key or East Button
    [HideInInspector] public bool interactPressed, interactReleased, interactHeld;

// These variables are used to determine input source.
    private bool _usingGamepad, _usingDpad;

// These variables are used to hold the current Input source
    private Keyboard _keyboard;
    private Gamepad _gamepad;

    private void Start()
    {
    //Assign Input Sources to Variables
        _keyboard = Keyboard.current;
        _gamepad = Gamepad.current;
    }

    private void Update()
    {
    // Check whether we are using Gamepad or Keyboard
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
        moveVector.x = (_keyboard.dKey.isPressed ? 1 : 0) + (_keyboard.aKey.isPressed ? -1 : 0);
        moveVector.y = (_keyboard.wKey.isPressed ? 1 : 0) + (_keyboard.sKey.isPressed ? -1 : 0);
        
        jumpPressed = _keyboard.spaceKey.wasPressedThisFrame;
        jumpReleased = _keyboard.spaceKey.wasReleasedThisFrame;
        jumpHeld = _keyboard.spaceKey.isPressed;
        
        interactPressed = _keyboard.fKey.wasPressedThisFrame;
        interactReleased = _keyboard.fKey.wasReleasedThisFrame;
        interactHeld = _keyboard.fKey.isPressed;
    }
    
    private void UpdateGamepadInput()
    {
        if (_usingDpad)
        {
            moveVector.x = (_gamepad.dpad.right.isPressed ? 1 : 0) + (_gamepad.dpad.right.isPressed ? -1 : 0);
            moveVector.y = (_gamepad.dpad.right.isPressed ? 1 : 0) + (_gamepad.dpad.right.isPressed ? -1 : 0); 
        }
        else
        {
            moveVector = _gamepad.leftStick.ReadValue();
        }
    
        jumpPressed = _gamepad.buttonSouth.wasPressedThisFrame;
        jumpReleased = _gamepad.buttonSouth.wasReleasedThisFrame;
        jumpHeld = _gamepad.buttonSouth.isPressed;
        
        interactPressed = _gamepad.buttonEast.wasPressedThisFrame;
        interactReleased = _gamepad.buttonEast.wasReleasedThisFrame;
        interactHeld = _gamepad.buttonEast.isPressed;
    }

  
}