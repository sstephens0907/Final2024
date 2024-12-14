using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerScript : MonoBehaviour
{
    public float slowedSpeed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AliceScript alice = collision.GetComponent<AliceScript>();
            if (alice != null)
            {
                alice.SetSpeed(slowedSpeed);
            }
        }
    }
    
   private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AliceScript alice = collision.GetComponent<AliceScript>();
            if (alice != null)
            {
                alice.ResetSpeed();
            }
        }
    }
}
