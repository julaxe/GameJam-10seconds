using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicManager : MonoBehaviour
{
    [Header("references")]
    public GameObject playerRef;
    public GameObject startScreen;
    public GameObject gameOverScreen;
    public OrbManager orbManager;
    public Enemy enemyPrefab;

    public float rewindTime = 3f;
    private float _timer;
    
    private PlayerMovement _playerMovement;
    private PlayerRecorder _playerRecorder;
    private List<Enemy> _enemies;
    private bool _enemySpawned;
    

    private void Start()
    {
        _enemies = new List<Enemy>();
        _playerMovement = playerRef.GetComponent<PlayerMovement>();
        _playerRecorder = playerRef.GetComponent<PlayerRecorder>();
    }

    void Update()
    {
        if (GameTimer.TimerFinished())
        {
            StopGameAndSpawnEnemy();

            if (_timer >= rewindTime+1)
            {
                _timer = 0.0f;
                StopRewindingEnemies();
                StartCoroutine(WaitAndStartTheGame(2.0f));
            }
            _timer += Time.deltaTime;
        }
    }
    
    public void StartGame()
    {
        GameTimer.StartTimer();
        startScreen.SetActive(false);
        StartMovement();
        orbManager.StartOrbManager();
    }

    private void StopGameAndSpawnEnemy()
    {
        if (!_enemySpawned)
        {
            StopGame();
            StartCoroutine(WaitAndSpawnEnemy(1.0f));
        }
    }

    private void StopGame()
    {
        GameTimer.PauseTimer();
        StopMovement();
        StopPlayingEnemies();
    }

    public void GameOver()
    {
        StopGame();
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        _enemies.ForEach(x => Destroy(x.gameObject));
        _enemies.Clear();
        StartGame();
    }

    IEnumerator WaitAndStartTheGame(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameTimer.StartTimer();
        PlayEnemies();
        StartMovement();
        _enemySpawned = false;
        _timer = 0.0f;
    }

    IEnumerator WaitAndSpawnEnemy(float seconds)
    {
        _enemySpawned = true;
        yield return new WaitForSeconds(seconds);
        SpawnNewEnemy();
        RewindEnemies();
        _timer = 0.0f;
    }

    private void SpawnNewEnemy()
    {
        Enemy newEnemy = Instantiate(enemyPrefab);
        newEnemy.StartEnemy( _playerRecorder.GetPositionRecorded(),_playerRecorder.GetLastPosition());
        _enemies.Add(newEnemy);
        GameStats.EnemiesSpawned += 1;
    }

    private void RewindEnemies()
    {
        SoundManager.Instance.PlayRewindEffect();
        foreach (var enemy in _enemies)
        {
            enemy.StartRewinding(rewindTime-1f);
        }
    }
    private void PlayEnemies()
    {
        foreach (var enemy in _enemies)
        {
            enemy.StartPlaying();
        }
    }

    private void StopPlayingEnemies()
    {
        foreach (var enemy in _enemies)
        {
            enemy.StopPlaying();
        }
    }
    
    private void StopRewindingEnemies()
    {
        foreach (var enemy in _enemies)
        {
            enemy.StopRewinding();
        }
    }
    

    private void StartMovement()
    {
        _playerMovement.ActivateMoving();
        _playerRecorder.StartRecording();
    }

    private void StopMovement()
    {
        _playerMovement.DisableMoving();
        _playerRecorder.StopRecording();
    }

    private bool EnemiesReady()
    {
        return _enemies.TrueForAll(x => x.IsReady());
    }
}
