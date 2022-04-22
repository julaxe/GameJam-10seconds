using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecorder : MonoBehaviour
{
    [SerializeField] private int _positionPerSecond = 10;
    private float _recorderRate;
    private float _timer;

    private Vector3[] _positionsArray;
    private int _currentPosition;

    private bool _isRecording;

    private void Start()
    {
        _positionsArray = new Vector3[_positionPerSecond * 10];
        _recorderRate = 1f / _positionPerSecond;
    }

    private void Update()
    {
        if (_isRecording)
        {
            if (_timer >= _recorderRate)
            {
                if (_currentPosition >= _positionPerSecond * 10)
                {
                    Debug.Log("Error: array is full, is trying to access an invalid position in the array");
                    return;
                }

                _positionsArray[_currentPosition] = transform.position;
                _currentPosition++;
                _timer = 0.0f;
            }

            _timer += Time.deltaTime;
        }
    }

    public void StartRecording()
    {
        _currentPosition = 0;
        _isRecording = true;
    }

    public void StopRecording()
    {
        _isRecording = false;
    }

    public Vector3[] GetPositionRecorded()
    {
        return _positionsArray;
    }

    public int GetLastPosition()
    {
        return _currentPosition;
    }

}
