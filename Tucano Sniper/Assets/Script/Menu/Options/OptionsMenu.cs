using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class OptionsMenu : MonoBehaviour
{

    //[SerializeField] Dropdown _ResolutionDropdown;

    //Resolution[] _resolutions;

    [SerializeField] AudioMixer _audioMixer;

    /* void Start()
     {

        _resolutions = Screen.resolutions;

         _ResolutionDropdown.ClearOptions();

         List<string> _options = new List<string>();

         for (int i= 0; i < _resolutions.Length; i++)
         {
             string _option = _resolutions[i].width + "x" + _resolutions[i].height;

             _options.Add(_option);
         }

         _ResolutionDropdown.AddOptions(_options);
     }*/

    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat("Tucano_Theme", volume);
    }
    
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

}
