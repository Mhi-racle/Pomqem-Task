using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using StarterAssets;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnimator;
    public GameObject guitar_back;
    public GameObject guitar_front;

    public ParticleSystem soundEffects;

    public Transform rightHand;
    bool hasGuitar = false;
    bool isPlaying = false;
   private StarterAssetsInputs playerControls;

    public GameObject[] crowdAnimators; 
    // Start is called before the first frame update
    void Start()
    {
        playerControls = new StarterAssetsInputs();
        playerAnimator = GetComponent<Animator>();

        crowdAnimators = GameObject.FindGameObjectsWithTag("crowd");
    }

    private void Update()
    {
        if (playerAnimator.GetFloat("Speed") > 0.3)
        {
            soundEffects.gameObject.SetActive(false);
            soundEffects.Stop();

            foreach (GameObject NPC in crowdAnimators)
            {
                NPC.GetComponent<Animator>().SetBool("isDancing", false);
            }
        }
    }
    private void OnDrawGuitar()
    {
        Debug.Log("Draw");
        if (!hasGuitar)
        {
            ArmGuitar();
            hasGuitar=true;
        }
        else
        {
            DisarmGuitar(); 
            hasGuitar = false;  
        }
      
    }
   
    void OnPlayGuitar() {
        if (!hasGuitar) {
            ArmGuitar();
            hasGuitar=true;
            
        }
        else 
        {
            playerAnimator.SetTrigger("Play");
            soundEffects.gameObject.SetActive(true);
            soundEffects.Play();
        }
       
    
    }

    public void StopPlaying()
    {
        playerAnimator.SetTrigger("StopPlaying");
    }
    public void PullGuitar()
    {
        playerAnimator.SetTrigger("arm");
    }
    void ArmGuitar()
    {

        guitar_back.SetActive(false);
        guitar_front.SetActive(true);
    }
    

    void DisarmGuitar()
    {
       
        guitar_back.SetActive(true);
        guitar_front.SetActive(false);
    }
}
