using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public bool Playing { get; private set; }
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
        }
        public void PauseGame()
        {
            Time.timeScale = 0;
            Playing = false;
        }
        public void GameOver()
        {
            PauseGame();
            Debug.Log("Game Over");
        }
    }
}
