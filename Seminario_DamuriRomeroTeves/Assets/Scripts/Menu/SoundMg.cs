using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMg : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource[] buttonSoundSources; // Array de AudioSource para sonidos de botones
    public AudioSource[] EffectsSources; // Array de AudioSource para sonidos de botones
    public Slider masterVolumeSlider;
    public Slider musicSlider;
    public Slider buttonSoundSlider;
    public Slider EffectsSoundSlider;


    void Start()
    {
        // Configurar los sliders
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        buttonSoundSlider.value = PlayerPrefs.GetFloat("ButtonSoundVolume", 1f);
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        EffectsSoundSlider.value = PlayerPrefs.GetFloat("EffectsVolume", 1f);

        // Configurar los volúmenes iniciales
        SetMusicVolume(musicSlider.value);
        SetButtonSoundVolume(buttonSoundSlider.value);
        SetMasterVolume(masterVolumeSlider.value);
        SetButtonSoundVolumeEffectSounds(EffectsSoundSlider.value);
    }

    // Función para cambiar el volumen de la música
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    // Función para cambiar el volumen de los sonidos de botones
    public void SetButtonSoundVolume(float volume)
    {
        foreach (AudioSource buttonSoundSource in buttonSoundSources)
        {
            buttonSoundSource.volume = volume;
        }
        PlayerPrefs.SetFloat("ButtonSoundVolume", volume);
    }
    public void SetButtonSoundVolumeEffectSounds(float volume)
    {
        foreach (AudioSource buttonSoundSource in EffectsSources)
        {
            buttonSoundSource.volume = volume;
        }
        PlayerPrefs.SetFloat("EffectsVolume", volume);
    }
    // Función para cambiar el volumen maestro (tanto música como sonidos de botones)
    public void SetMasterVolume(float volume)
    {
        foreach (AudioSource buttonSoundSource in buttonSoundSources)
        {
            buttonSoundSource.volume = volume;
        }

        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }    
    public void SetEffectsVolume(float volume)
    {
        foreach (AudioSource buttonSoundSource in EffectsSources)
        {
            buttonSoundSource.volume = volume;
        }

        musicSource.volume = volume;
        PlayerPrefs.SetFloat("EffectsVolume", volume);
    }
}
