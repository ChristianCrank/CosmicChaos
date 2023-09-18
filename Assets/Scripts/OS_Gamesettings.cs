using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class OS_Gamesettings : MonoBehaviour
{


    public GameObject start_bttn;
    public GameObject quit_bttn;

    public GameObject settings_menu;

    public Slider soundFx_Slider;
    public Slider backFx_Slider;


    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.Instance != null)
        {
            soundFx_Slider.value = MainManager.Instance.soundFX;
            backFx_Slider.value = MainManager.Instance.backgroundVolume;
        }
        settings_menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switch_scenes()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void openSettings()
    {
        start_bttn.SetActive(false);
        quit_bttn.SetActive(false);
        settings_menu.SetActive(true);
    }

    public void closeSettings()
    {
        start_bttn.SetActive(true);
        settings_menu.SetActive(false);
    }
}
