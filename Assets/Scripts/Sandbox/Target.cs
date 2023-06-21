using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    GameObject _target;
    void Start()
    {
        _target = GameObject.FindWithTag("Player");
        if (_target == null)
            Debug.LogWarning("Target.cs: Target is not defined");
        else 
            Debug.LogWarning("Oke");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetTarget()
    {
        return _target;
    }

   
}
