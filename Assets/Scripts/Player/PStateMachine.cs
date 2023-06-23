using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PStateMachine : StateMachine
    {
        [HideInInspector] public PIdle _pIdleState;
        [HideInInspector] public PMoving _pMovingState;
        [HideInInspector] public PAttack _pAttackState;
        [HideInInspector] public PDie _pDieState;

        public Rigidbody2D _rigidbody2D;
        public SpriteRenderer _spriteRenderer;
        public Animator _animator;
        // PAttack _pAttack;

        public float _speed = 12f;

        private void Awake()
        {
            _pIdleState = new PIdle(this);
            _pMovingState = new PMoving(this);
            _pAttackState = new PAttack(this);
            _pDieState = new PDie(this);
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
        
    }
}
