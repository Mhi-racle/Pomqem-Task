using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class musicParticleEffects : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
         animator = GetComponent<Animator>();
    }
    
  
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "Particle System")
        {
           animator.SetBool("isDancing", true);
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Particle System")
        {
            Debug.Log("Stopped");
            animator.SetBool("isDancing", false);
        }
    }

  
    private void Update()
    {
        
    }
}
