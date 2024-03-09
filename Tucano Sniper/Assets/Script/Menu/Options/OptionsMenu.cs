using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class OptionsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer _audioMixer;
   
    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat("Tucano_Theme", volume);

    }
}
