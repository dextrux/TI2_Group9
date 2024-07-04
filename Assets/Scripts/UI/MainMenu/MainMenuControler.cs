using Manager;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControler : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.ResumeGame();
        PlayerCharacter.Instance.GetComponent<InputControl>().EnableMenuMode();
        PlayerCharacter.Instance.GetComponent<PlayerMovement>().IsMoving = false;
        PlayerCharacter.Instance.GetComponent<PlayerMovement>().SetSpeedZero();
        AudioManager.Instance.TocarBGMusic(0);
    }
}
