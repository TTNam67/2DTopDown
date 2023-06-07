using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum SoundEffect
    {
        Grounding = 0,
        Die,
        Attack
        
    }

    [SerializeField] private AudioClip[] _audioClip;
    AudioSource _audioSource;
    EnemyActionScheduler _enemyActionScheduler;
    EnemyMover _enemyMover;
    float _groundingSoundScale = 0.24f, _explosionSoundScale = 0.3f;
    
    int _isMoving = 1;

    // Getters
    public int IsMoving()
    {
        return _isMoving;
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
            Debug.LogWarning("EnemyController.cs: _audioSource is null!");

        _enemyActionScheduler = GetComponent<EnemyActionScheduler>();
        if (_enemyActionScheduler == null)
            Debug.LogWarning("EnemyController.cs: _enemyActionScheduler is null!");

        _enemyMover = GetComponent<EnemyMover>();
        if (_enemyMover == null)
            Debug.LogWarning("EnemyController.cs: _enemyMover is null!");	

        _enemyMover.StartMoving();
        SetVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void GroundingSound()
    {
        _audioSource.clip = _audioClip[(int)SoundEffect.Grounding];
        _audioSource.volume = _groundingSoundScale;
        _audioSource.Play();
        
    }

    public void ExplosionSound()
    {
        _audioSource.clip = _audioClip[(int)SoundEffect.Die];
        _audioSource.volume = _explosionSoundScale;
        _audioSource.Play();
        // _audioSource.volume = 1f;
    }

    public void Moving()
    {
        _isMoving = 1;
    }

    public void StopMoving()
    {
        _isMoving = 0;
    }

    private void SetVolume()
    {

    }


}