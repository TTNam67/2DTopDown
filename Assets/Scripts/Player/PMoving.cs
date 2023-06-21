using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMoving : PPatrol
{
    string a_isMoving = "isMoving";
    // float _horizontalInput;
    // float _verticalInput;

    public PMoving(StateMachine stateMachine) : base("PMoving", stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        _animator.SetBool(a_isMoving, true);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        // Debug.Log("hori" + _horizontalInput + ", vertical" + _verticalInput);

        Vector2 velo = new Vector2(_horizontalInput, _verticalInput) * _pStateMachine._speed;

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
}
