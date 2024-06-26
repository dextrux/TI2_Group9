using TMPro;
using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public bool Playing { get; private set; }
        [SerializeField] private GameObject _gameOverScreen;
        [SerializeField] private GameObject _inGameUI;
        private uint _footPrint;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        public void ResumeGame()
        {
            Time.timeScale = 1;
            Playing = true;
            _footPrint = 0;
        }
        public void PauseGame()
        {
            Time.timeScale = 0;
            Playing = false;
        }
        public void GameOver()
        {
            PauseGame();
            _gameOverScreen.SetActive(true);
            _inGameUI.SetActive(false);
            Debug.Log("Game Over");
        }
        public void AddPezinho()
        {
            _footPrint++;
        }
    }
}
