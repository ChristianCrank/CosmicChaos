using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public Slider sfx;
    public Slider backsfx;

    public GameObject start_bttn;

    public GameObject settings_menu;

    public static MainManager Instance;

    [SerializeField] public float backgroundVolume;
    [SerializeField] public float soundFX;



    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        settings_menu.SetActive(false);
    }

    private void Update()
    {
       MainManager.Instance.soundFX = sfx.value;
        MainManager.Instance.backgroundVolume = backsfx.value;
    }

    public void switch_scenes()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void openSettings()
    {
        start_bttn.SetActive(false);
        settings_menu.SetActive(true);
    }

    public void closeSettings()
    {
        start_bttn.SetActive(true);
        settings_menu.SetActive(false);
    }

}
