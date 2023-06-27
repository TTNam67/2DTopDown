using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime
{
    public class EJump : EPatrol
    {
        string a_isJump = "isJump";


        public EJump(EStateMachine stateMachine) : base("EJump", stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();
            _animator.SetBool(a_isJump, true);
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            DetermineDirection();
        }

        public void DetermineDirection()
        {
            _direction = (Vector2)_target.transform.position - _rigidbody2D.position;
            _direction.Normalize();

            if (_direction.x < -Mathf.Epsilon)
                _rigidbody2D.transform.localScale = new Vector2(-1f, 1f);
            else if (_direction.x > Mathf.Epsilon)
                _rigidbody2D.transform.localScale = new Vector2(1f, 1f);
        }


        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
            MakeTheMove();
        }

        public void MakeTheMove()
        {
            _rigidbody2D.velocity = _direction * _eMovementSM._speed * _movable * _eMovementSM._speedScale;
        }

        public override void Exit()
        {
            base.Exit();
            _animator.SetBool(a_isJump, false);
        }

        public void SetMovable(int movable)
        {
            _movable = movable;
        }

        public void SetSpeedScale(float speedScale)
        {
            _eMovementSM._speedScale = speedScale;
        }
    }
}
