using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider mySliderMaster;
    [SerializeField] private Slider mySliderEffects;
    [SerializeField] private Slider mySliderMusic;
    public void ChangeValueMaster(){
        float newValue = mySliderMaster.value;
        myMixer.SetFloat("Master", Mathf.Log10(newValue) * 20f);
    }
    public void ChangeValueEffects(){
        float newValue = mySliderEffects.value;
        myMixer.SetFloat("Effects", Mathf.Log10(newValue) * 20f);
    }
    public void ChangeValueMusic(){
        float newValue = mySliderMusic.value;
        myMixer.SetFloat("Music", Mathf.Log10(newValue) * 20f);
    }
}
