using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputManager : MonoBehaviour
{
   
    [Header("Movement")]
    [HideInInspector] public Vector2 moveVector;

    [Header("Jump")]
    [HideInInspector] public bool canJump;
    [HideInInspector] public bool jumpPressed, jumpReleased, jumpHeld;

    [Header("Interact")]
    [HideInInspector] public bool canInteract;
    [HideInInspector] public bool interactPressed, interactReleased, interactHeld;

    private bool _usingGamepad;
    private bool _usingDpad;
        
    private Keyboard _keyboard;
    private Gamepad _gamepad;

    private void Start()
    {
        _keyboard = Keyboard.current;
        _gamepad = Gamepad.current;
    }

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
        moveVector.x = (_keyboard.dKey.isPressed ? 1 : 0) + (_keyboard.aKey.isPressed ? -1 : 0);
        moveVector.y = (_keyboard.wKey.isPressed ? 1 : 0) + (_keyboard.sKey.isPressed ? -1 : 0);
        
        jumpPressed = _keyboard.spaceKey.wasPressedThisFrame;
        jumpReleased = _keyboard.spaceKey.wasReleasedThisFrame;
        jumpHeld = _keyboard.spaceKey.isPressed;
        
        jumpPressed = _keyboard.spaceKey.wasPressedThisFrame;
        jumpReleased = _keyboard.spaceKey.wasReleasedThisFrame;
        jumpHeld = _keyboard.spaceKey.isPressed;
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
        
        jumpPressed = _gamepad.buttonSouth.wasPressedThisFrame;
        jumpReleased = _gamepad.buttonSouth.wasReleasedThisFrame;
        jumpHeld = _gamepad.buttonSouth.isPressed;
    }

  
}