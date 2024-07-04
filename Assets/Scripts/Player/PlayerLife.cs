using Manager;
using UnityEngine;

namespace Player
{
    public class PlayerLife : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacle"))
            {
                UiController.Instance.GameOver();
            }
            else if (other.CompareTag("Collectable"))
            {
                GameManager.instance.AddPezinho();
                other.gameObject.SetActive(false);
            }
            else if (other.CompareTag("Enemy"))
            {

            }
        }
    }
}
