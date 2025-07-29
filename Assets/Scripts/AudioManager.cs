using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  
  
    private int _muteButtonIndex
    {
        get => PlayerPrefs.GetInt("MuteButtonState", 0);
        set => PlayerPrefs.SetInt("MuteButtonState", value);
    }

    void Start()
    {
        LoadData();  
        
        
    }
    private void LoadData() 
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
