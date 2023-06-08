using System;
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
    GameObject _target;
    EnemyActionScheduler _enemyActionScheduler;
    EnemyMover _enemyMover;
    EnemyAttacker _enemyAttacker;
    Animator _animator;
    float _groundingSoundScale = 0.24f, _explosionSoundScale = 0.3f;
    string a_isAttack = "isAttack";
    

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
            Debug.LogWarning("EnemyController.cs: _audioSource is null!");

        _target = GameObject.FindWithTag("Player");
        if (_target == null)
            Debug.LogWarning("EnemyController.cs: _target is null!");

        _enemyActionScheduler = GetComponent<EnemyActionScheduler>();
        if (_enemyActionScheduler == null)
            Debug.LogWarning("EnemyController.cs: _enemyActionScheduler is null!");

        _enemyMover = GetComponent<EnemyMover>();
        if (_enemyMover == null)
            Debug.LogWarning("EnemyController.cs: _enemyMover is null!");	

        _enemyAttacker = GetComponent<EnemyAttacker>();
        if (_enemyAttacker == null)
            Debug.LogWarning("EnemyController.cs: _enemyAttacker is null!");

        _animator = GetComponent<Animator>();
        if (_animator == null)
            Debug.LogWarning("EnemyController.cs: _animator is null");

        // _enemyMover.StartMoving();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPosi = new Vector2(_target.transform.position.x, _target.transform.position.y);

        if (Vector2.Distance(transform.position, targetPosi) <= _enemyAttacker.GetAttackRange())
        {
            _enemyAttacker.AttackBehavour(_target.transform);
        }
        else 
        {
            _enemyMover.MoveBehaviour();
        }
    }

    

    public void GroundingSound()
    {
        // _audioSource.clip = _audioClip[(int)SoundEffect.Grounding];

        // _audioSource.volume = _groundingSoundScale;
        // _audioSource.PlayOneShot(_audioClip[(int)SoundEffect.Grounding]);
        
    }

    public void ExplosionSound()
    {
        // _audioSource.clip = _audioClip[(int)SoundEffect.Die];
        _audioSource.volume = _explosionSoundScale;
        _audioSource.PlayOneShot(_audioClip[(int)SoundEffect.Die]);
        
        // _audioSource.volume = 1f;
    }

    

    // public GameObject TargetObject()
    // {
    //     return _target;
    // }

}

