using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionScheduler : MonoBehaviour
{
    IEAction _currentAction;

    public void StartAction(IEAction action)
    {
        if (_currentAction == action) 
        {
            print("check null");
            return;
        }
        if (_currentAction != null)
        {
            print("Check");
            _currentAction.Cancel();
        }

        _currentAction = action;
    }

    public void CancelCurrentAction()
    {
        print("CheckCancel");
        StartAction(null);
    }
}
