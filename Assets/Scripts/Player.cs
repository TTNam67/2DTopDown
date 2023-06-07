using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float _speed = 7f;
    string a_isWalking = "isWalking";
    string a_isHoldingWeapon = "isHoldingWeapon";
    bool _holdingWeapon = false;
    Transform _weapon;
    Animator _animator;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogWarning("Player.cs: Animator is not found");
        }

        _weapon = transform.GetChild(0);
        if (_weapon == null)
            Debug.LogWarning("Player.cs: Weapon is not found");

    }

    private void Update()
    {
        float dt = Time.deltaTime;
        Movement(dt);

        if (Input.GetKeyDown(KeyCode.I))
            _holdingWeapon = !_holdingWeapon;

        if (_holdingWeapon == true)
        {
            _weapon.transform.gameObject.SetActive(_holdingWeapon);
            _animator.SetBool(a_isHoldingWeapon, true);
        }
        else 
        {
            _weapon.transform.gameObject.SetActive(_holdingWeapon);
            _animator.SetBool(a_isHoldingWeapon, false);
        }

    }

    private void Movement(float dt)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput == 0f && verticalInput == 0f)
        {
            _animator.SetBool(a_isWalking, false);
        }
        else 
        {
            _animator.SetBool(a_isWalking, true);
        }

        if (horizontalInput < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (horizontalInput > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        Vector2 direction = new Vector2(horizontalInput, verticalInput);

        transform.Translate(direction * _speed * dt);
    }

    public Vector3 GetDirection()
    {
        return transform.localScale;
    }
}

