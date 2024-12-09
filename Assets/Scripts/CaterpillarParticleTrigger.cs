using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaterpillarParticleTrigger : MonoBehaviour
{
    public Transform aliceTransform; 
    public ParticleSystem particleSystem;
    public float triggerDistance;
    public float pushbackForce;
    public float pushbackTrigger;

    private Rigidbody2D aliceRb;

    void Start()
    {
        aliceRb = aliceTransform.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, aliceTransform.position) <= triggerDistance)
        {
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play();
            }
        }
        else
        {
            if (particleSystem.isPlaying)
            {
                particleSystem.Stop();
            }
        }

        if (Vector3.Distance(transform.position, aliceTransform.position) <= pushbackTrigger)
        {
            ApplyPushback();
        }
    }

     void ApplyPushback()
     {
         Vector2 pushDirection = (aliceTransform.position - transform.position).normalized;
         aliceRb.AddForce(pushDirection * pushbackForce, ForceMode2D.Impulse);
    }
}
