using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SettingsController : MonoBehaviour
{

    public AudioMixer inGameAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetMasterVolume(float volume)
    {
        inGameAudio.SetFloat("Master", volume);
    }

    public void SetMusic(float volume)
    {
        inGameAudio.SetFloat("Music", volume);
    }

    public void SetSoundEffects(float volume) 
    {
        inGameAudio.SetFloat("SoundEffects", volume);
    }
}
