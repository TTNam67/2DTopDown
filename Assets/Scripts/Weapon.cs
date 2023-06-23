using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    float _damage = 3f;
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
            Health enemyHealth = other.transform.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(_damage);
            }
        }

        print(other.transform.name);
    }
}
