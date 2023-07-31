using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PAllStates : BaseState
    {
        
        protected PStateMachine _pStateMachine;
        protected Animator _animator;
        protected Rigidbody2D _rigidbody2D;
        protected CapsuleCollider2D _capsuleCollider2D;
        protected Health _health;
        protected HealthBar _healthBar;
        protected Weapon _weapon;

        protected string a_isMoving = "isMoving";
        protected string a_isDead = "isDead";
        protected string a_isAttack = "isAttack";
        protected FixedJoystick _fixedJoystick;
        

        public PAllStates(string name, StateMachine stateMachine) : base(name, stateMachine)
        {
            _pStateMachine = (PStateMachine)stateMachine;
            _animator = _pStateMachine._animator;
            _rigidbody2D = _pStateMachine._rigidbody2D;
            _capsuleCollider2D = _pStateMachine._capsuleCollider2D;
            _health = _pStateMachine._health;
            _healthBar = _pStateMachine._healthBar;
            _weapon = _pStateMachine._weapon;
            _fixedJoystick = _pStateMachine._fixedJoystick;
        }

        public override void Enter()
        {
            base.Enter();
            
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            _healthBar.SetHealth(_health.GetHealthPoint());
            CheckDead();
        }

        private void CheckDead()
        {
            if (_animator.GetBool(a_isDead))
            {
                
                _pStateMachine.ChangeState(_pStateMachine._pDieState);
            }
        }
    }
}
