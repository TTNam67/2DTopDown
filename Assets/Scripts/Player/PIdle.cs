using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PIdle : PPatrol
    {
        private string a_isIdle = "isIdle";
        
        public PIdle(StateMachine stateMachine) : base("PIdle", stateMachine)
        {
            
        }

        public override void Enter()
        {
            // _pStateMachine.DisableMovement();    
        }


        
    }
}
