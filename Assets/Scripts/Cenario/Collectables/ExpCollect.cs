using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EconomyManager.Instance.UpdateXp(1);
            gameObject.SetActive(false);
            AudioManager.Instance.TocarSFX(3);
        }
    }
}
