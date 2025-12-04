using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float Movespeed = 0.05f;
   [SerializeField] float Rotationspeed = 02f;
   
 

    void Update()
    {
        /*/Method1: Using the old Input System
         float move = Input.GetAxis("Vertical") *  Movespeed;
         float steer = Input.GetAxis("Horizontal")  * Rotationspeed;

         transform.Rotate(0, 0f, steer);
         transform.Translate(0, move , 0);/*/

        //Method2: Using the new Input System//
        float move = 0f;
        float steer= 0f;
        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
            //Debug.Log("Moving Forward");
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
            //Debug.Log("Moving Backward");
        }
        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
            //Debug.Log("Turning Left");
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
            //Debug.Log("Turning Right");
        }
        //calculate movement and steering amounts
        float moveAmount = move * Movespeed * Time.deltaTime;
        float steerAmount = steer * Rotationspeed * Time.deltaTime;
        transform.Rotate(0, 0f, steerAmount);
        transform.Translate(0, moveAmount, 0);

    }
    

}
