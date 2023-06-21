using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIdle : PPatrol
{
    private string a_isIdle = "isIdle";
    public PIdle(StateMachine stateMachine) : base("PIdle", stateMachine)
    {

    }

    
}
