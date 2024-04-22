using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControler : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.ResumeGame();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayButtonSFX()
    {
        AudioManager.Instance.TocarSFX(0);
    }
}
