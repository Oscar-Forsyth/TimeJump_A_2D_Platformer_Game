using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audiomixer;
    public Slider mSlider;
    public Toggle fullS;
    public void SetVolume(float volume)
    {
        audiomixer.SetFloat("volume", volume);
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void UpdateValues()
    {
        float value = 0;
        audiomixer.GetFloat("volume", out value);
        mSlider.value = value;

        fullS.isOn = Screen.fullScreen;
    }
}
