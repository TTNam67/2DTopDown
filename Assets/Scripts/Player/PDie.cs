using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PDie : PAllStates
    {
        public PDie(StateMachine stateMachine) : base("PDie", stateMachine)
        {
            
        }

        public override void Enter()
        {
            base.Enter();
            _capsuleCollider2D.enabled = false;
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
