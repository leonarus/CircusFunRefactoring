using UnityEngine;

public class KeyboardInputHandler : IInputHandler
{
    public bool CanJump()
    {
        return Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
    }
}