using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    BaseState _currentState;
    void Start()
    {
        _currentState = GetInitialState();
        if (_currentState != null)
            _currentState.Enter();
    }
    

    void Update()
    {
        if (_currentState != null)
            _currentState.UpdateLogic();   
    }

    void LateUpdate() {
        {
            if (_currentState != null)
                _currentState.UpdatePhysics();
        }
    }

    private void OnGUI()
    {
        // GUILayout.BeginArea(new Rect(10f, 10f, 200f, 100f));
        // string content = _currentState != null ? _currentState.name : "No current state";
        // GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        // GUILayout.EndArea();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    public void ChangeState(BaseState newState)
    {
        _currentState.Exit();

        _currentState = newState;
        _currentState.Enter();
    }

    public BaseState CurrentState()
    {
        return _currentState;
    }
}
