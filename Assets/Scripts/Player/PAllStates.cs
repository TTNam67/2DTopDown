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

        protected string a_isMoving = "isMoving";
        protected string a_isDead = "isDead";
        protected string a_isAttack = "isAttack";
        public PAllStates(string name, StateMachine stateMachine) : base(name, stateMachine)
        {
            _pStateMachine = (PStateMachine)stateMachine;
            _animator = _pStateMachine._animator;
            _rigidbody2D = _pStateMachine._rigidbody2D;
            _capsuleCollider2D = _pStateMachine._capsuleCollider2D;
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            CheckDead();
        }

        private void CheckDead()
        {
            if (_animator.GetBool(a_isDead))
                _pStateMachine.ChangeState(_pStateMachine._pDieState);
        }
    }
}
