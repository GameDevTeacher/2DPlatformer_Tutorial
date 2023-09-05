using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public bool jumpPressed;
    public bool jumpReleased;
    public bool jumpHeld;
    
    public Vector2 moveVector;
    
    private void Update()
    {
        moveVector.x = (Keyboard.current.dKey.isPressed ? 1 : 0) + (Keyboard.current.aKey.isPressed ? -1 : 0);
        moveVector.y = (Keyboard.current.wKey.isPressed ? 1 : 0) + (Keyboard.current.sKey.isPressed ? -1 : 0);
        
        jumpPressed = Keyboard.current.spaceKey.wasPressedThisFrame;
        jumpReleased = Keyboard.current.spaceKey.wasReleasedThisFrame;
        jumpHeld = Keyboard.current.spaceKey.isPressed;
    }
}