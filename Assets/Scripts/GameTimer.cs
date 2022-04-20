using System;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private static int _gameTimeInSeconds = 10;

    [SerializeField] private GameObject _startScreen;
    private TextMeshProUGUI _textMeshPro;
    private float _timer;
    private static bool _timerFinished;
    private static bool _timerStarted;
    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (!_timerStarted) return;
        if (_timer >= 1.0f)
        {
            _timer = 0.0f;
            _gameTimeInSeconds -= 1;
            _textMeshPro.text = _gameTimeInSeconds.ToString();
            if (_gameTimeInSeconds <= 0)
            {
                _timerFinished = true;
            }
        }

        _timer += Time.deltaTime;
    }
    

    public static bool TimerFinished()
    {
        return _timerFinished;
    }

    public static void StartTimer()
    {
        _gameTimeInSeconds = 11;
        _timerFinished = false;
        _timerStarted = true;
    }

    public static void PauseTimer()
    {
        _timerStarted = false;
    }
    
    
}
