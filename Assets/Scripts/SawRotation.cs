using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class SawRotation : MonoBehaviour
{
[SerializeField] private float speed = 0.75f;  

public void Update() //speed and rotation settings of the saw
{
    transform.Rotate(0,0,360*speed* Time.deltaTime);
}

}
