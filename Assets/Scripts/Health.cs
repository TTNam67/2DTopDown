using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
- Stores object's health information:
*/

public class Health : MonoBehaviour
{
    [SerializeField] private float _healthPoint = 50f;
    Animator _animator;
    string a_isDead = "isDead";
    bool _isDead = false;

    public bool isDead()
    {
        return _isDead;
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        if (_animator == null)
            Debug.LogWarning("Health.cs: _animator is null");
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        _healthPoint = Mathf.Max(0f, _healthPoint - damage);
        if (_healthPoint <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        _animator.SetBool(a_isDead, true);
    }
}
