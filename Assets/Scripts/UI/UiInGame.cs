using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInGame : MonoBehaviour
{
    void Update()
    {
        UiController.Instance.UpdateTextInGame();
    }
}
