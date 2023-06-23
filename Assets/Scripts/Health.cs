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

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public bool isDead()
    {
        return _isDead;
    }

    public void TakeDamage(float damage)
    {
        _healthPoint = Mathf.Max(0f, _healthPoint - damage);
        if (_healthPoint <= 0f)
        {
            _isDead = true;
        }
    }

    private void Die()
    {

    }
}
