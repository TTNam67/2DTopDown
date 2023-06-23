using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PAttack : BaseState
{
    Animator _animator;
    PStateMachine _pStateMachine;
    Rigidbody2D _rigidbody2D;

    string a_isAttack = "isAttack";
    public PAttack(StateMachine stateMachine) : base("PAttack", stateMachine)
    {
        _pStateMachine = (PStateMachine) stateMachine;
        _animator = _pStateMachine._animator;
        _rigidbody2D = _pStateMachine._rigidbody2D;
    }

    public override void Enter()
    {
        base.Enter();
        _animator.SetBool(a_isAttack, true);
        _pStateMachine.DisableMovement();
        // _pStateMachine._rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(-_rigidbody2D.velocity, ForceMode2D.Impulse);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void Exit()
    {
        base.Exit();
        _animator.SetBool(a_isAttack, false);
    }

    
    
}
}
