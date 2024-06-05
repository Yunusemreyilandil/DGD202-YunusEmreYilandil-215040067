using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public AudioSource cherrySound;
    [SerializeField] private TextMeshProUGUI cherriesText;
    private int cherries = 0 ;
   public void OnTriggerEnter2D(Collider2D collision)  //interacting with cherries
   {
    if(collision.gameObject.CompareTag("Cherry"))
    {
        Destroy(collision.gameObject);
        cherrySound.Play();   //sound effect works when cherries are destroyed
        cherries++;
        Debug.Log("Cherries: "+ cherries); //As the cherries are collected, the number of cherries increases in the text.
        cherriesText.text = "Cherries: "+ cherries;
        
        


    }
   }
}
