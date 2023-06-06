using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    string _isWalking = "isWalking";
    string _isHoldingWeapon = "isHoldingWeapon";
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
            _animator.SetBool(_isHoldingWeapon, true);
        }
        else 
        {
            _weapon.transform.gameObject.SetActive(_holdingWeapon);
            _animator.SetBool(_isHoldingWeapon, false);
        }

    }

    private void Movement(float dt)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            _animator.SetBool(_isWalking, true);
        }
        else if (horizontalInput > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            _animator.SetBool(_isWalking, true);
        }
        else if (horizontalInput == 0f)
        {
            _animator.SetBool(_isWalking, false);
        }

        Vector2 direction = new Vector2(horizontalInput, verticalInput);

        transform.Translate(direction * _speed * dt);
    }
}

