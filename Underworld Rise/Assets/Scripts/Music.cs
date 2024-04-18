using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public AudioSource musicSource;
    public Button muteButton;
    public Slider volumeSlider;
    private bool isMuted = false;
    public AudioClip inicio;
    public AudioClip principal;

    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Pantalla de Inicio")
        {
            musicSource.clip = inicio;
        }
        else if (sceneName == "Pantalla Principal")
        {
            musicSource.clip = principal;
        }

        musicSource.Play();
        muteButton.onClick.AddListener(ToggleMute);
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        volumeSlider.maxValue = 1f;
        volumeSlider.value = musicSource.volume;
    }

    void ToggleMute()
    {
        isMuted = !isMuted;
        musicSource.volume = isMuted ? 0 : 1;
        volumeSlider.value = musicSource.volume;
    }
    void ChangeVolume(float volume)
    {
        musicSource.volume = volume;
    }
}
