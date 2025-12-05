using UnityEngine;
using UnityEngine.InputSystem;

public class PickUp : MonoBehaviour
{
   
    [SerializeField]  ParticleSystem effectsPrefab;
    [SerializeField] float DelayTime = 0.5f;
    bool hasPackage;

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PickUp Item")&& !hasPackage ) //Using Tag to identify PickUp items
        {

            Debug.Log("Utha lia re baba");
            hasPackage = true;

            //Playing Particle Effect on Pickup
            //Destroying the PickUp item on collision
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, DelayTime);
            
           /*/ ParticleSystem ps = Instantiate(effectsPrefab, collision.transform.position, Quaternion.identity);
            ps.Play();

            Debug.Log("Particle Effect Played");
            //Destroying particle effect after Pickup 
            Destroy(ps.gameObject, ps.main.duration + ps.main.startLifetime.constantMax);*/


        }

        if (collision.CompareTag("Customer") && hasPackage) //Using Tag to identify Finish Line
        {
            Debug.Log("Item Delivered");
            hasPackage = false;
            GetComponent<ParticleSystem>().Stop();
        }

    }



    /*Optional Just for Practice
    void OnTriggerExit2D(Collider2D collision) 
    {
        Debug.Log("Trigger Exited");
    }*/



} 