using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime
{
    public class EAllStates : BaseState
    {
        protected EStateMachine _eMovementSM;
        protected Animator _animator;
        protected Rigidbody2D _rigidbody2D;
        protected GameObject _target;
        protected Health _health;
        protected CapsuleCollider2D _capsuleCollider2D;
        protected SpriteRenderer _spriteRenderer;

        protected Vector2 _direction;

        protected string a_isDead = "isDead";
        protected string a_isJumpAttack = "isJumpAttack";
        protected string a_isJump = "isJump";
        protected string a_isIdle = "isIdle";
        
        public EAllStates(string name, StateMachine stateMachine) : base(name, stateMachine)
        {
            _eMovementSM = (EStateMachine)stateMachine;
            _animator = _eMovementSM._animator;
            _rigidbody2D = _eMovementSM._rigidbody2D;
            _target = _eMovementSM._target;
            _health = _eMovementSM._health;
            _capsuleCollider2D = _eMovementSM._capsuleCollider2D;
            _spriteRenderer = _eMovementSM._spriteRenderer;
        }

        public override void Enter()
        {
            base.Enter();
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
        }
    }
}
