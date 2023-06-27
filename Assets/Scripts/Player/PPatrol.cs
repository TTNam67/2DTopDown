using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PPatrol : PAllStates
    {
        protected float _horizontalInput;
        protected float _verticalInput;

        
        
        public PPatrol(string name, StateMachine stateMachine) : base(name, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            if (_animator.GetBool(a_isDead) == false)
            {
                CheckAttack();
                CheckMoving();
            }
        }


        private void CheckAttack()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                _pStateMachine.ChangeState(_pStateMachine._pAttackState);
            }
        }

        private void CheckMoving()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");
            if (_pStateMachine.CurrentState() != _pStateMachine._pAttackState)
            {
                if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon
                || Mathf.Abs(_verticalInput) > Mathf.Epsilon)
                {
                    _pStateMachine.ChangeState(_pStateMachine._pMovingState);
                }
                else
                {
                    _pStateMachine.ChangeState(_pStateMachine._pIdleState);
                }
            }
        }
    }
}
