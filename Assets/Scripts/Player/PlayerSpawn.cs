using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    void Start()
    {
        PlayerCharacter.Instance.transform.position = transform.position;
    }
}
