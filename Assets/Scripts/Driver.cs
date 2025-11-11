using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
   [SerializeField] float Rotationspeed = 02f;
    [SerializeField] float Movespeed = 0.05f;

    void Update()
    {
        if(Keyboard.current.wKey.isPressed)
        {
            Debug.Log("Moving Forward");
        }
        else if(Keyboard.current.sKey.isPressed)
        {
            Debug.Log("Moving Backward");
        }
         if(Keyboard.current.aKey.isPressed)
        {
            Debug.Log("Turning Left");
        }
        else if(Keyboard.current.dKey.isPressed)
        {
            Debug.Log("Turning Right");
        }
            transform.Rotate(0, 0f, Rotationspeed);
        transform.Translate(0, Movespeed, 0);

    }
}
