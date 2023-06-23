using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime
{
    public class EDie : BaseState
    {
        Animator _animator;
        EMovementSM _eMovementSM;
        CapsuleCollider2D _capsuleCollider2D;
        SpriteRenderer _spriteRenderer;
        string a_isDie = "isDie";

        public EDie(StateMachine stateMachine) : base("EDie", stateMachine)
        {
            _eMovementSM = (EMovementSM) stateMachine;
            _animator = _eMovementSM._animator;
            _capsuleCollider2D = _eMovementSM._capsuleCollider2D;
            _spriteRenderer = _eMovementSM._spriteRenderer;
        }

        public override void Enter()
        {
            base.Enter();
            _animator.SetBool(a_isDie, true);
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
