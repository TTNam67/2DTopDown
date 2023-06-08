using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour, IEAction
{
    [SerializeField] private float _speed = 1f;
    Transform _playerTransform;
    EnemyController _enemyController;
    EnemyActionScheduler _enemyActionScheduler;

    Vector2 _direction;
    void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
        if (_playerTransform == null)
            Debug.LogWarning("EnemyMover.cs: _playerTransform is null!");

        _enemyController = GetComponent<EnemyController>();
        if (_enemyController == null)
            Debug.LogWarning("EnemyMover.cs: _enemyController is null!");

        _enemyActionScheduler = GetComponent<EnemyActionScheduler>();
        if (_enemyActionScheduler == null)
            Debug.LogWarning("EnemyMover.cs: _enemyActionScheduler is null!");

        //Before make the first move, enemy needs to be determined the direction
        //towards the player
        DetermineDirection();
        StartMoving();
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        Movement(dt);
    }

    private void Movement(float dt)
    {
        
        DetermineDirection();
        transform.Translate(_direction * dt * _speed * _enemyController.IsMoving());
    }

    private void DetermineDirection()
    {
        _direction = (_playerTransform.position - transform.position).normalized;

        if (_enemyController.IsMoving() == 0)
        {
            if (_direction.x < 0f)
                transform.localScale = new Vector3(-1f, 1f, 1f);
            else if (_direction.x > 0f)
                transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void Cancel()
    {
        _enemyController.StopMoving();
    }

    public void StartMoving()
    {
        _enemyActionScheduler.StartAction(this);
        _enemyController.Moving();
    }
}




