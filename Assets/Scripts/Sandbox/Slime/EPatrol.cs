using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPatrol : BaseState
{

    protected EMovementSM _eMovementSM;
    protected Animator _animator;
    protected Rigidbody2D _rigidbody2D;
    protected GameObject _target;
    protected int _movable = 0;
    protected Vector2 _direction;
    public EPatrol(string name, EMovementSM stateMachine) : base(name, stateMachine)
    {
        _eMovementSM = (EMovementSM)stateMachine;
        _animator = _eMovementSM._animator;
        _rigidbody2D = _eMovementSM._rigidbody2D;
        _target = _eMovementSM._target;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("EPatrol");
        _direction = new Vector2(0, 0);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        Debug.Log("EPatrol Updating");
        float distane = Vector2.Distance(_target.transform.position, _rigidbody2D.position);
        Debug.Log("movable" + _movable);

        // if target is in enemy's attackRange and the enemy is on the ground --> Change to jumpAttack state
        // Nếu lệnh if này đúng, lệnh ở bên dưới cụm "If" vẫn được thực thi
        if (distane <= _eMovementSM._attackRange
            && _movable == 0)
        {
            stateMachine.ChangeState(_eMovementSM._jumpAttackState);
        }
        else 
        {
            // Debug.Log(Time.timeSinceLevelLoad);

            
        }

        int ran = Random.Range(1, 101); //[0, 100]
        if (_movable == 0)
        {
            if (ran <= 40)
            {
                stateMachine.ChangeState(_eMovementSM._jumpState);
            }
            else
            {
                stateMachine.ChangeState(_eMovementSM._idleState);
            }
        }
        
        
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
