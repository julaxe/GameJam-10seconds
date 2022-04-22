using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
     [SerializeField] private GameLogicManager _gameLogicManager;
     [SerializeField] private PlayerLivesUI _playerLivesUI;

     public void RestartGame()
     {
          _playerLivesUI.RestartLives();
          GameStats.ResetStats();
          _gameLogicManager.RestartGame();
          gameObject.SetActive(false);
     }
}
