using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime
{
    public class EPatrol : EAllStates
    {
        protected int _movable = 0;
        

        public EPatrol(string name, EStateMachine stateMachine) : base(name, stateMachine)
        {
            
        }

        public override void Enter()
        {
            base.Enter();
            _direction = new Vector2(0, 0);
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            if (_animator.GetBool(a_isDead))
                _eMovementSM.ChangeState(_eMovementSM._dieState);

            float distane = Vector2.Distance(_target.transform.position, _rigidbody2D.position);

            // if target is in enemy's attackRange and the enemy is on the ground --> Change to jumpAttack state
            // Nếu lệnh if này đúng, lệnh ở bên dưới cụm "If" vẫn được thực thi
            if (distane <= _eMovementSM._attackRange
                && _movable == 0)
            {
                stateMachine.ChangeState(_eMovementSM._jumpAttackState);
            }
            else 
            {
                // Debug.Log(Time.timeSinceLevelLoad);
                int ran = Random.Range(1, 101); //[0, 100]
                if (_movable == 0)
                {
                    if (ran <= 40)
                    {
                        stateMachine.ChangeState(_eMovementSM._jumpState);
                    }
                    else
                    {
                        stateMachine.ChangeState(_eMovementSM._idleState);
                    }
                }
                
            }

            
            
            
        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
        }
    }
}
