using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime
{
    public class EJumpAttack : EAllStates
    {
        
        
        float _speedScale = 2.2f;
        float _horizontalInput;
        float _verticalInput;

        public EJumpAttack(StateMachine stateMachine) : base("EJumpAttack", stateMachine)
        {
            _eMovementSM = (EStateMachine)stateMachine;
            _animator = _eMovementSM._animator;
            // _target = _eMovementSM._target.transform;
            _rigidbody2D = _eMovementSM._rigidbody2D;
            _health = _eMovementSM._health;
        }

        public override void Enter()
        {
            base.Enter();
            _animator.SetBool(a_isJumpAttack, true);
            _eMovementSM._jumpState.SetSpeedScale(_speedScale);
        }

        public override void UpdateLogic()
        {
            // Debug.Log("something");
            base.UpdateLogic();

            if (_animator.GetBool(a_isDead))
                _eMovementSM.ChangeState(_eMovementSM._dieState);

            if (Vector2.Distance(_target.transform.position, _rigidbody2D.position) > _eMovementSM._attackRange)
            {
                _eMovementSM.ChangeState(_eMovementSM._idleState);
            }

            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");
            _eMovementSM._jumpState.DetermineDirection();
        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
            _eMovementSM._jumpState.MakeTheMove();
        }

        public override void Exit()
        {
            base.Exit();
            _animator.SetBool(a_isJumpAttack, false);
            _eMovementSM._jumpState.SetSpeedScale(1f);
        }

        
    }
}
