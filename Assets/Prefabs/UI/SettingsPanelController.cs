using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelController : MonoBehaviour
{
    public Slider BGMVolumeSlider;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("BGMVolume"))
        {
            BGMVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        }
        else
        {
            BGMVolumeSlider.value = 1;
        }
    }
    public void SetBackGroundMusicVolume()
    {
        SoundManager.instance.backGroundAudio.volume = BGMVolumeSlider.value;
        PlayerPrefs.SetFloat("BGMVolume", BGMVolumeSlider.value);
    }
}
