using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLivesUI : MonoBehaviour
{
    [SerializeField] private GameObject _life1;
    [SerializeField] private GameObject _life2;
    [SerializeField] private GameObject _life3;
    [SerializeField] private GameObject _life4;
    [SerializeField] private GameObject _life5;
    [SerializeField] private GameLogicManager _gameLogicManager;

// Update is called once per frame
    void Update()
    {
        if (GameStats.Lives < 1)
        {
            _life1.SetActive(false);
            _gameLogicManager.GameOver();
        }
        else if (GameStats.Lives < 2)
        {
            _life2.SetActive(false);
        }
        else if (GameStats.Lives < 3)
        {
            _life3.SetActive(false);
        }
        else if (GameStats.Lives < 4)
        {
            _life4.SetActive(false);
        }
        else if (GameStats.Lives < 5)
        {
            _life5.SetActive(false);
        }
    }

    public void RestartLives()
    {
        _life1.SetActive(true);
        _life2.SetActive(true);
        _life3.SetActive(true);
        _life4.SetActive(true);
        _life5.SetActive(true);
    }
}
