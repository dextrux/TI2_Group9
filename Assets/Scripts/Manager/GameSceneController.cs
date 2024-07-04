using Manager;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] private GameObject _playMenu;
    void Awake()
    {
        GameManager.instance.PauseGame();
        AudioManager.Instance.TocarBGMusic(1);
        _playMenu.SetActive(true);
    }
    public void IniciarPartida()
    {
        GameManager.instance.ResumeGame();
        PlayerCharacter.Instance.transform.position = new Vector3(0, 0, -45);
        PlayerCharacter.Instance.GetComponent<InputControl>().EnablePlayMode();
        PlayerCharacter.Instance.GetComponent<PlayerMovement>().IsMoving = true;
        PlayerCharacter.Instance.GetComponent<PlayerMovement>().SetSpeedNormal();
    }
}
