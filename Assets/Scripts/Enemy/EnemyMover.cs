using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour, IEAction
{
    private float _speed = 1.5f, _speedScale = 1f;
    GameObject _target;
    EnemyController _enemyController;
    EnemyActionScheduler _enemyActionScheduler;

    Vector2 _direction;
    int _isMoving = 0;
    void Start()
    {
        _target = GameObject.FindWithTag("Player");
        if (_target == null)
            Debug.LogWarning("EnemyMover.cs: _target is null!");

        _enemyController = GetComponent<EnemyController>();
        if (_enemyController == null)
            Debug.LogWarning("EnemyMover.cs: _enemyController is null!");

        _enemyActionScheduler = GetComponent<EnemyActionScheduler>();
        if (_enemyActionScheduler == null)
            Debug.LogWarning("EnemyMover.cs: _enemyActionScheduler is null!");

        //Before make the first move, enemy needs to be determined the direction
        //towards the player
        DetermineDirection(_target.transform);
        MoveBehaviour();
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        if (_isMoving == 1)
            MoveTowardTarget(_target.transform, dt);
    }

    public void MoveTowardTarget(Transform target, float dt)
    {
        DetermineDirection(target);
        transform.Translate(_direction * dt * _speed * GetSpeedScale());
    }

    private void DetermineDirection(Transform target)
    {
        _direction = (target.position - transform.position).normalized;

        if (_direction.x < 0f)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else if (_direction.x > 0f)
            transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void Cancel()
    {
        StopMoving();
    }

    public void MoveBehaviour()
    {
        _enemyActionScheduler.StartAction(this);
        Moving();
    }

    public void Moving()
    {
        _isMoving = 1;
    }

    public void StopMoving()
    {
        _isMoving = 0;
    }

    public void SetSpeedScale(float speedScale)
    {
        _speedScale = speedScale;
    }

    public float GetSpeedScale()
    {
        return _speedScale;
    }
}




