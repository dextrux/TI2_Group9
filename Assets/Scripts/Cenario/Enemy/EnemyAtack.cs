using Manager;
using UnityEngine;

namespace Scenario.Enemy
{
    public class EnemyAtack : MonoBehaviour
    {
        [SerializeField] Transform _player;
        [SerializeField] float _distanceToPlayerAtack;
        private AudioSource _audioSource;
        private bool _beingHitted;
        private float _distanceTimer;
        private float _startHitDistance;
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _startHitDistance = 0;
            _beingHitted = false;
        }
        private void Update()
        {
            if (_player.position.z - transform.position.z <= 0 && _player.position.z - transform.position.z >= -1 && !_beingHitted)
            {
                UiController.Instance.GameOver();
            } else if (_player.position.z - transform.position.z <= 0 && _player.position.z - transform.position.z >= -3 && _beingHitted)
            {
                _audioSource.Play();
                gameObject.SetActive(false);
            }
            if (_player.position.x != _startHitDistance)
            {
                _distanceTimer = _player.position.z + _distanceToPlayerAtack;
                _startHitDistance = _player.position.x;
            }
            HitVerify();
        }
        private void HitVerify()
        {
            float ratio = _player.position.z / _distanceTimer;
            if (ratio >= 1)
            {
                _beingHitted = false;
            }
            else
            {
                _beingHitted = true;
            }
        }
    }
}
