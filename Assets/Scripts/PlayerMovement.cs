using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float _speed = 1f;

    private Vector3 _direction;
    private Vector3 _force;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        _direction = new Vector3(x, 0f, y);
        if (_direction != Vector3.zero)
        {
            _direction = _direction.normalized;
            var newRot = Quaternion.LookRotation(_direction);
            transform.rotation = newRot;
        }
    }

    private void FixedUpdate()
    {
        _force = _direction * _speed * Time.fixedDeltaTime;
        _rigidbody.AddForce(_force);
    }

}
