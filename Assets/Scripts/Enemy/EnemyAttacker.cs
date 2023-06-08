using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour, IEAction
{
    float _damage = 5f, _speedScale = 3.5f;
    float _attackRange = 6f, _attackCountDown = 1f;
    float _timeSinceLastAttack = Mathf.Infinity;
    string a_isAttack = "isAttack";

    Transform _target;
    EnemyActionScheduler _enemyActionScheduler;
    Animator _animator;
    EnemyMover _enemyMover;

    void Start()
    {
        _enemyActionScheduler  = GetComponent<EnemyActionScheduler>();
        if (_enemyActionScheduler == null)
            Debug.LogWarning("EnemyAttackBehaviour.cs: EnemyActionScheduler is null");

        _animator = GetComponent<Animator>();
        if (_animator == null)
            Debug.LogWarning("EnemyAttackBehaviour.cs: Animator is null");

        _enemyMover = GetComponent<EnemyMover>();
        if (_enemyMover == null)
            Debug.LogWarning("EnemyAttackBehaviour.cs: EnemyMover is null");
    }

    void Update()
    {
        // float dt = Time.deltaTime;
        // if (_animator.GetBool(a_isAttack) == true)
        // {
        //     _enemyMover.MoveTowardTarget(_target, dt);
        // }
    }

    public void Cancel()
    {
        _animator.SetBool(a_isAttack, false);
        _enemyMover.SetSpeedScale(1f);
    }

    public float GetAttackRange()
    {
        return _attackRange;
    }

    public void AttackBehavour(Transform target)
    {
        _animator.SetBool(a_isAttack, true);
        _enemyActionScheduler.StartAction(this);
        _target = target;
        _enemyMover.SetSpeedScale(_speedScale);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.transform.tag == "Player")
        {
            Health playerHealth = other.GetComponent<Health>();
            playerHealth.TakeDamage(_damage);
        }    
    }
}
