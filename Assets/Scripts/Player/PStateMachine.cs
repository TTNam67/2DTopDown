using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PStateMachine : StateMachine
{
    [HideInInspector] public PIdle _pIdleState;
    [HideInInspector] public PMoving _pMovingState;
    [HideInInspector] public PAttack _pAttackState;
    [HideInInspector] public PDie _pDieState;

    public Rigidbody2D _rigidbody2D;
    public SpriteRenderer _spriteRenderer;
    public Animator _animator;

    public float _speed = 12f;

    private void Awake()
    {
        Debug.Log("PStateMachine");
        _pIdleState = new PIdle(this);
        _pMovingState = new PMoving(this);
        _pAttackState = new PAttack(this);
        _pDieState = new PDie(this);


        
    }

    protected override BaseState GetInitialState()
    {
        return _pIdleState;
    }
}
