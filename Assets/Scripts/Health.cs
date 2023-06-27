using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
- Stores object's health information:
*/

public class Health : MonoBehaviour
{
    [SerializeField] private float _healthPoint = 40f;
    bool _isDead = false;
    Animator _animator;
    string a_isDead = "isDead";

    void Start()
    {
        _animator = GetComponent<Animator>();
        if (_animator == null)
            Debug.LogWarning("PStateMachine.cs: Animator is null");
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        _healthPoint = Mathf.Max(0f, _healthPoint - damage);
        if (_healthPoint <= 0f)
        {
            if (_isDead == false)
            {
                _isDead = true;
                _animator.SetBool(a_isDead, _isDead);
            }
        }
        
    }

    private void Die()
    {

    }
}
