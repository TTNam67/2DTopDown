using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    AudioSource _audioSource;
    float _backgroundMusicVolume = 0.45f;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
            Debug.LogWarning("SoundController.cs: AudioSource is not found");

        _audioSource.volume = _backgroundMusicVolume;
        _audioSource.Play();

        DontDestroyOnLoad(this.gameObject);
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
