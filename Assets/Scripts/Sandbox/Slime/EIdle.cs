using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime
{
    public class EIdle : EPatrol
    {
        private string a_isIdle = "isIdle";
        public EIdle(EMovementSM stateMachine) : base("EIdle", stateMachine)
        {
            
        }

        public override void Enter()
        {
            base.Enter();
            
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            
        }
    }    
}

