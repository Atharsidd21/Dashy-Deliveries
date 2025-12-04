using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float Movespeed = 0.05f;
   [SerializeField] float Rotationspeed = 02f;
    [SerializeField]  private ParticleSystem effectsPrefab;
    bool hasPackage; 

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
    /*This Part can be done by creating a seprate script 
     but I am doing this here for my comfort,
    but making a seperate script is recommended.*/
     void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PickUp Item")) //Using Tag to identify PickUp items
        {

            Debug.Log("Utha lia re baba");
            hasPackage = true;

            //Playing Particle Effect on Pickup
            ParticleSystem ps = Instantiate(effectsPrefab, collision.transform.position, Quaternion.identity);
            ps.Play();
            Debug.Log("Particle Effect Played");
            //Destroying the PickUp item on collision
            Destroy(collision.gameObject);
            //Destroying particle effect after Pickup 
            Destroy(ps.gameObject, ps.main.duration + ps.main.startLifetime.constantMax);
        }

        if (collision.CompareTag("Customer")&& hasPackage) //Using Tag to identify Finish Line
        {
            Debug.Log("Item Delivered");
            hasPackage = false;
        }
    }



    /*Optional Just for Practice
    void OnTriggerExit2D(Collider2D collision) 
    {
        Debug.Log("Trigger Exited");
    }*/
     
    

}
