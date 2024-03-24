using Manager;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager.instance.GameOver();
        }
    }
}
