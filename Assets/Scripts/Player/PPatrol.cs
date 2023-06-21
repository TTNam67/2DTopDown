using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPatrol : BaseState
{
    protected Animator _animator;
    protected Rigidbody2D _rigidbody2D;
    protected PStateMachine _pStateMachine;
    protected float _horizontalInput;
    protected float _verticalInput;
    public PPatrol(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
        _pStateMachine = (PStateMachine) stateMachine;
        _animator = _pStateMachine._animator;
        _rigidbody2D = _pStateMachine._rigidbody2D;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon
            || Mathf.Abs(_verticalInput) > Mathf.Epsilon)
        {
            _pStateMachine.ChangeState(_pStateMachine._pMovingState);
        }
        else 
        {
            _pStateMachine.ChangeState(_pStateMachine._pIdleState);
        }
    }
}
