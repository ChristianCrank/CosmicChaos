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
       
    }

    private void Update()
    {
       MainManager.Instance.soundFX = sfx.value;
        MainManager.Instance.backgroundVolume = backsfx.value;
    }

}
