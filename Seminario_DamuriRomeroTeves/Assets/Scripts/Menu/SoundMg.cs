using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMg : MonoBehaviour
{
    public Slider volumeSlider;
    public GameObject[] MusicSoundobjs;
    private float MusicVolume = 1f;
    private AudioSource[] _AudioSources;

    private void Start()
    {
        _AudioSources = new AudioSource[MusicSoundobjs.Length];
        for (int i = 0; i < MusicSoundobjs.Length; i++)
        {
            _AudioSources[i] = MusicSoundobjs[i].GetComponent<AudioSource>();
        }

        // Maneja el volumen
        MusicVolume = PlayerPrefs.GetFloat("volume");
        foreach (var audioSource in _AudioSources)
        {
            audioSource.volume = MusicVolume;
        }
        volumeSlider.value = MusicVolume;
    }

    private void Update()
    {
        // Actualiza el volumen de todos los AudioSource en el array
        foreach (var audioSource in _AudioSources)
        {
            audioSource.volume = MusicVolume;
        }
        PlayerPrefs.SetFloat("volume", MusicVolume);
    }

    public void VolumeUpdater(float volume)
    {
        MusicVolume = volume;
    }

    public void MusicReset()
    {
        PlayerPrefs.DeleteKey("volume");
        foreach (var audioSource in _AudioSources)
        {
            audioSource.volume = 1;
        }
        volumeSlider.value = 1;
    }
}
