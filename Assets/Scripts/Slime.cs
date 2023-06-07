using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public enum SoundEffect
    {
        Grounding = 0,
        Attack = 1
    }

    [SerializeField] private AudioClip[] _audioClip;
    AudioSource _audioSource;
    Transform _playerTransform;
    float _speed = 1f;
    int _isMoving = 1;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
            Debug.LogWarning("Slime.cs: _audioSource is null!");

        _playerTransform = GameObject.FindWithTag("Player").transform;
        if (_playerTransform == null)
            Debug.LogWarning("Slime.cs: _playerTransform is null!");
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        Movement(dt);
    }

    private void Movement(float dt)
    {
        Vector2 direction = (_playerTransform.position - transform.position).normalized;
        
        if (_isMoving == 0)
        {
            if (direction.x < 0f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (direction.x > 0f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }

        print("Direction: " + direction);

        transform.Translate(direction * dt * _speed * _isMoving);
    }

    public void GroundingSound()
    {
        _audioSource.clip = _audioClip[(int)SoundEffect.Grounding];
        _audioSource.Play();
    }

    public void Moving()
    {
        _isMoving = 1;
    }

    public void Stable()
    {
        _isMoving = 0;
    }
}
