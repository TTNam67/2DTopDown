using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    string _isWalking = "isWalking";
    bool _isHoldingWeapon = false;
    Animator _animator;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogWarning("Player.cs: Animator is not found");
        }
    }

    private void Update()
    {
        float dt = Time.deltaTime;
        Movement(dt);

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

