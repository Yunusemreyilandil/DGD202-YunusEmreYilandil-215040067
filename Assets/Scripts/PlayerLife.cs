using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    
    [SerializeField] private GameObject failpanel;
     public AudioSource deathSound;
   private Rigidbody2D rb; 
   private Animator anim; 

   private  Animation anim1;
   public void Start() //calls components
   {
    anim = GetComponent<Animator>();  
    rb = GetComponent<Rigidbody2D>();
   }

   public void OnCollisionEnter2D(Collision2D collision) //It runs when an object with a trap tag is touched.
   {
    if (collision.gameObject.CompareTag("Trap"))  
    {
        Die();

    }

   }
   private void Die()
   {
    rb.bodyType = RigidbodyType2D.Static;
    anim.SetTrigger("death"); //Runs death animation
    deathSound.Play();  //activates death effect
    failpanel.SetActive(true); //Opens the fail panel
    
   }

    public void RespawnPlayer() // Used to reload the scene after death
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
   


}

