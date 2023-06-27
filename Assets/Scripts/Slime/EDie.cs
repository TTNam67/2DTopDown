using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime
{
    public class EDie : EAllStates
    {

        public EDie(StateMachine stateMachine) : base("EDie", stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();
            _animator.SetBool(a_isDead, true);
            _capsuleCollider2D.enabled = false;
            _eMovementSM.DisableMovement();
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
