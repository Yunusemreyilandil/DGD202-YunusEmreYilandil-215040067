using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  
    //Used to load the music in the game 
    private int _muteButtonIndex
    {
        get => PlayerPrefs.GetInt("MuteButtonState", 0);
        set => PlayerPrefs.SetInt("MuteButtonState", value);
    }

    void Start()
    {
        LoadData();  //Used to run when the game starts
        
        
    }
    private void LoadData() //It is used to turn the sound on and off according to the mute button.
    {
        if (_muteButtonIndex == 1) 
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }
    

   
}
