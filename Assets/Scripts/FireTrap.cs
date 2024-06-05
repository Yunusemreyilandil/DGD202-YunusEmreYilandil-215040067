using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    
    [Header ("FireTrap Timers ")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    private Animator anim; 
    private SpriteRenderer spriteRend; 

    private bool triggered; // when the trap gets triggered 
    private bool active; // when the trap is active and can kill the player 

    private void Awake() // Calls the animator and sprite renderer components
    {
        anim = GetComponent<Animator>();
        spriteRend= GetComponent<SpriteRenderer>(); 
        
    }

    private void OntriggerEnter2D(Collider2D collision)  //When collider is entered, the player life code will run and the player will die.
    {
        if (collision.tag   == "Player")
        {
            if(!triggered)
            
                StartCoroutine(ActivateFiretrap());
            
            if(active)  
            {
                collision.GetComponent<PlayerLife> ().enabled = false;  
            }
        }
        
    }
    private IEnumerator ActivateFiretrap()  ////Wait for delay, activate trap, turn on anim
    {
        triggered = true;
        
        
        yield return new WaitForSeconds(activationDelay);
        active = true;
        yield return new WaitForSeconds (activeTime);
        active = false;
        triggered = false;


    }


}
