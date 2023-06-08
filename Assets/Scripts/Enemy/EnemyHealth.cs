using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
- Stores object's health information:
*/

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _healthPoint = 30f;
    Animator _animator;
    EnemyActionScheduler _enemiesActionScheduler;
    EnemyMover _enemyMover;
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
            Debug.LogWarning("EnemyHealth.cs: _animator is null");

        _enemiesActionScheduler = GetComponent<EnemyActionScheduler>();
        if (_enemiesActionScheduler == null)
            Debug.LogWarning("EnemyHealth.cs: _enemiesActionScheduler is null");
        
        _enemyMover = GetComponent<EnemyMover>();
        if (_enemyMover == null)
            Debug.LogWarning("EnemyHealth.cs: _enemyMover is null");
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
        _enemiesActionScheduler.transform.GetComponent<CapsuleCollider2D>().enabled = false;
        _animator.SetBool(a_isDead, true);
        _enemiesActionScheduler.CancelCurrentAction();
        _enemyMover.StopMoving();

        Destroy(this.gameObject, 1.5f);
    }
}
