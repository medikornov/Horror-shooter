using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class settingsScript : MonoBehaviour
{

    public AudioMixer audioMixer;
    public static float volume;
    public static float sensitivity;
    public Slider slider;
    public Slider senst;
    // Start is called before the first frame update
    void Start()
    {
        volume = PlayerPrefs.GetFloat("Volume", volume);
        sensitivity = PlayerPrefs.GetFloat("Sensitivity", sensitivity);
        audioMixer.SetFloat("Volume", volume);
        slider.value = volume;
        senst.value = sensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }
    public void SetSensitivity(float sensitivity)
    {
        PlayerPrefs.SetFloat("Sensitivity", sensitivity);
    }
}
