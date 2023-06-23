using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    
    public class PMoving : PPatrol
    {
        string a_isMoving = "isMoving";
        int _movable = 1;

        public PMoving(StateMachine stateMachine) : base("PMoving", stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();
            _animator.SetBool(a_isMoving, true);
            _pStateMachine.EnableMovement();
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            // Debug.Log("hori" + _horizontalInput + ", vertical" + _verticalInput);

            Vector2 velo = new Vector2(_horizontalInput, _verticalInput) * _pStateMachine._speed * _movable;

            // Debug.Log("velo" + velo);
            _rigidbody2D.velocity = velo;
        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
            if (_horizontalInput > Mathf.Epsilon)
                _rigidbody2D.transform.localScale = new Vector2(1f, 1f);
            else if (_horizontalInput < -Mathf.Epsilon)
                _rigidbody2D.transform.localScale = new Vector2(-1f, 1f);
        }

        public override void Exit()
        {
            base.Exit();
            _animator.SetBool(a_isMoving, false);
        }

        public void SetMovable(int movable)
        {
            _movable = movable;
        }
    }
}
