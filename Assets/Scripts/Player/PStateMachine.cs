using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PStateMachine : StateMachine
    {
        Inventory _inventory;

        [HideInInspector] public PIdle _pIdleState;
        [HideInInspector] public PMoving _pMovingState;
        [HideInInspector] public PAttack _pAttackState;
        [HideInInspector] public PDie _pDieState;

        public Rigidbody2D _rigidbody2D;
        public SpriteRenderer _spriteRenderer;
        public Animator _animator;
        public Health _health;
        public CapsuleCollider2D _capsuleCollider2D;
        public HealthBar _healthBar;
        public Weapon _weapon;
        public FixedJoystick _fixedJoystick;

        public float _speed = 12f;
        public int _movable = 1;

        private void Awake()
        {
            _pIdleState = new PIdle(this);
            _pMovingState = new PMoving(this);
            _pAttackState = new PAttack(this);
            _pDieState = new PDie(this);

            _healthBar.SetMaxHealth(_health.GetHealthPoint());

            // _weapon = GetComponentInChildren<Weapon>();
            // if (_weapon == null)
            //     Debug.LogWarning("PStateMachine.cs: Weapon is null.");

            _inventory = new Inventory();
        }

        protected override BaseState GetInitialState()
        {
            return _pIdleState;
        }

        public void ChangeToIdle()
        {
            ChangeState(_pIdleState);
        }

        public void DisableMovement()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _pMovingState.SetMovable(0);
        }

        public void EnableMovement()
        {
            _pMovingState.SetMovable(1);
        }

        public void Destroy()
        {
            Destroy(this.gameObject);
        }
    }
}
