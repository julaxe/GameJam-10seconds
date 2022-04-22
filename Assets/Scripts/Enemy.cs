using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _rewindTime;
    private float _playingRate;
    private float _rewindRate;
    private float _timer;
    
    private int _arraySize;
    private Vector3[] _positionsArray;
    private int _currentPosition;
    
    private Rigidbody _rigidbody;
    private PlayerAnimation _animation;

    private bool _isRewinding;
    private bool _isPlaying;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isRewinding)
        {
            if (_currentPosition < 0) return;
            ChangeRotation();
            MoveBackwards();
        }
        else if (_isPlaying)
        {
            if (_currentPosition >= _arraySize) return;
            ChangeRotation();
            MoveForward();
        }
    }

    public void StartEnemy(Vector3[] positions, int lastPosition)
    {
        _playingRate = 1f / (lastPosition / 9f);
        _arraySize = lastPosition;
        _positionsArray = new Vector3[_arraySize];
        _positionsArray =(Vector3[]) positions.Clone();
    }

    public void StartPlaying()
    {
        _currentPosition = 0;
        _isPlaying = true;
        _isRewinding = false;
        _animation.StartRolling();
    }

    public void StartRewinding(float rewindTime)
    {
        _rewindTime = rewindTime;
        _rewindRate = 1f / (_arraySize / _rewindTime);
        _currentPosition = _arraySize - 1;
        _isRewinding = true;
        _isPlaying = false;
        _animation.StartRollingBackwards();
    }

    private void MoveForward()
    {
        if (_timer >= _playingRate)
        {
            transform.position = _positionsArray[_currentPosition];
            _currentPosition += 1;
            _timer = 0.0f;
        }

        _timer += Time.deltaTime;
    }

    private void MoveBackwards()
    {
        
        if (_timer >= _rewindRate)
        {
            transform.position = _positionsArray[_currentPosition];
            _currentPosition -= 1;
            _timer = 0.0f;
        }
        _timer += Time.deltaTime;
    }

    public void StopPlaying()
    {
        _isPlaying = false;
        _animation.StopRolling();
    }

    public void StopRewinding()
    {
        _isRewinding = false;
        _animation.StopRollingBackwards();
    }

    private void ChangeRotation()
    {
        Vector3 direction;
        if (!_isRewinding)
        {
            direction = _positionsArray[_currentPosition] - transform.position;
        }
        else
        {
            direction = -transform.position - _positionsArray[_currentPosition] ;
        }

        if (direction.Equals(Vector3.zero)) return;
        var newRot = Quaternion.LookRotation(direction.normalized);
        transform.rotation = newRot;
    }
    

    public bool IsReady()
    {
        return !_isPlaying && !_isRewinding;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isPlaying) return;
        if (!other.CompareTag("Player")) return;
        
        other.GetComponent<PlayerMovement>().CollideWithEnemy();
    }
}
