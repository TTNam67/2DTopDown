using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    float _damage = 90f;
    AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;    
    private void Start() 
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
            Debug.LogWarning("Weapon.cs: AudioSource is null");

        _audioSource.clip = _audioClip;
    }

    private void Update() 
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {


        if (other.transform.tag == "Enemy")    
        {
            print("Hit enemy");
            Health enemyHealth = other.transform.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(_damage);
            }
        }

        print(other.transform.name);
    }
}
