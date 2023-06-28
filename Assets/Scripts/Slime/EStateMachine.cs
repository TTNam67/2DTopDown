using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime
{
    public class EStateMachine : StateMachine
    {

    [HideInInspector] public EIdle _idleState;
    [HideInInspector] public EJump _jumpState;
    [HideInInspector] public EJumpAttack _jumpAttackState;
    [HideInInspector] public EDie _dieState;
    [SerializeField] public Rigidbody2D _rigidbody2D;
    [SerializeField] public Animator _animator;
    [SerializeField] public GameObject _target;
    [SerializeField] public CapsuleCollider2D _capsuleCollider2D;
    [SerializeField] public Health _health;
    [SerializeField] public SpriteRenderer _spriteRenderer;


    public float _speed = 1.5f, _speedScale = 1.2f;
    public float _attackRange = 7f, _attackDamage = 6f;

    private void Awake() 
    {

        _target = GameObject.FindWithTag("Player");

        _idleState = new EIdle(this);
        _jumpState = new EJump(this);   
        _jumpAttackState = new EJumpAttack(this);
        _dieState = new EDie(this);

        // _rigidbody2D = GetComponent<Rigidbody2D>();
        // if (_rigidbody2D == null)
        //     Debug.LogWarning("MovementSM.cs:No Rigidbody2D");

        // _animator = GetComponent<Animator>();
        // if (_animator == null)
        //     Debug.LogWarning("MovementSM.cs: No Animator");

        // _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        // if (_capsuleCollider2D == null)
        //     Debug.LogWarning("MovementSM.cs: No CapsuleCollider2D");

        // _health = GetComponent<Health>();
        // if (_health == null)
        //     Debug.LogWarning("EMovementSM.cs: Health is null");

        // _spriteRenderer = GetComponent<SpriteRenderer>();
        // if (_spriteRenderer == null)
        //         Debug.LogWarning("EMovementSM.cs: SpriteRenderer is null");

        

    }

    // Nếu có hàm Start() thì enemy sẽ không target được vào player
    // private void Start() 
    // {
     
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

    public void Destroy()
    {
        Destroy(this.gameObject);
    }


    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.tag == "Player")
        {
            _target.GetComponent<Health>().TakeDamage(_attackDamage);

        }
    }
}
}
