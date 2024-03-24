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
        [SerializeField] private TextMeshProUGUI _pezinhoText;
        private uint _pezinhos;
        private void Start()
        {
            if (instance == null)
            {
                instance = this;
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
            _pezinhos = 0;
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
            _pezinhos++;
            _pezinhoText.text = "Score: " + _pezinhos.ToString("000"); ;
        }
    }
}
