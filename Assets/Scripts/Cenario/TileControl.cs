using UnityEngine;

namespace Scenario
{
    public class TileControl : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private TileManager _tileManager;
        [SerializeField] private float _distanceToDisable;
        private void Update()
        {
            if (_player.position.z - transform.position.z >= _distanceToDisable)
            {
                _tileManager.DisableTile(gameObject);
            }
        }
    }
}
