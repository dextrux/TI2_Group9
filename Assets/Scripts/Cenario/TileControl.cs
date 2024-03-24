using UnityEngine;

namespace Scenario
{
    public class TileControl : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private TileManager _tileManager;
        [SerializeField] private float _distanceToDisable;
        private void Awake()
        {
            Transform[] _childrens = GetComponentsInChildren<Transform>();
            foreach (Transform t in _childrens)
            {
                t.gameObject.SetActive(true);
            }
        }
        private void Update()
        {
            if (_player.position.z - transform.position.z >= _distanceToDisable)
            {
                _tileManager.DisableTile(gameObject);
            }
        }
    }
}
