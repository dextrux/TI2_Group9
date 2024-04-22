using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIControle : MonoBehaviour
{
    public void PlayButtonSFX()
    {
        AudioManager.Instance.TocarSFX(0);
    }
    public void ResumeInGame()
    {
        GameManager.instance.ResumeGame();
    }
    public void LoadSceneGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
