using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControler : MonoBehaviour
{
    
    private void Start()
    {
        GameManager.instance.ResumeGame();
    }
}
