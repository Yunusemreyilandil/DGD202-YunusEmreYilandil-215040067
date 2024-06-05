using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button muteButton;
    [SerializeField] private Sprite muteButtonEnabledSprite, muteButtonDisabledSprite;

    private Image _muteButtonImage;

    private int _muteButtonIndex
    {
        get => PlayerPrefs.GetInt("MuteButtonState", 0);
        set => PlayerPrefs.SetInt("MuteButtonState", value);
    }
    private void Start()
    {
        
        _muteButtonImage = muteButton.GetComponent<Image>();
        LoadData();
    }
    private void LoadData()
    {
        if (_muteButtonIndex == 1)
        {
            AudioListener.volume = 0;
            _muteButtonImage.sprite = muteButtonDisabledSprite;
        }
        else
        {
            AudioListener.volume = 1;
            _muteButtonImage.sprite = muteButtonEnabledSprite;
        }
    }
    public void MuteButtonClick()
    {
        if (_muteButtonIndex == 1)
        {
            AudioListener.volume = 1;
            _muteButtonImage.sprite = muteButtonEnabledSprite;
            _muteButtonIndex = 0;
        }
        else
        {
            AudioListener.volume = 0;
            _muteButtonImage.sprite = muteButtonDisabledSprite;
            _muteButtonIndex = 1;
        }
        
    }
    public void QuitButtonClick()
    {
        Application.Quit(); 
        Debug.Log("Oyuncu Gitti");


    }

    public void PlayButtonClick()
    {
        SceneManager.LoadScene(1);
        
    }
   
}
