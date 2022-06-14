using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider mainSlider;
    public string mainName = "MainVol";
    public Slider musicSlider;
    public string musicName = "Music";
    public Slider voiceSlider;
    public string voiceName = "Voice";
    public Slider sfxSlider;
    public string sfxName = "SfxVol";

    float currentMain;
    float currentMusic;
    float currentVoice;
    float currentSfx;
    private float vol;

    // Start is called before the first frame update
    void Start()
    {
        LoadSettings();
    }

       public void SetMain(float volume)
    {
        audioMixer.SetFloat(mainName, Mathf.Log10(volume) * 20);
        currentMain = volume;
        audioMixer.GetFloat("MainVol", out vol);
        //print("Main Volume: " + vol);
    }

    public void SetMusic(float volume)
    {
        audioMixer.SetFloat(musicName, Mathf.Log10(volume) * 20);
        currentMusic = volume;
    }

    public void SetVoice(float volume)
    {
        audioMixer.SetFloat(voiceName, Mathf.Log10(volume) * 20);
        currentVoice = volume;
    }

    public void SetSfx(float volume)
    {
        audioMixer.SetFloat(sfxName, Mathf.Log10(volume) * 20);
        currentSfx = volume;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat(mainName, currentMain);
        PlayerPrefs.SetFloat(musicName, currentMusic);
        PlayerPrefs.SetFloat(voiceName, currentVoice);
        PlayerPrefs.SetFloat(sfxName, currentSfx);
        PlayerPrefs.Save();
        //print("Settings saved.");
    }

    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey(mainName))
        {
            currentMain = PlayerPrefs.GetFloat(mainName);
         }
        else
            currentMain = 1f;
        mainSlider.value = currentMain;
        audioMixer.SetFloat(mainName, Mathf.Log10(currentMain) * 20);

        if (PlayerPrefs.HasKey(musicName))
        {
            currentMusic = PlayerPrefs.GetFloat(musicName);
        }
        else
            currentMusic = 0.5f;
        musicSlider.value = currentMusic;
        audioMixer.SetFloat(musicName, Mathf.Log10(currentMusic) * 20);


        if (PlayerPrefs.HasKey(voiceName))
        {
            currentVoice = PlayerPrefs.GetFloat(voiceName);
        }
        else
            currentVoice = 1f;
        voiceSlider.value = currentVoice;
        audioMixer.SetFloat(voiceName, Mathf.Log10(currentVoice) * 20);

        if (PlayerPrefs.HasKey(sfxName))
        {
            currentSfx = PlayerPrefs.GetFloat(sfxName);
        }
        else
           currentSfx = 1f;
        sfxSlider.value = currentSfx;
        audioMixer.SetFloat(sfxName, Mathf.Log10(currentSfx) * 20);

        //print("Settings loaded");
    }
}
