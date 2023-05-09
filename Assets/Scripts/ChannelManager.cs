using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "ChannelManager", menuName = "ScriptableObjects/Audio/ChannelManager", order = 1)]
public class ChannelManager : ScriptableObject
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private string ChannelVolume;
    [SerializeField] private float currentVolume;

    public void UpdateVolume(Slider mySlider)
    {
        currentVolume = mySlider.value;
        myMixer.SetFloat(ChannelVolume, Mathf.Log10(currentVolume) * 20f);
    }
}