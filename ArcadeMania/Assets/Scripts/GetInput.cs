using UnityEngine;
using UnityEngine.InputSystem;

public class GetInput : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            Application.Quit();
        }

    }



}
