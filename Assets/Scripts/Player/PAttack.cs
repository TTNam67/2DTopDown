using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PAttack : PAllStates
    {
        
        public PAttack(StateMachine stateMachine) : base("PAttack", stateMachine)
        {

            
        }

        public override void Enter()
        {
            base.Enter();
            _animator.SetBool(a_isAttack, true);
            _pStateMachine.DisableMovement();
            _rigidbody2D.AddForce(-_rigidbody2D.velocity, ForceMode2D.Impulse);
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
            _animator.SetBool(a_isAttack, false);
        }

        
        
    }
}
