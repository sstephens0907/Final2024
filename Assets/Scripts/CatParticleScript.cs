using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatParticleTrigger : MonoBehaviour
{
    public Transform aliceTransform; 
    public ParticleSystem particleSystem;
    public float triggerDistance;

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
        
    }
    
}

