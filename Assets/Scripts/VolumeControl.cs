using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeControl : MonoBehaviour
{
    public Slider volume;
    public TextMeshProUGUI volumeTxt;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 0.5f);
        }
        SetSlider();
        ChangeVolume();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volume.value;
        volumeTxt.text = ((int)(volume.value * 100)).ToString();
        Save();
    }

    void SetSlider()
    {
        volume.value = PlayerPrefs.GetFloat("volume");
    }

    void Save()
    {
        PlayerPrefs.SetFloat("volume", volume.value);
    }
}
