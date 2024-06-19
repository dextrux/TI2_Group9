using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingManager : MonoBehaviour
{
    public static PlayingManager Instance;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _inGameUI;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ResumeGame()
    {
        _gameOverScreen.SetActive(false);
    }
    public void GameOver()
    {
        GameManager.instance.PauseGame();
        _gameOverScreen.SetActive(true);
        _inGameUI.SetActive(false);
    }
}
