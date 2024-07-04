using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    void Start()
    {
        PlayerCharacter.Instance.GetComponent<InputControl>().EnablePlayMode();
        PlayerCharacter.Instance.GetComponent<PlayerMovement>().IsMoving = true;
        PlayerCharacter.Instance.GetComponent<PlayerMovement>().SetSpeedNormal();
        AudioManager.Instance.TocarBGMusic(1);
    }
}
