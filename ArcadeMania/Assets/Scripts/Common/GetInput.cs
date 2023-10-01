using UnityEngine;
using UnityEngine.InputSystem;

public class GetInput : MonoBehaviour
{
    public float directionX;
    public bool isJumping = false;
    void Update()
    {

        // if d key or right arrow is pressed, directionX = 1

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            directionX = 1;
        }
        else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            directionX = -1;
        }
        else
        {
            directionX = 0;
        }

        if (Keyboard.current.spaceKey.isPressed)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }

        if (Keyboard.current.escapeKey.isPressed)
        {
            Application.Quit();
        }
    }
}
