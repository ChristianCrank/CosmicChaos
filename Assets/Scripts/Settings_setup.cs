using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Settings_setup : MonoBehaviour
{
    public GameObject inGameMenu;

    public Slider soundFx_Slider;
    public Slider backFx_Slider;

    public AudioSource soundFx_Source;
    public AudioSource backFx_Source;


    float sfx_value;
    float backsfx_value;
   
    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.Instance != null)
        {
            sfx_value = MainManager.Instance.soundFX;
            backsfx_value = MainManager.Instance.backgroundVolume;
        }

        inGameMenu.SetActive(false);
        
    }

    public void openMenu()
    {
        inGameMenu.SetActive(true);
    }

    public void closeMenu()
    {
        inGameMenu.SetActive(false);
    }

    public void quitToMain()
    {
        SceneManager.LoadScene("OpeningScene");
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
