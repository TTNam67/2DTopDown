using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMovementSM : StateMachine
{

    [HideInInspector] public EIdle idleState;
    [HideInInspector] public EJump jumpState;
    [HideInInspector] public EJumpAttack jumpAttackState;
    [SerializeField]  Rigidbody2D _rigidbody2D;
    [SerializeField]  Animator _animator;
    [SerializeField]  Target _target;


    public float _speed = 2f, _speedScale = 1.5f;
    public float _attackRange = 7f;

    private void Awake() 
    {
        idleState = new EIdle(this);
        jumpState = new EJump(this);   
        jumpAttackState = new EJumpAttack(this);



        
    }

    private void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        if (_rigidbody2D == null)
            Debug.LogWarning("MovementSM.cs:No Rigidbody2D");

        _animator = GetComponent<Animator>();
        if (_animator == null)
            Debug.LogWarning("MovementSM.cs: No Animator");

        if (_target != null)
            Debug.LogWarning("Yes");
    }


    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    public void DisableMovement()
    {
        _rigidbody2D.velocity = Vector2.zero;
        jumpState.SetMovable(0);
    }

    public void EnableMovement()
    {
        jumpState.SetMovable(1);
    }

    public GameObject GetTarget()
    {
        return _target.GetTarget();
    }

    public Rigidbody2D GetRigidbody2D()
    {
        return _rigidbody2D;
    }

    public Animator GetAnimator()
    {
        return _animator;
    }
}
