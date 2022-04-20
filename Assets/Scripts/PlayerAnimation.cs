using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Animator _animator;
    
    private readonly int _hashRForwardAnimation = Animator.StringToHash("RollingForward");
    private readonly int _hashRBackwardsAnimation = Animator.StringToHash("RollingBackwards");
    private bool _isRolling = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isRolling = !_isRolling;
            _animator.SetBool(_hashRForwardAnimation, _isRolling);
        }
    }
}
