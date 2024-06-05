using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
   [SerializeField] private GameObject[] waypoints; 
   private int currentWaypointIndex = 0; 

   [SerializeField] private float speed = 2f; //speed value between way points

    
    private void Update() //transform operation between way points
    {
        if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++; 
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
            
        }
        transform.position = Vector2.MoveTowards(transform.position,waypoints[currentWaypointIndex].transform.position,Time.deltaTime*speed);
    }
}
