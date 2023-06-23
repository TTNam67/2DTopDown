using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private void Start() 
    {
        
    }

    private void Update() 
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.transform.tag == "Enemy")    
        {
            print("Hit enemy");
        }

        print(other.transform.name);
    }
}
