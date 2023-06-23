using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime
{
    public class EMovementSM : StateMachine
{

    [HideInInspector] public EIdle _idleState;
    [HideInInspector] public EJump _jumpState;
    [HideInInspector] public EJumpAttack _jumpAttackState;
    [SerializeField] public Rigidbody2D _rigidbody2D;
    [SerializeField] public Animator _animator;
    [SerializeField] public GameObject _target;


    public float _speed = 2f, _speedScale = 1.5f;
    public float _attackRange = 7f;

    private void Awake() 
    {

        _target = GameObject.FindWithTag("Player");
        _idleState = new EIdle(this);
        _jumpState = new EJump(this);   
        _jumpAttackState = new EJumpAttack(this);
    }


    // private void Start() {
    //     _rigidbody2D = GetComponent<Rigidbody2D>();
    //     if (_rigidbody2D == null)
    //         Debug.LogWarning("MovementSM.cs:No Rigidbody2D");

    //     _animator = GetComponent<Animator>();
    //     if (_animator == null)
    //         Debug.LogWarning("MovementSM.cs: No Animator");    

       
    // }


    protected override BaseState GetInitialState()
    {
        return _idleState;
    }

    public void DisableMovement()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _jumpState.SetMovable(0);
    }

    public void EnableMovement()
    {
        _jumpState.SetMovable(1);
    }
    public Rigidbody2D GetRigidbody2D()
    {
        return _rigidbody2D;
    }

    public Animator GetAnimator()
    {
        return _animator;
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
    }
}
}
