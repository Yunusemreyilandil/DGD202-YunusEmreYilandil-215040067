using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour
{
 
 
 //Enable winCanvas when player collider interacts with cup's collider
 
 public Canvas kazanmaCanvas;
 public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  //Makes the layer of the cup player and runs it when the character touches the cup.
        {
            
            kazanmaCanvas.gameObject.SetActive(true);
        }
    }
}

