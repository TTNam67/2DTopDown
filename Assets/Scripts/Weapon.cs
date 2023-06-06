using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
            Debug.LogWarning("Weapon.cs: AudioSource is not found");

        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
